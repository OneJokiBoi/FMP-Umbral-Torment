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
            
            Attacking();   
        }
    }

 
    void Attacking()
    {
        print("attacking");

        anim.SetTrigger("AttackShort");

    }
}