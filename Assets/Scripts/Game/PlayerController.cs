using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float flapStrength = 5f;  // Stärke des Flugs (wie stark der Spieler nach oben fliegt)
    public float fallSpeed = 2f;  // Die Geschwindigkeit, mit der der Spieler fällt (optional)
    private Rigidbody2D rb;  // Referenz zum Rigidbody2D der Spielfigur

    void Start()
    {
        // Hole das Rigidbody2D-Komponenten der Spielfigur
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Wenn die Leertaste gedrückt wird, fliegt der Spieler nach oben
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Flap();
        }
        
        // Optional: Wenn der Spieler die Leertaste nicht drückt, fällt er mit einer bestimmten Geschwindigkeit
        // Hier könnte man auch Schwerkraft anpassen oder die Fallgeschwindigkeit direkt beeinflussen.
        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, -fallSpeed);  // Kontrolliert die Geschwindigkeit des Falls
        }
    }

    void Flap()
    {
        // Setzt die Geschwindigkeit des Spielers in Y-Richtung (nach oben)
        rb.linearVelocity = Vector2.up * flapStrength;
    }
}
