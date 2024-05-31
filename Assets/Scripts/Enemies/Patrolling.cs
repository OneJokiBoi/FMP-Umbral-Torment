using HutongGames.PlayMaker.Actions;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Patrolling : MonoBehaviour
{
    public EnemyHealth enemyHealth;

    Animator anim;

    //MOVEMENT
    public float speed;
    public float distance;

    private bool movingRight = true;
    private bool beingAttacked = false;

    public Transform groundDetection;
    public Transform playerDetection;
    public Transform player;

    //ATTACKING
    public int playerDamage = 10;
    public bool chase = false;

    bool attack = false;
    public float chaseRange = 4f;
    public float attackRange = 2f;
    float value;

    public GameObject HitPoint;

    Vector2 playerVector;
    Vector2 enemyVector;

    Vector2 moveDir;

    [SerializeField] BoxCollider2D col;

    private void Start()
    {
      anim = GetComponent<Animator>();
      HitPoint.SetActive(false);
    }

    private void Update()
    {
        if (!chase)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2.0f, LayerMask.GetMask("Ground"));
            anim.SetBool("Walking", true);

            if (groundInfo.collider == false)
            {
                if (movingRight == true)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    movingRight = false;

                }

                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    movingRight = true;
                }

            }
        }
        if (chase)
        {
            RaycastHit2D playerInfo = Physics2D.Raycast(playerDetection.position, Vector2.right, 20.0f, LayerMask.GetMask("Player"));
            if(playerInfo.collider != null)
            {
                if (playerInfo.collider.tag == "Player")
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    HitPoint.SetActive(true);
                }
            }
            else
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                HitPoint.SetActive(true);

            }

            if (Vector2.Distance(playerVector, enemyVector) > attackRange)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                anim.SetBool("Attack1", false);
                anim.SetBool("Attack2", false);
                anim.SetBool("Walking", true);
                col.enabled = false;
                HitPoint.SetActive(false);
            }

            else
            {
                if (!attack)
                {
                    value = Random.Range(0, 2);
                    attack = true;
                    Invoke("Timer", 1);
                }
                
                if(value == 0)
                {
                    anim.SetBool("Attack1", true);
                    anim.SetBool("Attack2", false);
                }
                if (value == 1)
                {
                    anim.SetBool("Attack2", true);
                    anim.SetBool("Attack1", false);
                }
                anim.SetBool("Walking", false);
                col.enabled = true;
            }
            
        }

        if(Vector2.Distance(playerVector, enemyVector) < chaseRange)
        {
            chase = true;
        }
        else
        {
            chase = false;
        }

        playerVector = new Vector2(player.transform.position.x, player.transform.position.y);
        enemyVector = new Vector2(transform.position.x, transform.position.y);
        player = GameObject.FindGameObjectWithTag("Player").transform;
  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "AttackPoint" && beingAttacked == false)
        {
            print("touching player");
            beingAttacked = true;
            Invoke("attackTimer", 0.5f);
            enemyHealth.TakeDamage(playerDamage);
            
        }
        else if(collision.gameObject.name == "leftattackPoint" && beingAttacked == false)
        {

            print("touching player");
            beingAttacked = true;
            Invoke("attackTimer", 0.5f);
            enemyHealth.TakeDamage(playerDamage);


        }
    }

    void attackTimer()
    {
        beingAttacked = false;
    }

    void Timer()
    {
        attack = false;
    }


}
