using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    protected override void Start()
    {
        base.Start();
        // Configura las propiedades específicas del arma
        damage = 10;
        fireRate = 0.5f;
        burstCount = 1;
        burstInterval = 0f;
    }
}
