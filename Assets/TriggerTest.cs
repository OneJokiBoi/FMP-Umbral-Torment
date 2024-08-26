using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour
{
    public GameObject player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Slime")
        {
            print("hit");
            Destroy(collision.gameObject);
        }
    }

    private void Update()
    {
        gameObject.transform.position = player.transform.position;
    }
}
