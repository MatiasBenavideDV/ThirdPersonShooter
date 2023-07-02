using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 10;         // Da�o de la bala
    public float speed = 10f;       // Velocidad de la bala
    public float lifetime = 5f;     // Tiempo de vida de la bala

    private Rigidbody rb;
    private Transform target;       // Referencia al transform del jugador

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player").transform;  // Encuentra el jugador por su etiqueta "Player"

        // Destruir la bala despu�s del tiempo de vida
        Destroy(gameObject, lifetime);
    }

    private void FixedUpdate()
    {
        // Calcular la direcci�n hacia el jugador
        Vector3 direction = (target.position - transform.position).normalized;

        // Mover la bala en la direcci�n calculada con la velocidad especificada
        Vector3 movement = direction * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Obtener el componente IDamageable del objeto con el que colisiona la bala
        IDamageable damageable = other.GetComponent<IDamageable>();

        // Verificar si el objeto tiene el componente IDamageable
        if (damageable != null)
        {
            // Aplicar da�o al objeto
            damageable.TakeDamage(damage);

            // Destruir la bala si no colisiona con un enemigo
            if (!other.CompareTag("Enemy"))
            {
                Destroy(gameObject);
            }
        }
        else
        {
            // Destruir la bala si no colisiona con un objeto da�able
            Destroy(gameObject);
        }
    }
}




