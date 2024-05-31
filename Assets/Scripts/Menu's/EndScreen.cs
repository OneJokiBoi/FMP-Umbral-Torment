using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
          SceneManager.LoadScene("End Screen");
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
