using HutongGames.PlayMaker.Actions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;
    public GameObject EnemyHitBox;


    Animator anim;
    

    bool PlayerisDead = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;

    }

    private void Update()
    {
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
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == EnemyHitBox)
        {

            currentHealth = 0;
           
        }
    }

}
