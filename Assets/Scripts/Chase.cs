using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{

    public enum AIState
    {
        Idle,
        Patrol,
        Persuing
    }


    public AIState State;

    public Transform player;
    static Animator anim;

    public GameObject[] waypoints;
    int currentWP = 0;
    public float rotSpeed = 0.2f;
    public float speed = 1.5f;
    public float accuracyWP = 5.0f;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 direction = player.position - this.transform.position;
        direction.y = 0;
        float angle = Vector3.Angle(direction, this.transform.forward);

        float distanceToParolPoint = Vector3.Distance(waypoints[currentWP].transform.position, transform.position);
        float distanceToPlayer = Vector3.Distance(player.position, this.transform.position);
     
        switch (State)
        {
            case AIState.Idle:
                State = AIState.Patrol;
                break;
            case AIState.Patrol:

                if (distanceToPlayer < 10 && angle < 30)
                {
                    State = AIState.Persuing;
                }
                else
                {
                    if (waypoints.Length > 0)
                    {
                        direction = waypoints[currentWP].transform.position - transform.position;
                        this.transform.rotation = Quaternion.Slerp(transform.rotation,
                                           Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);

                        

                        this.transform.Translate(0, 0, Time.deltaTime * speed);
                        anim.SetBool("isWalking", true);
                        if (distanceToParolPoint < accuracyWP)
                        {
                            currentWP++;
                            if (currentWP >= waypoints.Length)
                            {
                                currentWP = 0;
                            }
                        }
                    }
                }

                break;

            case AIState.Persuing:
                if (distanceToPlayer > 10 || angle > 30)
                {
                    anim.SetBool("isAttacking", false);
                    State = AIState.Patrol;
                }
                else
                {
                    this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                                              Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);

                    if (direction.magnitude > 5)
                    {
                        this.transform.Translate(0, 0, Time.deltaTime * speed);
                        anim.SetBool("isWalking", true);
                        anim.SetBool("isAttacking", false);
                        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                                   Quaternion.LookRotation(direction), 0.1f);
                    }
                    else
                    {
                        anim.SetBool("isAttacking", true);
                        anim.SetBool("isWalking", false);
                        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                                   Quaternion.LookRotation(direction), 0.1f);
                    }
                }
                break;
        }
    }
}
