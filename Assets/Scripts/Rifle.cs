using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class Rifle : Weapon
    {
        public override int MaxRange => 50;
        public override int MaxMagazineSize => 30;

        public override void Shoot()
        {
            Debug.Log(MaxRange);
            bullet.Fire(gameObject.transform, MaxRange);
        }
    }
}
