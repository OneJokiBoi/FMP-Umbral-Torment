using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolling : MonoBehaviour
{
    public int maxHealth = 10;
    int currentHealth;
    public float speed;
    public float distance;

    Animator anim;

    private bool movingRight = true;

    public Transform groundDetection;
    public Transform playerDetection;
    public Transform player;

    public bool chase = false;
    bool attack = false;

    float chaseRange = 4f;
    float attackRange = 2f;
    float value;

    Vector2 playerVector;
    Vector2 enemyVector;

    Vector2 moveDir;

    [SerializeField] BoxCollider2D col;

    private void Start()
    {
      anim = GetComponent<Animator>();
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
                }

            }
            else
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
            }

            //if not next to player
            if (Vector2.Distance(playerVector, enemyVector) > attackRange)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                anim.SetBool("Attack1", false);
                anim.SetBool("Attack2", false);
                anim.SetBool("Walking", true);
                //gameObject.GetComponentInChildren<BoxCollider2D>().enabled = false;
                col.enabled = false;
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
                //gameObject.GetComponentInChildren<BoxCollider2D>().enabled = true;
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

    void Timer()
    {
        attack = false;
    }


}
