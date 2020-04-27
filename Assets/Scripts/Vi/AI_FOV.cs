using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_FOV : MonoBehaviour
{
    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    public float persistentTraceingTime = 8f;
    [SerializeField]
    float currentpersistentTraceingTime;

    public List<Transform> visibleTargets = new List<Transform>();

 

    private void Update()
    {
        FindIsVisibleTargets();
    }

    void FindIsVisibleTargets()
    {
        if (visibleTargets.Count > 0)
        {
            if (currentpersistentTraceingTime < persistentTraceingTime)
            {
                currentpersistentTraceingTime += Time.deltaTime;
            }
            else
            {
                currentpersistentTraceingTime = 0;
                visibleTargets.Clear();
            }
        }
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);
        TargetInSameHeight();

        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToAngle = (target.position - transform.position).normalized;
            float dstToTarget = Vector3.Distance(transform.position, target.position);

            if (Vector3.Angle(transform.forward, dirToAngle) < viewAngle / 2 && dstToTarget < viewRadius)
            {
                if (!Physics.Raycast(transform.position, dirToAngle, dstToTarget, obstacleMask))
                {
                    if (!visibleTargets.Contains(target)) {
                        visibleTargets.Add(target);
                    }
                }
            }
        }
    }

    List<Collider> TargetInSameHeight()
    {
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);
        List<Collider> selecteTargets = new List<Collider>();
        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            if (Mathf.Abs(targetsInViewRadius[i].transform.position.y - transform.position.y) < 3) {
                if (!selecteTargets.Contains(targetsInViewRadius[i])) {
                    selecteTargets.Add(targetsInViewRadius[i]);
                }
            }
        }
        return selecteTargets;
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
