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
    public Transform player;

    public bool chase = false;

    float chaseRange = 4f;

    Vector2 playerVector;
    Vector2 enemyVector;

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

        //print(Vector2.Distance(playerVector, enemyVector));

    }

}
