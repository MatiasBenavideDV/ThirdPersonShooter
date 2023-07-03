using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemy : MonoBehaviour
{
    public GameObject projectilePrefab;            // Prefab del proyectil
    public Transform projectileSpawnPoint;         // Punto de origen para la instanciación del proyectil
    public float rotationSpeed = 5f;               // Velocidad de rotación de la torreta
    public float fireRate = 1f;                    // Cadencia de fuego (tiempo entre disparos)

    public Transform player;                       // Referencia al jugador

    private float nextFireTime;                     // Tiempo en el que se puede realizar el próximo disparo

    private void Start()
    {
        nextFireTime = Time.time;   // Establecer el tiempo del próximo disparo al inicio
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

            // Establecer el tiempo del próximo disparo
            nextFireTime = Time.time + fireRate;
        }
    }

    private void AimAtPlayer()
    {
        // Obtener la dirección hacia el jugador
        Vector3 direction = player.position - transform.position;
        //direction.y = 0f;   // Ignorar la componente Y para que la torreta no apunte hacia arriba o hacia abajo
        direction *= -1;   // Invertir la dirección para que la torreta apunte hacia el jugador

        // Calcular la rotación hacia el jugador
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        // Aplicar la rotación gradualmente
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private bool CanFire()
    {
        // Verificar si ha pasado el tiempo suficiente desde el último disparo
        return Time.time >= nextFireTime;
    }

    private void FireProjectile()
    {
        // Instanciar el proyectil desde el prefab en la posición del punto de origen
        GameObject projectileObj = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        Projectile projectile = projectileObj.GetComponent<Projectile>();

        // Verificar si el proyectil se ha encontrado correctamente
        if (projectile != null)
        {
            // Configurar la dirección del proyectil
            Vector3 direction = projectileSpawnPoint.forward;
            projectile.SetDirection(direction.normalized);
        }
    }
}


