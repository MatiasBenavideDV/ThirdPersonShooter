using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;             // Velocidad de movimiento del personaje
    public float rotationSpeed = 5f;     // Velocidad de rotaci�n horizontal

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
        rb.velocity = new Vector3(moveDirection.x * speed, rb.velocity.y, rb.velocity.z);

        // Movimiento vertical
        float moveVertical = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, moveVertical * speed);

        // Rotaci�n horizontal para apuntar con la c�mara
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up, mouseX * rotationSpeed);
    }
}
