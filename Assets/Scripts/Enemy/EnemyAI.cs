using System;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform target; // Referencja do obiektu Player, do którego d¹¿y Enemy
    public float speed = 2f; // Prêdkoœæ ruchu Enemy
    Animator animator;
    bool facingRight = false;

    private void Start()
    {

        animator = GetComponent<Animator>();
        // Szukaj obiektu Player na pocz¹tku gry
        target = GameObject.FindGameObjectWithTag("Player").transform;

        if (target == null)
        {
            Debug.LogError("Nie mo¿na znaleŸæ obiektu Player!");
        }
    }

    private void Update()
    {
        if (target == null)
        {
            // Jeœli nie ma obiektu Player, zakoñcz funkcjê Update
            return;
        }

        // Oblicz wektor kierunku od pozycji Enemy do pozycji Player
        Vector3 direction = target.position - transform.position;

        // Normalizuj wektor kierunku, aby uzyskaæ jednostkowy wektor kierunku
        direction.Normalize();

        // Przesuñ Enemy w kierunku Player z okreœlon¹ prêdkoœci¹
        transform.position += direction * speed * Time.deltaTime;

        if (direction.x < 0 && facingRight)
        {
            Flip();
        }
        if (direction.x > 0 && !facingRight)
        {
            Flip();
        }
        animator.SetFloat("xVelocity", Math.Abs(direction.x));
        animator.SetFloat("yVelocity", Math.Abs(direction.y));

        void Flip()
        {
           facingRight = !facingRight;
           transform.Rotate(0, 180, 0);
        }
    }
}