using UnityEngine;
using UnityEngine.SceneManagement;

public class LooseManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Überprüfe, ob das kollidierte Objekt den Tag "Player" hat
        if (collision.gameObject.CompareTag("Player"))
        {
            // Überprüfe, ob das aktuelle Objekt den Tag "Borders" oder "Webs" hat
            if (CompareTag("Borders") || CompareTag("Webs"))
            {
                // Szene wechseln: Lade die nächste Szene
                LoadNextScene();
            }
        }
    }

    private void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        // Prüfe, ob die nächste Szene existiert
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex, LoadSceneMode.Single);
        }
        else
        {
            Debug.LogWarning("Keine weitere Szene im Build-Index vorhanden!");
        }
    }
}
