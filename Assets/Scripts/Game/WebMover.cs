using UnityEngine;

public class WebMover : MonoBehaviour
{
    private float moveSpeed; // Geschwindigkeit der Bewegung

    public void Initialize(float speed)
    {
        moveSpeed = speed;
    }

    void Update()
    {
        // Bewege das Objekt nach links
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        // Deaktiviere das Objekt, wenn es den Bildschirm verlässt
        if (transform.position.x < -20f) // Grenze festlegen
        {
            gameObject.SetActive(false);

            // Deaktiviere alle Child-Objekte
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
        }
    }
}
