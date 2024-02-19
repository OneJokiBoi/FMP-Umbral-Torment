using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolling : MonoBehaviour
{
    public float speed;
    public float distance;

    Animator anim;

    private bool movingRight = true;

    public Transform groundDetection;
    public Transform player;

    public bool chase;

    private void Start()
    {
      anim = GetComponent<Animator>();
    }
    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2.0f, LayerMask.GetMask("Ground"));
        anim.SetBool("Walking", true);

        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;

            }

            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }

        }

    }

    public void detectPlayer()
    {
        chase = true;
    }
}
