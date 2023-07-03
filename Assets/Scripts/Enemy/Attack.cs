using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : MonoBehaviour
{
    protected ITargetable target;

    protected virtual void Start()
    {
        target = (ITargetable)FindObjectOfType<PlayerController>(); // Conversión explícita
    }

    protected virtual void Update()
    {
        if (target == null)
        {
            target = (ITargetable)FindObjectOfType<PlayerController>(); // Conversión explícita
        }
    }
}




