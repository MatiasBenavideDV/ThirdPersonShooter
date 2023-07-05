using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts
{
    public class RespawnButton : MonoBehaviour
    {
        public void Respawn()
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
