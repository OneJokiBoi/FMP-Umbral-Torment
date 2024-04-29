using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 10;
    int currentHealth;

    Animator anim;
    GameObject player;

    bool isDead = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        
    }
    private void Update()
    {
        if (currentHealth <= 0 && isDead == false)
        {
            die();
            isDead = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            gameObject .GetComponent<Patrolling> ().enabled = false;
        }
    }
    void die()
    {
        anim.SetTrigger("Die");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {

            
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            currentHealth = 0;
            
        }
    }



}
   

