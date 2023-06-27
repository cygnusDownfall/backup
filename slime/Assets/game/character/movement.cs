using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class movement : MonoBehaviour
{
    public Vector3 dir = Vector3.zero;
    protected Rigidbody rb;
    public float speed = 0;
    public bool isMoving
    {
        get
        {
            return animator.GetBool("isMoving");
        }
        set
        {
            animator.SetBool("isMoving", value);
        }
    }
    Animator animator;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        Move();
    }
    protected void Move()
    {
        if (dir == Vector3.zero)
        {
            if (isMoving)
                isMoving = false;
            return;
        }
        rb.velocity = dir * speed;
        if (!isMoving)
        {
            isMoving = true;
        }
    }
}
