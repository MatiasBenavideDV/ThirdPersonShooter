using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SniperEnemy : Enemy
{

    private new void Start()
    {
        // Configura las propiedades espec�ficas del enemigo sniper
        health = 50;
        speed = 0;
        weaponType = EnemyWeapon.Sniper;
        attackRange = 50;

        base.Start();
    }

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            targetIsInAttackRange = Physics.CheckSphere(transform.position, attackRange, targetLayer);
            if (targetIsInAttackRange)
            {
                LookAtTarget();
                Debug.Log(damageToTarget);
                projectile.SetDamageAndFireRate(damageToTarget, fireRate);
            }
        }
    }
}

