using UnityEngine;
using TMPro;

public class RangeCounter : MonoBehaviour
{
    [Header("References")]
    public Transform player; // Der Spieler, dessen Y-Position überwacht wird
    public TMP_Text rangeText; // Das TextMeshPro-Textfeld zur Anzeige der Y-Position

    void Start()
    {
    // Setze den Text auf 0, wenn das Spiel startet
    rangeText.text = "0000";
    }

    void Update()
    {
        // Konvertiere die Y-Position des Spielers in einen Integer und zeige ihn im TMP-Text an
        if (player != null && rangeText != null)
        {
            int playerYPosition = Mathf.RoundToInt(player.position.y);
            rangeText.text = playerYPosition.ToString();
        }
    }
}
