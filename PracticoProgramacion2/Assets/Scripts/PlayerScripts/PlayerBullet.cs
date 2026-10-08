using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private int damage = 10;
    [SerializeField] private float lifeTime = 3f;  // segundos antes de autodestruirse

    void Start()
    {
        // Red de seguridad: se destruye solo si no impacta nada antes
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // Aqu� delegamos el da�o al script de vida del enemigo
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Suelo"))
        {
            Destroy(gameObject);
        }
    }
}
