using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Vector2 startPos;
    public PlayerHealth playerHealth;

    private void Start()
    {
        startPos = transform.position;
        
    }

    /*private void Update()
    {
       if(playerHealth.currentHealth = 0)
        {
            Respawn()
        }

    }*/

    void Respawn()
    {
        transform.position = startPos;
    }




}
