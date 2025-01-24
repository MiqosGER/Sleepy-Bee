using UnityEngine;

public class WebCounter : MonoBehaviour
{
    [SerializeField] private int currentScore = 0;  // Current score (counted during play)
    [SerializeField] private int highScore = 0;     // Highest score, will be saved in PlayerPrefs or a prefab

    // Reference to the UI text or any other object to display the score
    [SerializeField] private TMPro.TextMeshProUGUI scoreText;
    [SerializeField] private TMPro.TextMeshProUGUI highScoreText;

    // Called when the player enters the collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider is the Player
        if (other.CompareTag("WebCounter"))
        {
            Debug.Log("Player entered the collider.");

            // Increment the current score
            currentScore++;
            Debug.Log("Current Score incremented: " + currentScore);

            // Update the UI display for the current score
            UpdateScoreUI();

            // Check if the current score is higher than the stored high score
            if (currentScore > highScore)
            {
                // Save the new high score
                SaveHighScore();
                highScore = currentScore;
                UpdateScoreUI();
                Debug.Log("New High Score: " + highScore);
            }
        }
    }

    private void Start()
    {
        Debug.Log("ScoreCounter Start method called.");
        // Load the high score from PlayerPrefs (or prefab if applicable)
        LoadHighScore();
        Debug.Log("High Score loaded: " + highScore);
        // Initialize the UI text
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        // Assuming you have a TextMeshPro object for score display
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore.ToString();
            Debug.Log("Score UI updated: " + currentScore);
        }

        if (highScoreText != null)
        {
            highScoreText.text = "High Score: " + highScore.ToString();
            Debug.Log("High Score UI updated: " + highScore);
        }
    }

    // Save the high score using PlayerPrefs (could also be a prefab save method)
    public void SaveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.Save();
        Debug.Log("High Score saved: " + highScore);
    }

    // Load the high score from PlayerPrefs
    private void LoadHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0); // Default to 0 if no high score exists
        Debug.Log("High Score loaded from PlayerPrefs: " + highScore);
    }
}
