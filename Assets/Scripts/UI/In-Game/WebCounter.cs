using TMPro;
using UnityEngine;

public class TriggerIncrement : MonoBehaviour
{
    public TMP_Text tmpText; // TMP Text that will be updated
    private int counter = 0; // The counter to increment
    private bool hasEntered = false; // Prevent multiple triggers

    void Start()
    {
        tmpText.text = counter.ToString(); // Initialize the TMP text                                    
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Enter");
        // Check if the object entering the trigger is the player
        if (other.CompareTag("Player") && !hasEntered)
        {
            hasEntered = true; // Set the flag to true to prevent multiple increments
            Debug.Log("Counter: " + counter);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Exit");
        // Reset the flag when the player exits the trigger area
        if (other.CompareTag("Player") && hasEntered)
        {
            hasEntered = false;
            counter++; // Increment the counter
            tmpText.text = counter.ToString(); // Update the TMP text
            Debug.Log("Counter: " + counter);
        }
    }
}
