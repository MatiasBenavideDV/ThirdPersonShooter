using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public GameObject[] weaponPrefabs;          // Array de prefabs de armas
    private int currentWeaponIndex = 0;         // Índice del arma actualmente seleccionada

    private void Start()
    {
        // Desactivar todos los prefabs de armas al inicio, excepto el primero
        for (int i = 1; i < weaponPrefabs.Length; i++)
        {
            weaponPrefabs[i].SetActive(false);
        }
    }

    private void Update()
    {
        // Cambiar de arma con la rueda del mouse
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0f)
        {
            // Scroll hacia arriba, cambiar al siguiente arma
            SwitchToNextWeapon();
        }
        else if (scroll < 0f)
        {
            // Scroll hacia abajo, cambiar al arma anterior
            SwitchToPreviousWeapon();
        }
    }

    private void SwitchToNextWeapon()
    {
        // Desactivar el arma actualmente seleccionada
        weaponPrefabs[currentWeaponIndex].SetActive(false);

        // Incrementar el índice del arma
        currentWeaponIndex++;
        if (currentWeaponIndex >= weaponPrefabs.Length)
        {
            currentWeaponIndex = 0;
        }

        // Activar el nuevo arma seleccionada
        weaponPrefabs[currentWeaponIndex].SetActive(true);
    }

    private void SwitchToPreviousWeapon()
    {
        // Desactivar el arma actualmente seleccionada
        weaponPrefabs[currentWeaponIndex].SetActive(false);

        // Decrementar el índice del arma
        currentWeaponIndex--;
        if (currentWeaponIndex < 0)
        {
            currentWeaponIndex = weaponPrefabs.Length - 1;
        }

        // Activar el nuevo arma seleccionada
        weaponPrefabs[currentWeaponIndex].SetActive(true);
    }
}
