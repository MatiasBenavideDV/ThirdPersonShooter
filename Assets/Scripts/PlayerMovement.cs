using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{   
    public class PlayerMovement : MonoBehaviour
    {
        [Header ("References")]
        public Camera playerCamera;

        [Header ("General")]
        public float gravityScale = -20f;

        [Header("Movement")]
        public float walkSpeed = 6f;
        public float RunSpeed = 10f;

        [Header("Rotation")]
        public float rotationSensibility = 500f;

        [Header("Jump")]
        public float jumpHeight = 1.9f;

        private float cameraVerticalAngle = 0f;
        bool loockedCursor = true;

        Vector3 moveInput = Vector3.zero;
        Vector3 rotationInput = Vector3.zero;
        CharacterController characterController;

        private void Start()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            Move();
            Look();
        }

        private void Move()
        {
            if (characterController.isGrounded)
            {
                moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
                moveInput = Vector3.ClampMagnitude(moveInput, 1f);

                if (Input.GetButton("Sprint"))
                {
                    moveInput = transform.TransformDirection(moveInput) * RunSpeed;
                }
                else
                {
                    moveInput = transform.TransformDirection(moveInput) * walkSpeed;
                }

                if (Input.GetButtonDown("Jump"))
                {
                    moveInput.y = Mathf.Sqrt(jumpHeight * -2f * gravityScale);
                }
            }
            
            moveInput.y += gravityScale * Time.deltaTime;
            characterController.Move(moveInput * Time.deltaTime);
        }

        private void Look()
        {
            rotationInput.x = Input.GetAxis("Mouse X") * rotationSensibility * Time.deltaTime;
            rotationInput.y = Input.GetAxis("Mouse Y") * rotationSensibility * Time.deltaTime;

            cameraVerticalAngle += rotationInput.y;
            cameraVerticalAngle = Mathf.Clamp(cameraVerticalAngle, -70, 70);

            transform.Rotate(Vector3.up * rotationInput.x);
            playerCamera.transform.localRotation = Quaternion.Euler(-cameraVerticalAngle, 0f, 0f);
        }
    }
}
