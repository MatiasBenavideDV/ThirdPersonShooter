using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, ITargetable
{
    public float speed = 5f;             // Velocidad de movimiento del personaje

    private Camera mainCamera;
    private float screenWidth;
    private float screenHeight;
    private Weapon[] weapons;            // Arreglo de armas disponibles
    private int currentWeaponIndex;      // Índice de la arma actualmente equipada

    private void Start()
    {
        // Obtener todas las armas en el jugador
        weapons = GetComponentsInChildren<Weapon>();

        // Desactivar todas las armas excepto la primera
        for (int i = 1; i < weapons.Length; i++)
        {
            weapons[i].gameObject.SetActive(false);
        }

        currentWeaponIndex = 0;                     // Inicializa el índice de arma actual
        weapons[currentWeaponIndex].gameObject.SetActive(true);  // Activa la primera arma
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

        // Disparar el arma actual al hacer clic izquierdo
        if (Input.GetMouseButton(0))
        {
            weapons[currentWeaponIndex].Fire();
        }

        // Detectar el cambio de la rueda del mouse
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        if (scrollWheel > 0f)
        {
            // Desplazarse hacia adelante en el array de armas
            SelectWeapon(currentWeaponIndex + 1);
        }
        else if (scrollWheel < 0f)
        {
            // Desplazarse hacia atrás en el array de armas
            SelectWeapon(currentWeaponIndex - 1);
        }
    }

    private void SelectWeapon(int weaponIndex)
    {
        // Asegurarse de que el índice esté dentro del rango válido
        if (weaponIndex < 0)
        {
            weaponIndex = weapons.Length - 1;
        }
        else if (weaponIndex >= weapons.Length)
        {
            weaponIndex = 0;
        }

        // Desactivar todas las armas
        foreach (Weapon weapon in weapons)
        {
            weapon.gameObject.SetActive(false);
        }

        // Activar el arma seleccionada
        weapons[weaponIndex].gameObject.SetActive(true);

        // Actualizar el índice de arma actual
        currentWeaponIndex = weaponIndex;
    }

    public void TakeDamage(int amount)
    {
        // Implementa la lógica para recibir daño aquí
    }

    public Transform GetTargetPosition()
    {
        // Implementa la lógica para obtener la posición objetivo aquí
        return transform;
    }
}




