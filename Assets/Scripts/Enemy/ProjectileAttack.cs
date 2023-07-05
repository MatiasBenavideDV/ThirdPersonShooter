using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAttack : MonoBehaviour
{
    // Prefab del proyectil
    public GameObject projectilePrefab;

    // Punto de origen para la instanciaci�n del proyectil
    public Transform projectileSpawnPoint;

    // Cadencia de fuego (tiempo entre disparos)
    [HideInInspector] public float fireRate;

    // Tiempo en el que se puede realizar el pr�ximo disparo
    private float nextFireTime;

    [HideInInspector] public int damageToTarget;

    private void Start()
    {
        nextFireTime = Time.time;
    }

    private void Update()
    {
        // Verificar si se puede realizar un disparo
        if (CanFire())
        {
            // Instanciar un proyectil
            Shoot(damageToTarget);

            // Establecer el tiempo del pr�ximo disparo
            nextFireTime = Time.time + fireRate;
        }
    }

    private bool CanFire()
    {
        // Verificar si ha pasado el tiempo suficiente desde el �ltimo disparo
        return Time.time >= nextFireTime;
    }

    //***** Instancia un objeto y le da impulso hacia el target asignando que recibe por parámetro *****//
    public void Shoot(int damageToTarget)
    {
        GameObject projectileObj = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        Rigidbody projectileRb = projectileObj.GetComponent<Rigidbody>();
        Projectile projectile = projectileObj.GetComponent<Projectile>();
        projectileRb.AddForce(transform.forward * 50f, ForceMode.Impulse);
        projectile.damage = damageToTarget;
    }

    public void SetDamageAndFireRate(int damageToTarget, float fireRate)
    {
        this.damageToTarget = damageToTarget;
        this.fireRate = fireRate;
    }
}


