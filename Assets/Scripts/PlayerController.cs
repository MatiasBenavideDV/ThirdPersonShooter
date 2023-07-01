using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;             // Velocidad de movimiento del personaje

    private Camera mainCamera;
    private float screenWidth;
    private float screenHeight;

    private void Start()
    {
        mainCamera = Camera.main;
        screenWidth = Screen.width;
        screenHeight = Screen.height;

        Cursor.lockState = CursorLockMode.Locked;   // Oculta y bloquea el cursor
    }

    private void Update()
    {
        // Obtener la entrada del jugador
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calcular el vector de movimiento
        Vector3 moveDirection = new Vector3(moveHorizontal, 0f, moveVertical);
        moveDirection *= speed;

        // Aplicar el movimiento al jugador
        transform.Translate(moveDirection * Time.deltaTime);       

        
    }
}



