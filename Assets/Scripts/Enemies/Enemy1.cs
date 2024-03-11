using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    [Header("Publics")]
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
    private bool cooldown;
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

       //5:32 from the video continue here!

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            target = collision.gameObject;
            inRange = true;
        }

    }

    private void RayCastDebugger()
    {
        if (distance > attackDistance)
        {
            Debug.DrawRay(LOSraycast.position, Vector2.left * rayCastLength, Color.red);
        }

        if (distance < attackDistance) 
        {
            Debug.DrawRay(LOSraycast.position, Vector2.left * rayCastLength, Color.white);
        }
    }

}
