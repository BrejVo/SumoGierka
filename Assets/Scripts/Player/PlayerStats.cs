using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public float speed;
    public float mass;
    public float drag;
    public float money;
    [SerializeField]Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartStats();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartStats()
    {
        rb.mass = 10f;
        rb.drag = 10f;
        mass = rb.mass;
        drag = rb.drag;
        speed = 2f;
        money = 0;
    }
}
