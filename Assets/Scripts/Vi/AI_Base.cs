using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Base : MonoBehaviour
{
    public enum StateBehavior {
        Idle,
        Patrol,
        Persuing,
        Hurt,
        Attack
    }

    public StateBehavior State;

    private Animator anim;

    [Header("BaseProperty")]
    protected float currentHP;
    public float maxHP = 100;

    public float walkSpeed = 3.5f;
    public float runSpeed = 14f;
    public bool isShowingAttackArea;

    [Range(1,10)]
    public float attackArea = 3f;
    public Vector3 attackOffset;
    [Range(4f,20)]
    public float attackDistance = 4.5f;
    public float attackDamage = 35f;
  

    public float getStunTime;
    protected float currentGetStunTime;

    private NavMeshAgent agent;
    private AI_FOV fov;
   


    [Header("Patrol")]
    public bool isRoute;
    public Transform[] patrolPoints;
    public float stoppingTime = 2f;
    float currentstoppTime;
    int nextPatrolPointIndex = 0;

    private NavMeshPath path;
    public Vector2 randomAreaX;
    public Vector2 randomAreaZ;
    public float findPathTime;
    bool isFinding;
    bool vaildPath;

    private bool _isDead;
    public bool isDead { get { return _isDead; } }
    private bool _isHurt;
    public bool isHurt { get { return _isHurt; } }

    protected virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        fov = GetComponent<AI_FOV>();

        currentHP = maxHP;
        agent.speed = walkSpeed;
        path = new NavMeshPath();
    }

    private void Update()
    {
        if (!_isDead)
        {
            switch (State)
            {
                case StateBehavior.Idle:
                    Idle();
                    break;
                case StateBehavior.Patrol:
                    if (isRoute)
                    {
                        Patrol_Route();
                    }
                    else {
                        Patrol_RANDOM();
                    }
                    break;
                case StateBehavior.Persuing:
                    Persuing();
                    break;
                case StateBehavior.Hurt:
                    Hurt();
                    break;
                case StateBehavior.Attack:
                    Attack();
                    break;
            }
        }
        else {
            Die();
        }
    }

    bool IsFindTarget() {
        if (_isHurt && !fov.visibleTargets.Contains(InGameAssetManager.i.player.transform)) {
            fov.visibleTargets.Add(InGameAssetManager.i.player.transform);
        }
        if (fov.visibleTargets.Count > 0) {
            return true;
        }
        return false;
    }

    Vector3 PlayerPosition() {
        if (fov.visibleTargets.Contains(InGameAssetManager.i.player.transform)) {
            return fov.visibleTargets[0].position;
        }
        return Vector3.zero;
    }

    void Idle() {
        anim.SetBool("isWalking",false);
        anim.SetBool("isAttacking", false);
        anim.SetBool("isHurt", false);
        anim.SetBool("isRunning", false);
        if (!IsFindTarget()) {
            if (currentstoppTime < stoppingTime)
            {
                currentstoppTime += Time.deltaTime;
            }
            else
            {
                currentstoppTime = 0;
                State = StateBehavior.Patrol;
            }
        }
        else
        {
            currentstoppTime = 0;
            State = StateBehavior.Persuing;
        }
        if (_isHurt) {
            State = StateBehavior.Hurt;
        }
    }

    void Patrol_Route()
    {
        agent.speed = walkSpeed;
        anim.SetBool("isWalking", true);
        anim.SetBool("isAttacking", false);
        anim.SetBool("isHurt", false);
        anim.SetBool("isRunning", false);
        if (!IsFindTarget())
        {
            float distanceToNextPatrolPoint = Vector3.Distance(transform.position, patrolPoints[nextPatrolPointIndex].position);
            if (distanceToNextPatrolPoint > 1.5f)
            {
                agent.SetDestination(patrolPoints[nextPatrolPointIndex].position);
            }
            else
            {
                nextPatrolPointIndex += 1;
                if (nextPatrolPointIndex > patrolPoints.Length - 1)
                {
                    nextPatrolPointIndex = 0;
                }
            }
        }
        else
        {
            State = StateBehavior.Persuing;
        }
        if (_isHurt)
        {
            State = StateBehavior.Hurt;
        }
    }

    Vector3 GetNewRandomPath() {
        float x = Random.Range(randomAreaX.x,randomAreaX.y);
        float z = Random.Range(randomAreaZ.x,randomAreaZ.y);

        Vector3 newPos = new Vector3(x,transform.position.y,z);
        return newPos;
    }

    void Patrol_RANDOM()
    {
        agent.isStopped = false;
        agent.speed = walkSpeed;
        anim.SetBool("isWalking", true);
        anim.SetBool("isAttacking", false);
        anim.SetBool("isHurt", false);
        anim.SetBool("isRunning", false);
        if (!IsFindTarget())
        {
            if (!isFinding) {
                StartCoroutine(FindNewPath());
            }
        }
        else
        {
            State = StateBehavior.Persuing;
        }
        if (_isHurt)
        {
            State = StateBehavior.Hurt;
        }
    }

    IEnumerator FindNewPath() {
        isFinding = true;
        agent.SetDestination(GetNewRandomPath());
        vaildPath = agent.CalculatePath(GetNewRandomPath(), path);
        yield return new WaitForSeconds(findPathTime);
        if (!vaildPath) {
            Debug.Log("NotVaild");
        }
        while (!vaildPath) {
            agent.SetDestination(GetNewRandomPath());
            vaildPath = agent.CalculatePath(GetNewRandomPath(), path);
        }
        isFinding = false;
    }


    protected virtual void Persuing() {
        agent.isStopped = false;
        agent.speed = runSpeed;
        anim.SetBool("isWalking", false);
        anim.SetBool("isAttacking", false);
        anim.SetBool("isHurt", false);
        anim.SetBool("isRunning", true);
        float distanceToPlayer = Vector3.Distance(transform.position, PlayerPosition());
        if (PlayerPosition() != Vector3.zero)
        {
            agent.SetDestination(PlayerPosition());
        }
        if (!IsFindTarget())
        {
            State = StateBehavior.Patrol;
        }
        else
        {
            if (distanceToPlayer < attackDistance) {
                State = StateBehavior.Attack;
            }
        }
        if (_isHurt)
        {
            State = StateBehavior.Hurt;
        }
    }

    void Attack()
    {
        Vector3 newPos = new Vector3(PlayerPosition().x,transform.position.y,PlayerPosition().z);
        transform.LookAt(newPos);
        agent.isStopped = true;
        anim.SetBool("isWalking", false);
        anim.SetBool("isAttacking", true);
        anim.SetBool("isHurt", false);
        anim.SetBool("isRunning", false);
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.95f)
        {
            State = StateBehavior.Persuing;
        }
    }

    void Hurt() {
        agent.isStopped = true;
        anim.SetBool("isWalking", false);
        anim.SetBool("isAttacking", false);
        anim.SetBool("isHurt", true);
        anim.SetBool("isRunning", false);
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Hurt") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.95f)
        {
            _isHurt = false;
            State = StateBehavior.Persuing;
        }
    }

    public void GetHit() {
        _isHurt = true;
    }

    void Die() {
        
    }

    public void AttackDetect() {
        Collider[] target = Physics.OverlapSphere(transform.position + attackOffset, attackArea, fov.targetMask);
        if (target.Length > 0)
        {
            for (int i = 0; i < target.Length; i++)
            {
                target[i].GetComponent<PlayerDying>().TakeDamage(attackDamage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (isShowingAttackArea) {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position + attackOffset,attackArea);
        }
    }
}
