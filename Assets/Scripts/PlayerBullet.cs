using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 10f;   // Velocidad de la bala
    public int damage = 10;     // Da�o infligido por la bala

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Acciones a realizar cuando la bala colisiona con un enemigo
            
        }

        // Destruir la bala despu�s de la colisi�n
        Destroy(gameObject);
    }
}
