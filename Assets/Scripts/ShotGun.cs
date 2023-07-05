using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class ShotGun : Weapon
    {

        public override int MaxRange => 15;
        public override int MaxMagazineSize => 7;

        public override void Shoot()
        {
            Debug.Log(MaxRange);
            bullet.Fire(gameObject.transform, MaxRange);
        }
    }
}
