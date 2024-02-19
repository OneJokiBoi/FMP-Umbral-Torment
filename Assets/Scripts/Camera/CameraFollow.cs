using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private float followSpeed = 0.1f;

    [SerializeField] private Vector3 offset;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, followSpeed);
    }
}
