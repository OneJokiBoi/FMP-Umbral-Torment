using HutongGames.PlayMaker.Actions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    GameController gameController;

    private void Awake()
    {
        gameController= GameObject.FindGameObjectWithTag("Player").GetComponent<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            print("checkpoint hit");
            //gameController.UpdateCheckpoint(transform.position);
            GameObject.Find("Player").GetComponent<PlayerHealth>().startPos= collision.transform.position;
        }
    }

}
