using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : MonoBehaviour
{
    protected ITargetable target;

    protected virtual void Start()
    {
        target = (ITargetable)FindObjectOfType<PlayerController>(); // Conversi�n expl�cita
    }

    protected virtual void Update()
    {
        if (target == null)
        {
            target = (ITargetable)FindObjectOfType<PlayerController>(); // Conversi�n expl�cita
        }
    }
}




