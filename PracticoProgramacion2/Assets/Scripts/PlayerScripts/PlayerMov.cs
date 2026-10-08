using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public AudioSource sfxSource;
    public AudioClip sonidoSalto;
    public float Velocidad = 5f;
    public float FuerzaSalto = 10f;
    public float LongitudRaycast = 0.1f;
    public LayerMask CapaSuelo;
    private bool Ensuelo;
    private Rigidbody2D rb;
    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float VelocidadX = Input.GetAxis("Horizontal") * Time.deltaTime * Velocidad;
        animator.SetFloat("Movement", VelocidadX * Velocidad);

        if (VelocidadX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (VelocidadX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        Vector3 posicion = transform.position;


        transform.position = new Vector3(VelocidadX + posicion.x, posicion.y, posicion.z);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, LongitudRaycast, CapaSuelo);
        Ensuelo = hit.collider != null;

        if (Ensuelo && Input.GetKeyDown(KeyCode.Space))
        {
            sfxSource.PlayOneShot(sonidoSalto);
            rb.AddForce(new Vector2(0f, FuerzaSalto), ForceMode2D.Impulse);
        }

        animator.SetBool("Ensuelo", Ensuelo);

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * LongitudRaycast);
    }


}
