using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.Interfaces;

public class Enemy : MonoBehaviour
{
    [HideInInspector] public int health;
    [HideInInspector] public float speed;
    [HideInInspector] public float fireRate;

    //***** Tipos de armas que puede tener un enemigo *****//
    protected enum EnemyWeapon { Assault, MachineGun, Sniper };

    //***** Arma asignada al tipo de enemigo, *****//
    protected EnemyWeapon? weaponType;

    //***** Layer dentro de la cual se busca al target *****//
    public LayerMask targetLayer;

    //***** Target *****//
    public Transform targetTransform;

    //***** Rango de ataque que se designa al tipo de enemigo *****//
    public int attackRange;

    //***** Bool que detecta si el target se encuentra dentro del rango de ataque *****//
    protected bool targetIsInAttackRange;

    //***** Script que instancia el proyectil que se dirige hacia el target *****//
    public ProjectileAttack projectile;

    //***** Daño a aplicar a target *****//
    [HideInInspector] public int damageToTarget;

    protected void Start() {
        switch (weaponType)
        {
            case EnemyWeapon.MachineGun:
                damageToTarget = 5;
                fireRate = 0.3f;
                break;
            case EnemyWeapon.Sniper:
                damageToTarget = 25;
                fireRate = 3;
                break;
            default:
                damageToTarget = 10;
                fireRate = 1;
                break;
        }
    }

    protected void LookAtTarget()
    {
        transform.LookAt(targetTransform);
    }

    public void TakeDamage(int damageAmount)
    {
        // Reducir la salud del enemigo según el daño recibido únicamente en el caso de que no haya muerto
        if (health > 0) health -= damageAmount;
    }

    private void OnDrawGizmosSelected() {
        //***** GIZMOS QUE REPRESENTA EL RANGO DE ATAQUE *****//
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}

