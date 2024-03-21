using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;

    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical"); // Pobiera input x i y

        Vector2 movement = new Vector2(horizontalInput, verticalInput);

        if (movement.magnitude > 0.1f) // Magnitude sprawdza czy gracz siê porusza w jakimœ kierunku
        {
            movement.Normalize(); // Dziêki temu nawet id¹c po przek¹tnej mamy tak¹ sam¹ szybkoœæ ruchu jak id¹c w bok
            transform.position += (Vector3)movement * speed * Time.deltaTime; // Nadanie nowej pozycji
        }
    }
}