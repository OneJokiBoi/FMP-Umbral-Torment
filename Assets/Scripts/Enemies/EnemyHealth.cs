using HutongGames.PlayMaker.Actions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;

    public Color fullHealth;
    public Color halfHealth = Color.red;
    public Color lowHealth = Color.black;

    public SpriteRenderer sprite;
  
    Animator anim;
    GameObject player;

    [SerializeField] BoxCollider2D col;

    bool isDead = false;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        fullHealth = sprite.color;

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
            gameObject.GetComponent<Patrolling> ().enabled = false;
            gameObject.GetComponentInChildren<BoxCollider2D>().enabled = false;
        }
    }
    void die()
    {
        anim.SetTrigger("Die");
        col.enabled = false;

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        print("taking damage");

        if(currentHealth <= 7)
        {
            sprite.color = halfHealth;
        }
        if (currentHealth <= 4)
        {
            sprite.color = lowHealth;
        }

    }   

}
   

