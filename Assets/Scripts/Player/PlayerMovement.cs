using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb; // rb obiektu, potem input jaki gracz daje, animacja, ustawienie patrzenia w prawo i dołączenie skryptu stats
    private float horizontalInput;
    private float verticalInput;
    Animator animator;
    bool facingRight = true;
    PlayerStats playerStats;



    private void Start()
    {
        animator = GetComponent<Animator>();
        playerStats = GetComponent<PlayerStats>();
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
        // sprawdza input horizontal i vertical dodatkowo przy horizontal zmienia oś sumo żeby patrzył w odpowiednią stronę

    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        movement.Normalize(); // Normalizacja wektora ruchu
        rb.velocity = movement * playerStats.speed;
        animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", Math.Abs(rb.velocity.y));
        // Tworzymy nowy vector2 z nowym ruchem horizontal i vertical, normalizujemy zeby szedł nawet po skosie normalnie, dodajemy przyśpieszenia w zależności gdzie idzie
        // Dodajemy do animacji info jakie jest przyśpieszenie x i y żeby mogła się wykonać odpowiednia animacja
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
        // Obraca sumo o 180 stopnii
    }

}