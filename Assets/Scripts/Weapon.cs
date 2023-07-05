using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public abstract class Weapon : MonoBehaviour
    {
        public GameObject bulletPrefab;
        //***** Prefab de la bala *****//

        public Bullet bullet;
        //***** Script de la bala *****//

        public abstract int MaxRange { get; }
        //***** Rango máximo de la bala *****//

        public abstract int MaxMagazineSize { get; }

        private void Awake() {
            bullet = bulletPrefab.GetComponent<Bullet>();
        }

        public abstract void Shoot();
    }
}
