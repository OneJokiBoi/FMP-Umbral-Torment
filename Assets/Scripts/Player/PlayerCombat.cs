using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    Animator anim;
    public GameObject attackPoint;
    public float radius;
    public LayerMask Enemy;
    public int _swordDamage;
    public float _swordRange;

    public bool isFacingLeft = false;

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
        if(TryGetComponent<SpriteRenderer>(out SpriteRenderer sprite))
        {
            if (sprite.flipX == true)
            {
                isFacingLeft = true;
            }
            
        }
        
    }

 
    public void Attacking()
    {
        print("attacking");

        anim.SetTrigger("AttackShort");

    }

    public void rayOut()
    {

        Vector3 middlePoint = new Vector3(transform.position.x, transform.position.y / 2, transform.position.z);
        if(isFacingLeft == false)
        {
            RaycastHit2D hit = Physics2D.Raycast(middlePoint, Vector2.right, _swordRange);
            if (hit.collider != null && hit.collider.gameObject.TryGetComponent<EnemyHealth>(out EnemyHealth enemy))
            {
                enemy.TakeDamage(_swordDamage);

            }
        }
        else if(isFacingLeft == true)
        {
            RaycastHit2D hit = Physics2D.Raycast(middlePoint, Vector2.left, _swordRange);
            if (hit.collider != null && hit.collider.gameObject.TryGetComponent<EnemyHealth>(out EnemyHealth enemy))
            {
                enemy.TakeDamage(_swordDamage);

            }
        }

         
    }
}