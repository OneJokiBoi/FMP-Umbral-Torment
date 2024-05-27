using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    Animator anim;
    public GameObject attackPoint;
    public GameObject leftattackPoint;
    public float radius;
    public int swordDamage;

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

    /*public void rayOut()
    {

        Vector3 middlePoint = new Vector3(mP.transform.position.x, mP.transform.position.y, mP.transform.position.z);
        Vector3 rightPoint = new Vector3(rP.transform.position.x, rP.transform.position.y, rP.transform.position.z);
        Vector3 leftPoint = new Vector3(lP.transform.position.x, lP.transform.position.y, lP.transform.position.z);
        if (isFacingLeft == false)
        {
            RaycastHit2D hit = Physics2D.Raycast(middlePoint, rightPoint, _swordRange, mask);
            Debug.DrawLine(middlePoint, hit.point, Color.red);
            print("shoot right");
            if (hit.collider != null && hit.collider.gameObject.TryGetComponent<EnemyHealth>(out EnemyHealth enemy))
            {
                enemy.TakeDamage(_swordDamage);

            }

        }
        else if(isFacingLeft == true)
        {
            RaycastHit2D hit = Physics2D.Raycast(middlePoint, leftPoint, _swordRange, mask);
            Debug.DrawLine(middlePoint, hit.point, Color.red);
            print("shoot left");
            if (hit.collider != null && hit.collider.gameObject.TryGetComponent<EnemyHealth>(out EnemyHealth enemy))
            {
                enemy.TakeDamage(_swordDamage);

            }
        }

         
    }*/
}