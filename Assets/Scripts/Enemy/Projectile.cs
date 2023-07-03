using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 10;         // Da�o de la bala
    public float speed = 10f;       // Velocidad de la bala
    private Vector3 direction;      // Direcci�n de la bala

    private void Update()
    {
        // Mover la bala en la direcci�n establecida a una velocidad constante
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void SetDirection(Vector3 newDirection)
    {
        // Establecer la direcci�n de la bala
        direction = newDirection.normalized;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto colisionado no tiene la etiqueta "Enemy"
        if (!other.CompareTag("Enemy"))
        {
            // Destruir la bala al colisionar con cualquier objeto que no sea un enemigo
            Destroy(gameObject);
        }
        else
        {
            // Obtener el componente IDamageable del objeto con el que colisiona la bala
            IDamageable damageable = other.GetComponent<IDamageable>();

            // Verificar si el objeto tiene el componente IDamageable
            if (damageable != null)
            {
                // Aplicar da�o al objeto
                damageable.TakeDamage(damage);
            }
        }
    }
}









