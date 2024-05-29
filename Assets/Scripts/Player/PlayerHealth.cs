using HutongGames.PlayMaker.Actions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    Vector2 startPos;

    public int maxHealth = 10;
    public int currentHealth;

    public int enemyDamage = 10;

    Animator anim;

    public bool PlayerisAttacked = false;
    bool PlayerisDead = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        startPos = transform.position;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Checks for enemy hitbox layer
        if (collision.gameObject.layer == 10 && PlayerisAttacked == false)
        {
            print("player hit");
            PlayerisAttacked = true;
            playerTakeDamage(enemyDamage);

        }
    }



    public void playerTakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0 && PlayerisDead == false)
        {
            playerDie();
            PlayerisDead = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            gameObject.GetComponent<PlayerMovement>().enabled = false;

            StartCoroutine(Respawn(0.5f));

        }
    }

    public void playerDie()
    {
        anim.SetTrigger("Die");
        anim.SetBool("Dead", true);
    }

    IEnumerator Respawn(float duration)
    {
        yield return new WaitForSeconds(duration);
        transform.position = startPos;
        PlayerisDead = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        gameObject.GetComponent<PlayerMovement>().enabled = true;

        anim.SetBool("Dead", false);
        anim.SetBool("Idle", true);

        PlayerisAttacked = false;
    }

    

   /* private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemyHitBox")
        {
            currentHealth = 0;
            Debug.Log("Hit player");
        }
    }
   */
}

