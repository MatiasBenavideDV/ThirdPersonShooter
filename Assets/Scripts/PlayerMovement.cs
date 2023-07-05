using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Movement")]
        private float moveSpeed = 6f;
        public float groundDrag;
        [Header("Ground Check")]
        private float playerHeight;
        public LayerMask whatIsGround;
        private bool isOnGround;
        [SerializeField] private Transform orientation;

        private float horizontalInput;
        private float verticalInput;

        private Vector3 moveDirection;

        private Rigidbody rb;

        private void Start() {
            rb = GetComponent<Rigidbody>();
        }

        private void Update() {
            isOnGround = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
            GatherInput();
            SpeedControl();

            if (isOnGround) rb.drag = groundDrag;
            else rb.drag = 0;
        }

        private void FixedUpdate() {
            MovePlayer();
        }

        private void GatherInput()
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");
        }

        private void MovePlayer()
        {
            Vector3 forwardDir = orientation.forward * verticalInput;
            Vector3 rightDir = orientation.right * horizontalInput;

            moveDirection = forwardDir + rightDir;

            rb.AddForce(moveDirection.normalized * moveSpeed * 10.0f, ForceMode.Force);
        }

        private void SpeedControl()
        {
            Vector3 flatVel = new Vector3(rb.velocity.x, 0, rb.velocity.z);

            if (flatVel.magnitude > moveSpeed)
            {
                Vector3 limitedVel = flatVel.normalized * moveSpeed;
                rb.velocity = new Vector3(limitedVel.x, 0, limitedVel.z);
            }
        }
    }
}
