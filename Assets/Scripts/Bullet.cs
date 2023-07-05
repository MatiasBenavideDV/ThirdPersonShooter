using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class Bullet : MonoBehaviour
    {
        private float distanceTraveled = 0f;
        private float speed = 5f;
        public int maxRange;

        // Update is called once per frame
        void Update()
        {
            float distanceDelta = speed * Time.deltaTime;
            distanceTraveled += distanceDelta;

            if (distanceTraveled >= maxRange)
            {
                Destroy(gameObject);
            }
        }

        public void SetMaxRange(int maxRange)
        {
            this.maxRange = maxRange;
        }

        public void Fire(Transform weaponTransform, int maxRange)
        {
            SetMaxRange(maxRange);
            GameObject newBullet = Instantiate(gameObject, weaponTransform.position, weaponTransform.rotation);
            Rigidbody rb = newBullet.GetComponent<Rigidbody>();
            rb.AddForce(weaponTransform.forward * speed, ForceMode.Impulse);
        }
    }
}
