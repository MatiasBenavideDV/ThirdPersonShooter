using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class Rifle : Weapon
    {
        public override int MaxRange => 50;
        public override int MaxMagazineSize => 30;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public override void Shoot()
        {
            Debug.Log(MaxRange);
            bullet.Fire(gameObject.transform, MaxRange);
        }
    }
}
