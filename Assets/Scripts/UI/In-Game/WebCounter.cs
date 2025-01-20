using TMPro;
using UnityEngine;

public class WebCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshProUi; // Das TMP-Textfeld für den Zähler
    private int counter = 0; // Der aktuelle Zählerstand

    private bool isPlayerInside = false; // Gibt an, ob der Spieler im Trigger ist

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Prüfe, ob das andere Objekt den Tag "Player" hat
        if (other.CompareTag("Player") && !isPlayerInside)
            Debug.Log("Player entered trigger"); // Gebe eine Meldung aus
        {
            counter++; // Erhöhe den Zähler
            UpdateCounterUI(); // Aktualisiere die Anzeige im TextMeshPro
            isPlayerInside = true; // Spieler ist jetzt im Trigger
            Debug.Log("Counter: " + counter); // Gebe den aktuellen Zählerstand aus
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Prüfe, ob der Spieler den Trigger verlässt
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false; // Spieler hat den Trigger verlassen
            Debug.Log("Player left trigger"); // Gebe eine Meldung aus
        }
    }

    private void UpdateCounterUI()
    {
        // Zeige den aktuellen Zählerwert im TextMeshPro an
        textMeshProUi.text = counter.ToString();
        Debug.Log("Updated counter UI"); // Gebe eine Meldung aus
    }
}
