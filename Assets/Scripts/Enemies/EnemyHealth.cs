using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public Attributes enemyAtm;
    //public int maxHealth = 10;
    //int currentHealth;

    Animator anim;
    GameObject player;

    bool isDead = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        //currentHealth = maxHealth;
        enemyAtm = GetComponent<Attributes>();
    }
    private void Update()
    {
        if (enemyAtm.health <= 0 && isDead == false)
        {
            die();
            isDead = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            gameObject.GetComponent<Patrolling> ().enabled = false;
            gameObject.GetComponentInChildren<BoxCollider2D>().enabled = false;
        }
    }
    void die()
    {
        anim.SetTrigger("Die");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerHitBox")
        {
            enemyAtm.health = 0;
            
        }
    }



}
   

