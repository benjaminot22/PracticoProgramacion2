using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMov : MonoBehaviour
{
    private bool enMovimiento;
    private Animator animator;
    public float velocidad = 2f;

    // Empezamos movi�ndonos a la izquierda (-1). Para la derecha ser�a 1.
    private int direccion = -1;

    void Start()
    {
        animator = GetComponent<Animator>();
        enMovimiento = true;
        animator.SetBool("enMovimiento", enMovimiento);
    }

    void Update()
    {
        // Movemos al enemigo en el eje X constantemente
        transform.Translate(new Vector2(direccion * velocidad * Time.deltaTime, 0));
    }

    // Usamos las colisiones f�sicas para rebotar en paredes
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Si choca con algo y ese algo NO es el jugador...
        if (collision.gameObject.CompareTag("Player") == false)
        {
            // Invertimos la direcci�n (de -1 a 1, o de 1 a -1)
            direccion = direccion * -1;
            if (direccion < 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }

            if (direccion > 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }

            // Aqu� podr�an voltear el SpriteRenderer para que mire al otro lado
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


    }
}

