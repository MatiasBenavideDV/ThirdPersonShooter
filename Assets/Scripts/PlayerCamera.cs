using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class PlayerCamera : MonoBehaviour
    {
        public float sensX;
        public float sensY;
        [SerializeField] private Transform orientation;

        private float xRotation;
        private float yRotation;
        // Start is called before the first frame update
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        // Update is called once per frame
        void Update()
        {
            RotatePlayer();
        }

        private void RotatePlayer()
        {
            // Rotaci�n horizontal para apuntar con la c�mara
            float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensX;
            // Rotaci�n vertical para apuntar con la c�mara
            float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sensY;

            yRotation += mouseX;
            xRotation -= mouseY;

            xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);

            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
            orientation.rotation = Quaternion.Euler(0f, yRotation, 0f);
        }
    }
}
