using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
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

        // Aplicar velocidad inicial a la bala
        bulletRb.velocity = bullet.transform.forward * initialSpeed;

        // Destruir la bala después de un tiempo
        Destroy(bullet, 3f);
    }
}
