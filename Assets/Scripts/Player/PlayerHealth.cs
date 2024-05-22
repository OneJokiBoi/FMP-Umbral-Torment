using HutongGames.PlayMaker.Actions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;

    Animator anim;
    

    bool PlayerisDead = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;

    }

    private void Update()
    {
        /*if (currentHealth <= 0 && PlayerisDead == false)
        {
            playerDie();
            PlayerisDead = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            gameObject.GetComponent<PlayerMovement>().enabled = false;

        }*/
    }

    public void takeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0 && PlayerisDead == false)
        {
            playerDie();
            PlayerisDead = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            gameObject.GetComponent<PlayerMovement>().enabled = false;

        }
    }


    void playerDie()
    {
        anim.SetTrigger("Die");
        anim.SetBool("Dead", true);
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemyHitBox")
        {
            currentHealth = 0;
            Debug.Log("Hit player");
        }
    }

}

