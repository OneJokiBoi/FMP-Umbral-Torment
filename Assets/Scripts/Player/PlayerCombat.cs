using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    Animator anim;
    public GameObject attackPoint;
    public GameObject leftattackPoint;
    

    public bool isFacingLeft = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
        leftattackPoint.SetActive(false);
        attackPoint.SetActive(false);
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Attacking();
            attackPoint.SetActive(true);
        }
        if(TryGetComponent<SpriteRenderer>(out SpriteRenderer sprite))
        {
            if (sprite.flipX == true)
            {
                isFacingLeft = true;
                leftattackPoint.SetActive(true);
                attackPoint.SetActive(false);
            }
            else
            {
                isFacingLeft = false;
                leftattackPoint.SetActive(false);
                attackPoint.SetActive(true);
            }
            
        }
        
    }

    public void activateCollider()
    {
        attackPoint.GetComponent<BoxCollider2D>().enabled = true;
        leftattackPoint.GetComponent<BoxCollider2D>().enabled = true;
        print("activating");
    }

    public void disableCollider()
    {
        attackPoint.GetComponent<BoxCollider2D>().enabled = false;
        leftattackPoint.GetComponent<BoxCollider2D>().enabled = false;
        print("disabling");
    }


    public void Attacking()
    {
        print("attacking");

        anim.SetTrigger("AttackShort");

    }

}