using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {

    private Rigidbody rb;
    public float moveSpeed = 20f;
    private Vector3 moveDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {

        moveDirection = transform.forward;
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.deltaTime);
    }


}
