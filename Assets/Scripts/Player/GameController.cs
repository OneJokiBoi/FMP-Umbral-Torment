using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    Vector2 checkpointPos;
    public PlayerHealth playerHealth;

    private void Start()
    {
        checkpointPos = transform.position;
        
    }

    void Respawn()
    {
        transform.position = checkpointPos;
    }

    public void UpdateCheckpoint(Vector2 pos)
    {
        checkpointPos = pos;
    }

}
