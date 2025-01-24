using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float upForce = 170f; // The upward force applied when the player clicks
    public float gravityScale = 2.8f; // The gravity applied to the bird
    public Rigidbody2D rb; // The Rigidbody2D component of the player

    private bool isDead = false; // A flag to check if the player is dead

    void Start()
    {
        // Gets the Rigidbody2D component if it hasn't been assigned yet
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }

        // Sets the gravity scale to the desired strength
        rb.gravityScale = gravityScale;
    }

    void Update()
    {
        // If the player is not "dead" and the player clicks, the bird moves upwards
        if (!isDead)
        {
            // Check if the player clicks or touches the screen
            if (Input.GetButtonDown("Jump"))
            {
                // Set the Rigidbody's current velocity in the Y-direction to zero to stop the bird
                rb.linearVelocity = Vector2.zero; // Reset the current velocity to stop the bird
                rb.AddForce(Vector2.up * upForce, ForceMode2D.Impulse); // Apply upward force to make the bird fly
            }
        }
    }

    // Function to mark the bird as "dead" (e.g., when colliding with obstacles)
    public void Die()
    {
        isDead = true;
        rb.linearVelocity = Vector2.zero; // Stop the bird's movement when it is dead
    }

    // Function to handle collision with 2D objects
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Webs"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
