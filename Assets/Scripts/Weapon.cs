using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Propiedades del arma
    public int damage;                  // Da�o del arma
    public float fireRate;              // Cadencia de fuego (tiempo entre disparos)
    public int burstCount;              // N�mero de balas en una r�faga de disparo
    public float burstInterval;         // Intervalo de tiempo entre cada disparo dentro de una r�faga
    public GameObject bulletPrefab;     // Prefab de la bala

    // Variables internas
    private float nextFireTime;         // Tiempo en el que se puede realizar el pr�ximo disparo
    private int bulletsInCurrentBurst;   // N�mero de balas restantes en la r�faga actual

    // M�todo llamado al inicio del script
    protected virtual void Start()
    {
        nextFireTime = 0f;                       // Inicializa el pr�ximo tiempo de disparo en cero
        bulletsInCurrentBurst = burstCount;       // Inicializa el n�mero de balas restantes en la r�faga
    }

    // M�todo para realizar un disparo
    public virtual void Fire()
    {
        // Verifica si ha pasado el tiempo suficiente y a�n hay balas restantes en la r�faga
        if (Time.time > nextFireTime && bulletsInCurrentBurst > 0)
        {
            // Realiza el disparo
            // Aqu� puedes implementar la l�gica para instanciar una bala o efecto de disparo
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            Destroy(bullet, 3f); // Destruye la bala despu�s de 3 segundos si no colisiona con nada

            bulletsInCurrentBurst--;    // Reduce en uno el n�mero de balas restantes en la r�faga

            // Establece el pr�ximo tiempo de disparo basado en la cadencia de fuego
            nextFireTime = Time.time + fireRate;

            // Si a�n quedan balas en la r�faga, programa el pr�ximo disparo
            if (bulletsInCurrentBurst > 0)
            {
                Invoke("Fire", burstInterval);    // Invoca el m�todo "Fire" despu�s del intervalo de tiempo especificado
            }
        }
    }
}

