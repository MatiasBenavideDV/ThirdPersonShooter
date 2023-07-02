using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : MonoBehaviour
{
    protected ITargetable target;

    protected virtual void Start()
    {
        target = FindObjectOfType<PlayerController>(); // Obtener el objetivo, puedes cambiarlo por tu lógica específica
    }

    protected virtual void Update()
    {
        if (target == null)
        {
            target = FindObjectOfType<PlayerController>(); // Actualizar el objetivo si se ha perdido, puedes cambiarlo por tu lógica específica
        }
    }
}



