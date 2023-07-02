using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float minX = -5f; // Límite mínimo del rango
    public float maxX = 5f;  // Límite máximo del rango
    public float speed = 3f; // Velocidad del movimiento

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Mover el enemigo horizontalmente dentro del rango con velocidad
        float horizontalMovement = Mathf.PingPong(Time.time * speed, maxX - minX) + minX;
        Vector3 newPosition = new Vector3(horizontalMovement, rb.position.y, rb.position.z);
        rb.MovePosition(newPosition);
    }
}




