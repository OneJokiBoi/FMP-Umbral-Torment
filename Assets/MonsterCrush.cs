using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCrush : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("hit");
        if (collision.gameObject.tag == "Weakpoint")
        {
            Destroy(collision.gameObject);
        }
    }
}
