using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class Pistol : Weapon
    {
        public override int MaxRange => 30;
        public override int MaxMagazineSize => 15;

        public override void Shoot()
        {
            bullet.Fire(gameObject.transform, MaxRange);
        }

    }
}
