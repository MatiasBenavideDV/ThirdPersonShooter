using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Enemy
{
    public class MachineGunEnemy : Enemy
    {
        private new void Start()
        {
            // Configura las propiedades espec�ficas del enemigo de ametralladora
            health = 150;
            speed = 2;
            weaponType = EnemyWeapon.MachineGun;
            attackRange = 20;

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
}
