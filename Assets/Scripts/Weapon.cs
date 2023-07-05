using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public abstract class Weapon : MonoBehaviour
    {
        public GameObject ammoType;

        public void Shoot()
        {
            Instantiate(ammoType);
        }
    }
}
