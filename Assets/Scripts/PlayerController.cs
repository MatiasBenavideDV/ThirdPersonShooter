using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scripts.Interfaces;

namespace Scripts
{
    public class PlayerController : MonoBehaviour, IDamageable
    {
        // Vida del personaje
        private int health;
        private int maxHealth = 100;
        // Velocidad de movimiento del personaje
        public float speed = 5f;

        //Velocidad maxima de movimiento
        private float maxSpeed = 5f;

        private Rigidbody rb;

        private void Awake() {
            health = maxHealth;
        }

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            health = maxHealth;
        }

        private void Update()
        {
            Debug.Log(health);
            if (health <= 0)
            {
                health = 0;
                SceneManager.LoadScene("LooseScene");
            }
            else
            {
                // Movimiento horizontal
                float moveHorizontal = Input.GetAxisRaw("Horizontal");
                //Movimoiento vertical
                float moveVertical = Input.GetAxisRaw("Vertical");
                Vector3 moveDirection = new Vector3(moveHorizontal, 0f, moveVertical);


                if (rb.velocity.magnitude < maxSpeed)
                {
                    rb.velocity = new Vector3(moveDirection.x * speed, rb.velocity.y, moveDirection.z * speed);
                }
            }
        }

        public void TakeDamage(int damageAmount)
        {
            if (health > 0)
            {
                health -= damageAmount;
            }
        }
    }
}
