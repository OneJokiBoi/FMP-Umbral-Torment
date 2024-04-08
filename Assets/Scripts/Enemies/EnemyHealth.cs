using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 10;
    int currentHealth;

    Animator anim;
    GameObject player;


    void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = 10; 
        if (currentHealth >= 0) die();
    }

    {
        if (collision.gameObject.name == "player");
    }

    void die()
    { 
        anim.SetBool("Die", true );
    }
    
}
