using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    protected override void Start()
    {
        base.Start();
        // Configurar las propiedades específicas del arma
        damage = 5;
        fireRate = 1f;
        burstCount = 5;
        burstInterval = 0.1f;
    }
}

