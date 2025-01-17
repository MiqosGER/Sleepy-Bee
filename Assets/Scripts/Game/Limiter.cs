using UnityEngine;
using UnityEngine.SceneManagement;

public class Limiter : MonoBehaviour
{
    // Methode, die aufgerufen wird, wenn eine Kollision mit einem anderen Collider stattfindet
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Prueft, ob das kollidierende Objekt den Tag "Player" hat
        if (collision.gameObject.CompareTag("Player"))
        {
            // Lade die aktuelle Szene neu
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        // Prueft, ob das kollidierende Objekt den Layer "Borders" hat
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Borders"))
        {
            // Ignoriere die Kollision mit dem Rigidbody
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
    }
}
