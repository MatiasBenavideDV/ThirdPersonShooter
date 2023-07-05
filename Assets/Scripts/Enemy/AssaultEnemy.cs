using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Scripts.Enemy
{

    public class AssaultEnemy : Enemy
    {

        private new void Start()
        {
            // Configura las propiedades espec�ficas del enemigo de asalto
            health = 75;
            speed = 3f;
            weaponType = EnemyWeapon.Assault;
            attackRange = 10;

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
                    Debug.Log(damageToTarget);
                    LookAtTarget();
                    projectile.SetDamageAndFireRate(damageToTarget, fireRate);
                }
            }
        }
    }
}
