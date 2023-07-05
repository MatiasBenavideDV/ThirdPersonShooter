using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.Interfaces;

namespace Scripts.Enemy
{

    public class Projectile : MonoBehaviour
    {
        [HideInInspector] public int damage;         // Da�o de la bala
        [HideInInspector] public float speed = 10f;       // Velocidad de la bala
        private Vector3 direction;      // Direcci�n de la bala

        private void Update()
        {
            // Mover la bala en la direcci�n establecida a una velocidad constante
            transform.Translate(direction * speed * Time.deltaTime);

            //El objeto se destruye pasado 1 seg
            Destroy(gameObject, 1f);
        }

        public void SetDirection(Vector3 newDirection)
        {
            // Establecer la direcci�n de la bala
            direction = newDirection.normalized;
        }

        private void OnTriggerEnter(Collider coll)
        {
            IDamageable objectToDamage = coll.GetComponent<IDamageable>();

            if (objectToDamage != null)
            {
                // Aplicar daño al objeto
                objectToDamage.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}
