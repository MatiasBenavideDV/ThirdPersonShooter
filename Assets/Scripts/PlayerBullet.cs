using UnityEngine;

namespace Scripts
{
    public class PlayerBullet : MonoBehaviour
    {
        public float speed = 10f;   // Velocidad de la bala
        public int damage = 10;     // Da�o infligido por la bala

        private Rigidbody rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            // Mover la bala hacia adelante
            rb.velocity = transform.forward * speed;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                // Acciones a realizar cuando la bala colisiona con un enemigo
                // Puedes implementar tu l�gica espec�fica aqu�, como reducir la salud del enemigo o activar alg�n efecto de impacto
            }

            // Destruir la bala despu�s de la colisi�n
            Destroy(gameObject);
        }

    }
}
