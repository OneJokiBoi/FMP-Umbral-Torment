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
    public GameObject player;
    
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
            RaycastDebugger();
        }

        //When Hit
        if(hit.collider != null)
        {
            Enemy1();
        }
        else if (hit.collider == null)
        {
            inRange = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            target = collision.gameObject;
            inRange = true;
        }
    }

    void RaycastDebugger()
    {
        if (distance > attackDistance)
        {
            Debug.DrawRay(LOSraycast.position, Vector2.left * rayCastLength, Color.red);
        }
        else if (attackDistance > distance)
        {
            Debug.DrawRay(LOSraycast.position, Vector2.left * rayCastLength, Color.green);
        }
    }



























}
