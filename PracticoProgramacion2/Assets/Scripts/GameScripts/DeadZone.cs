using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadZone : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
     if (collision.gameObject.CompareTag("Player") == true)
        { 
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
