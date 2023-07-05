using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShoot : MonoBehaviour
{
    public GameObject bulletPrefab;         // Prefab de la bala
    public float initialSpeed = 10f;        // Velocidad inicial de la bala
    public Transform bulletSpawnPoint;      // Punto de spawn de la bala

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    public void Fire()
    {
        // Instanciar la bala en el punto de spawn
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        // Obtener el Rigidbody de la bala
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        if (bulletRb == null)
        {
            // Si no hay Rigidbody adjunto, añadirlo
            bulletRb = bullet.AddComponent<Rigidbody>();
        }

        // Obtener la dirección hacia adelante del punto de spawn
        Vector3 spawnForward = bulletSpawnPoint.forward;

        // Aplicar velocidad inicial a la bala en la dirección hacia adelante del punto de spawn
        bulletRb.velocity = spawnForward * initialSpeed;

        // Destruir la bala después de un tiempo
        Destroy(bullet, 3f);
    }

}
