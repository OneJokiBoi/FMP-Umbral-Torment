using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    Animator anim;
    public GameObject attackPoint;
    public float radius;
    public LayerMask Enemy;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            hitz();
            
        }

        //if (Input.GetMouseButtonUp(0))
        //{
        //    stopAttack();
       // }
    }

    /*void Attack()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, Enemy);

        foreach (Collider2D enemyGameobject in enemy)
        {
            Debug.Log("Hit");
        }
       

    }*/

    void stopAttack()
    {
        //anim.SetTrigger("Attacking", false);
 
    }

    void hitz()
    {
        print("attacking");

        anim.SetTrigger("Attacking");

    }
}