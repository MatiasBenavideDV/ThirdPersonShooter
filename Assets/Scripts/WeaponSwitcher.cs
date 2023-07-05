using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public List<Weapon> weapons;        // Lista de armas disponibles
    public int currentWeaponIndex = 0;  // Índice de la arma actualmente seleccionada

    private void Update()
    {
        // Cambiar de arma con las teclas numéricas
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchWeapon(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchWeapon(1);
        }
        // Añadir más teclas numéricas según la cantidad de armas disponibles

        // Disparar con la tecla de espacio
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireCurrentWeapon();
        }
    }

    private void SwitchWeapon(int index)
    {
        // Desactivar todas las armas
        foreach (Weapon weapon in weapons)
        {
            weapon.gameObject.SetActive(false);
        }

        // Activar el arma seleccionada
        weapons[index].gameObject.SetActive(true);

        // Actualizar el índice de la arma actual
        currentWeaponIndex = index;
    }

    private void FireCurrentWeapon()
    {
        // Obtener el arma actualmente seleccionada
        Weapon currentWeapon = weapons[currentWeaponIndex];

        // Disparar desde el arma actual
        currentWeapon.Fire();
    }
}
