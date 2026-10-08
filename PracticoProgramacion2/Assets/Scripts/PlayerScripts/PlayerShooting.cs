using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float bulletSpeed = 12f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) Shoot();
    }

    private void Shoot()
    {
        // 1. Instanciamos una copia del Prefab en firePoint
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // 2. Le asignamos velocidad (ver siguiente diapositiva)
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        float dir = transform.localScale.x >= 0 ? 1f : -1f;
        rb.linearVelocity = new Vector2(dir * bulletSpeed, 0f);
    }
}
