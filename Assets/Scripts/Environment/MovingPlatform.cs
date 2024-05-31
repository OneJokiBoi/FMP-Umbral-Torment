using HutongGames.PlayMaker.Actions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
   public Transform pos1;
   public Transform pos2;
   public float speed;
   Vector3 targetPos;

    

    private void Start()
    {
        

        targetPos = pos2.position;
        

    }

    private void FixedUpdate()
    {
       if(Vector2.Distance(transform.position, pos1.position) < 0.05f)
       {
            targetPos = pos2.position;
            
       }
        
       if(Vector2.Distance(transform.position, pos2.position) < 0.05f)
        {
            targetPos = pos1.position;
           
        }

       transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

    }

   



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {

            collision.transform.parent = this.transform;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            
            collision.transform.parent = null;
            
        }
    }

}
