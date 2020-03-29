using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmosDisplay : MonoBehaviour
{
    public float radius;
    public Color color;

    private void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position,radius);
    }
}
