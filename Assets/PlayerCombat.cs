using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }

        if (Input.GetMouseButtonUp(0))
        {
            stopAttack();
        }
    }

    void Attack()
    {
        anim.SetBool("Attacking", true);
    }

    void stopAttack()
    {
        anim.SetBool("Attacking", false);
    }
}