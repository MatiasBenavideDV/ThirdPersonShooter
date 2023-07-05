using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class Pistol : Weapon
    {
        public override int MaxRange => 30;
        public override int MaxMagazineSize => 15;

        // Start is called before the first frame update
        private void Start()
        {

        }

        // Update is called once per frame
        private void Update()
        {

        }

        public override void Shoot()
        {
            bullet.Fire(gameObject.transform, MaxRange);
        }

    }
}
