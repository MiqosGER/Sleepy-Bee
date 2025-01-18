using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Prüft, ob das Objekt, das den Trigger betritt, den Tag "Player" hat
        if (collision.CompareTag("Player"))
        {
            // Wechselt zur nächsten Szene
            LoadNextScene();
        }
    }

    private void LoadNextScene()
    {
        // Holt den aktuellen Szenenindex
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Berechnet den nächsten Szenenindex
        int nextSceneIndex = currentSceneIndex + 1;

        // Prüft, ob eine weitere Szene im Build vorhanden ist
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogWarning("Keine weitere Szene im Build-Index vorhanden!");
        }
    }
}
