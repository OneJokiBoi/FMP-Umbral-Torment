using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    /*[Header("Publics")]
    public Transform LOSraycast;
    public LayerMask raycastMask;
    public float rayCastLength;
    public float attackDistance;
    public float moveSpeed;
    public float timer;

    [Header("Privates")]
    private RaycastHit2D hit;
    private GameObject target;
    private Animator anim;
    private float distance;
    private bool attackMode;
    private bool inRange;
    private bool cooling;
    private float intTimer;


    private void Awake()
    {
        intTimer = timer;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (inRange)
        {
            hit = Physics2D.Raycast(LOSraycast.position, Vector2.left, rayCastLength, raycastMask);
            RayCastDebugger();
        }

        if (hit.collider != null)
        {
            EnemyLogic();
        }

        else if (hit.collider == null)
        {
            inRange = false;
        }

        if (inRange == false)
        {
            anim.SetBool("Walking", false);
            StopAttack();
        }

    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);
        if (distance > attackDistance)
        {
            Move();
            StopAttack();
        }

        else if (attackDistance >= distance && cooling == false)
        {
            Attack();
        }

        if (cooling)
        {
            anim.SetBool("Attack1", false);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            target = collision.gameObject;
            inRange = true;
        }
    }
    private void Move()
    {
        anim.SetBool("Walking", true);

        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack1"))
        {
            Vector2 targetPosition = new Vector2(target.transform.position.x, transform.position.y);

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    void Attack()
    {
        timer = intTimer;
        attackMode = true;

        anim.SetBool("Walking", false);
        anim.SetBool("Attack1", true);
    }

    private void StopAttack()
    {
        cooling = false;
        attackMode = false;
        anim.SetBool("Attack1", false);
    }

    private void RayCastDebugger()
    {
        if (distance > attackDistance)
        {
            Debug.DrawRay(LOSraycast.position, Vector2.left * rayCastLength, Color.red);
        }

        if (distance < attackDistance)
        {
            Debug.DrawRay(LOSraycast.position, Vector2.left * rayCastLength, Color.green);
        }
    }*/

    private void Awake()
    {
      
    }




}
