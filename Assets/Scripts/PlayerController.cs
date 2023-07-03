using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;          // Velocidad de movimiento del personaje
    public float jumpForce = 5f;      // Fuerza de salto del personaje

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Obtener la entrada del jugador
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calcular el vector de movimiento
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        movement *= speed;

        // Aplicar el movimiento al jugador
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        // Saltar si se presiona la tecla de salto (por ejemplo, "Espacio")
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Jump()
    {
        // Comprobar si el personaje está en el suelo antes de saltar
        if (IsGrounded())
        {
            // Aplicar una fuerza hacia arriba para realizar el salto
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private bool IsGrounded()
    {
        // Raycast hacia abajo para comprobar si el personaje está en el suelo
        float raycastDistance = 0.1f;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance))
        {
            return true;
        }

        return false;
    }
}


