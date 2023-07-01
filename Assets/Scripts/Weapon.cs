using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Propiedades del arma
    public int damage;                  // Daño del arma
    public float fireRate;              // Cadencia de fuego (tiempo entre disparos)
    public int burstCount;              // Número de balas en una ráfaga de disparo
    public float burstInterval;         // Intervalo de tiempo entre cada disparo dentro de una ráfaga
    public GameObject bulletPrefab;     // Prefab de la bala

    // Variables internas
    private float nextFireTime;         // Tiempo en el que se puede realizar el próximo disparo
    private int bulletsInCurrentBurst;   // Número de balas restantes en la ráfaga actual

    // Método llamado al inicio del script
    protected virtual void Start()
    {
        nextFireTime = 0f;                       // Inicializa el próximo tiempo de disparo en cero
        bulletsInCurrentBurst = burstCount;       // Inicializa el número de balas restantes en la ráfaga
    }

    // Método para realizar un disparo
    public virtual void Fire()
    {
        // Verifica si ha pasado el tiempo suficiente y aún hay balas restantes en la ráfaga
        if (Time.time > nextFireTime && bulletsInCurrentBurst > 0)
        {
            // Realiza el disparo
            // Aquí puedes implementar la lógica para instanciar una bala o efecto de disparo
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            Destroy(bullet, 3f); // Destruye la bala después de 3 segundos si no colisiona con nada

            bulletsInCurrentBurst--;    // Reduce en uno el número de balas restantes en la ráfaga

            // Establece el próximo tiempo de disparo basado en la cadencia de fuego
            nextFireTime = Time.time + fireRate;

            // Si aún quedan balas en la ráfaga, programa el próximo disparo
            if (bulletsInCurrentBurst > 0)
            {
                Invoke("Fire", burstInterval);    // Invoca el método "Fire" después del intervalo de tiempo especificado
            }
        }
    }
}

