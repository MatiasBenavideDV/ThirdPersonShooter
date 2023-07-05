using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class Camera : MonoBehaviour
    {
        [SerializeField] private Transform cameraPosition;
        void Update()
        {
            transform.position = cameraPosition.position;
        }
    }
}
