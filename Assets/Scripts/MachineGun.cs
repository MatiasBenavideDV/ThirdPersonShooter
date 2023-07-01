using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : Weapon
{
    protected override void Start()
    {
        base.Start();
        // Configurar las propiedades específicas del arma
        damage = 7;
        fireRate = 0.2f;
        burstCount = 1;
        burstInterval = 0f;
    }
}
