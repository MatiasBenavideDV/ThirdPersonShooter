using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public GameObject[] weapons;
    private int currentWeaponIndex = 0;

    private void Start()
    {
        // Desactivar todas las armas excepto la primera
        for (int i = 1; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
        }
    }

    private void Update()
    {
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
        foreach (GameObject weapon in weapons)
        {
            weapon.SetActive(false);
        }

        // Activar el arma seleccionada
        weapons[weaponIndex].SetActive(true);

        // Actualizar el índice de arma actual
        currentWeaponIndex = weaponIndex;
    }
}

