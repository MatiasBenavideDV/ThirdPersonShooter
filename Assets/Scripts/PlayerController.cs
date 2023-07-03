using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;             // Velocidad de movimiento del personaje

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Movimiento horizontal
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 moveDirection = new Vector3(moveHorizontal, 0f, 0f);
        rb.velocity = new Vector3(moveDirection.x * speed, rb.velocity.y, 0f);
    }
}
