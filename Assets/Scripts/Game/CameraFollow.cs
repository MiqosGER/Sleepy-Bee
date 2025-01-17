using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // Referenz zur Spielfigur
    public float smoothSpeed = 0.125f;  // Geschwindigkeit der Kamerabewegung
    public Vector3 offset;  // Abstand zwischen Kamera und Spielfigur

    void Start()
    {
        // Initialisiere die Kamera-Offset, wenn sie nicht manuell gesetzt wurde
        if (offset == Vector3.zero)
        {
            offset = new Vector3(3f, 1.5f, -10f);  // Beispiel für ein Standard-Offset (kann angepasst werden)
        }
    }

    void LateUpdate()
    {
        // Bestimme die Zielposition der Kamera (Spielfigur + Offset)
        Vector3 desiredPosition = player.position + offset;

        // Interpoliere zwischen der aktuellen Position der Kamera und der gewünschten Position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Setze die Kamera-Position auf die glättete Position
        transform.position = smoothedPosition;

        // Optional: Kamera immer auf die Spielfigur ausrichten (falls gewünscht)
        transform.LookAt(player);
    }
}
