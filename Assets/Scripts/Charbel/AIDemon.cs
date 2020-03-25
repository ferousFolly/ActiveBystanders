using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDemon : MonoBehaviour
{
    public enum AIState
    {
        Idle,
        Patrol,
        Persuing,
        Hurt,
        Death,
        Attack
    }


    public AIState State;

    public Transform player;
    public SphereCollider attackCollider;
    private Animator anim;
    private AudioSource footStep;

    public GameObject[] waypoints;
    int currentWP = 0;
    public float rotSpeed = 0.2f;
    public float speed = 1.5f;
    public float accuracyWP = 5.0f;

    public float MaxHealth = 100f;
    [SerializeField]
    private float CurrentHealth = 0f;
    private bool isHurt;
    private bool isDead;
    public bool _isDead {
        get {
            return isDead;
        }
    }

    void Start()
    {
        attackCollider.enabled = false;
        anim = GetComponent<Animator>();
        CurrentHealth = MaxHealth;
        footStep = GetComponent<AudioSource>();
    }

    public void Attacking(int i)
    {
        attackCollider.enabled = (i == 0) ? false : true;
    }


    void Update()
    {
        if (CurrentHealth <= 0)
        {
            isDead = true;
        }

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
                if (!isDead)
                {
                    if (!isHurt)
                    {
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
                                PlayFootStep(true);
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
                    }
                    else
                    {
                        State = AIState.Hurt;
                    }
                }
                else {
                    State = AIState.Death;
                }
               
                break;

            case AIState.Persuing:
                if (!isDead) {
                    if (!isHurt)
                    {
                        if (distanceToPlayer > 10 || angle > 30)
                        {
                            anim.SetBool("isAttacking", false);
                            State = AIState.Patrol;
                        }
                        else
                        {
                            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                                                      Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);
                            this.transform.Translate(0, 0, Time.deltaTime * speed);
                            if (distanceToPlayer < 5.5f)
                            {
                                anim.SetBool("isWalking", false);
                                PlayFootStep(false);
                                State = AIState.Attack;
                            }
                        }
                    }
                    else
                    {
                        State = AIState.Hurt;
                    }
                }
                else
                {
                    State = AIState.Death;
                }
                break;
            case AIState.Attack:
                if (!isDead)
                {
                    if (!isHurt)
                    {
                        anim.SetBool("isAttacking", true);
                        if (distanceToPlayer > 5.5f)
                        {
                            anim.SetBool("isAttacking", false);
                            PlayFootStep(true);
                            State = AIState.Persuing;
                        }
                    }
                    else
                    {
                        State = AIState.Hurt;
                    }
                }
                else {
                    State = AIState.Death;
                }
                break;
            case AIState.Hurt:
                anim.SetBool("isAttacking", false);
                PlayFootStep(false);
                if (anim.GetCurrentAnimatorStateInfo(0).IsName("isHurt") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.98f) {
                    isHurt = false;
                    State = AIState.Patrol;
                }
                break;

            case AIState.Death:
                anim.SetBool("isAttacking", false);
                anim.SetBool("isWalking", false);
                anim.SetTrigger("isDead");
                PlayFootStep(false);
                break;
        }
    }

    public void GetHit(float damage)
    {
        if (CurrentHealth > 0)
        {
            isHurt = true;
            anim.SetTrigger("isHurt");
            CurrentHealth -= damage;
        }
    }

    void PlayFootStep(bool b) {
        if (!footStep.isPlaying && b) {
            footStep.Play();
        }
        if (!b && footStep.isPlaying)
        {
            footStep.Stop();
        }
    }
}
