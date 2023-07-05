using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Enemy
{
    public class TurretEnemy : MonoBehaviour
    {
        public GameObject projectilePrefab;            // Prefab del proyectil
        public Transform projectileSpawnPoint;         // Punto de origen para la instanciaci�n del proyectil
        public float rotationSpeed = 5f;               // Velocidad de rotaci�n de la torreta
        public float fireRate = 1f;                    // Cadencia de fuego (tiempo entre disparos)

        public Transform player;                       // Referencia al jugador

        private float nextFireTime;                     // Tiempo en el que se puede realizar el pr�ximo disparo

        private void Start()
        {
            nextFireTime = Time.time;   // Establecer el tiempo del pr�ximo disparo al inicio
        }

        private void Update()
        {
            // Apuntar al jugador
            AimAtPlayer();

            // Verificar si se puede realizar un disparo
            if (CanFire())
            {
                // Disparar un proyectil
                FireProjectile();

                // Establecer el tiempo del pr�ximo disparo
                nextFireTime = Time.time + fireRate;
            }
        }

        private void AimAtPlayer()
        {
            // Obtener la direcci�n hacia el jugador
            Vector3 direction = player.position - transform.position;
            //direction.y = 0f;   // Ignorar la componente Y para que la torreta no apunte hacia arriba o hacia abajo
            direction *= -1;   // Invertir la direcci�n para que la torreta apunte hacia el jugador

            // Calcular la rotaci�n hacia el jugador
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            // Aplicar la rotaci�n gradualmente
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        private bool CanFire()
        {
            // Verificar si ha pasado el tiempo suficiente desde el �ltimo disparo
            return Time.time >= nextFireTime;
        }

        private void FireProjectile()
        {
            // Instanciar el proyectil desde el prefab en la posici�n del punto de origen
            GameObject projectileObj = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
            Projectile projectile = projectileObj.GetComponent<Projectile>();

            // Verificar si el proyectil se ha encontrado correctamente
            if (projectile != null)
            {
                // Configurar la direcci�n del proyectil
                Vector3 direction = projectileSpawnPoint.forward;
                projectile.SetDirection(direction.normalized);
            }
        }
    }
}
