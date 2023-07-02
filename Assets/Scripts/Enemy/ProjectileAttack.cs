using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAttack : Attack
{
    public GameObject projectilePrefab;     // Prefab del proyectil
    public Transform projectileSpawnPoint;  // Punto de origen para la instanciaci�n del proyectil
    public float fireRate = 0.5f;           // Cadencia de fuego (tiempo entre disparos)

    private float nextFireTime;             // Tiempo en el que se puede realizar el pr�ximo disparo

    protected override void Start()
    {
        base.Start();
        nextFireTime = Time.time;
    }

    protected override void Update()
    {
        base.Update();

        // Verificar si se puede realizar un disparo
        if (CanFire())
        {
            // Instanciar un proyectil
            InstantiateProjectile();

            // Establecer el tiempo del pr�ximo disparo
            nextFireTime = Time.time + fireRate;
        }
    }

    private bool CanFire()
    {
        // Verificar si ha pasado el tiempo suficiente desde el �ltimo disparo
        return Time.time >= nextFireTime;
    }

    private void InstantiateProjectile()
    {
        // Instanciar el proyectil desde el prefab en la posici�n del punto de origen
        GameObject projectileObj = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        Projectile projectile = projectileObj.GetComponent<Projectile>();

        // Verificar si el proyectil se ha encontrado correctamente
        if (projectile != null)
        {
            // Asignar el objetivo del proyectil si implementa la interfaz IDamageable
            IDamageable damageable = projectileObj.GetComponent<IDamageable>();
            if (damageable != null && target != null)
            {
                damageable.TakeDamage(10); // Cambiar el valor del da�o seg�n tus necesidades
            }
        }
    }
}
