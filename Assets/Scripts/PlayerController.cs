using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{

    public class PlayerController : MonoBehaviour
    {
        //***** MOVEMENT *****//
        public float speed = 5f;             // Velocidad de movimiento del personaje
        public float maxSpeed = 5f;             // Velocidad de movimiento del personaje
        private Vector3 directionAxis;
        private Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void Start() {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            GatherInput();
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }

        private void FixedUpdate() {
            directionAxis.Normalize();
            bool hasInput = directionAxis.magnitude != 0;

            if (hasInput)
            {
                MovePlayer();
            }
        }

        private void GatherInput()
        {
            float horizontalAxis = Input.GetAxisRaw("Horizontal");
            float verticalAxis = Input.GetAxisRaw("Vertical");

            directionAxis = new Vector3(horizontalAxis, 0, verticalAxis);
        }

        private void MovePlayer()
        {
            if (rb.velocity.magnitude < maxSpeed)
            {
                rb.MovePosition(transform.position +  (transform.forward * directionAxis.magnitude) * speed * Time.deltaTime);
            }

        }

        private void Shoot()
        {

        }
    }
}
