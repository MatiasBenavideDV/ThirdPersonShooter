using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MachineGunEnemy : Enemy
{
    private new void Start()
    {
        // Configura las propiedades espec�ficas del enemigo de ametralladora
        health = 150;
        weaponType = EnemyWeapon.MachineGun;

        base.Start();
    }

    private void Update()
    {
        // Implementa el comportamiento espec�fico del enemigo de ametralladora
    }
}

