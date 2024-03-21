using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    [SerializeField] private Rigidbody2D rb;
    private float horizontalInput;
    private float verticalInput;
    Animator animator;
    bool facingRight = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        if (horizontalInput < 0 && facingRight)
        {
            Flip();
        }
        if (horizontalInput > 0 && !facingRight)
        {
            Flip();
        }
        verticalInput = Input.GetAxisRaw("Vertical");

    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        movement.Normalize(); // Normalizacja wektora ruchu
        rb.velocity = movement * speed;
        animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", Math.Abs(rb.velocity.y));
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
}