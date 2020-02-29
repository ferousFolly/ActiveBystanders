using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_chase : MonoBehaviour
{


    private NavMeshAgent AI;

    public GameObject Player;

    public float AIDistance = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        AI = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);

        if (distance < AIDistance)

        {
            Vector3 dirToPlayer = transform.position - Player.transform.position;

            Vector3 newPos = transform.position - dirToPlayer;

            AI.SetDestination(newPos);
        }
    }
}
