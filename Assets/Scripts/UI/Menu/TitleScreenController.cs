using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour
{
    public int sceneIndex; // Der Name der Szene, zu der gewechselt werden soll.

    void Update()
    {
        // Prueft, ob eine Taste gedrueckt wurde, um die Szene zu wechseln.
        if (Input.anyKeyDown)
        {
            // Wechseln zur angegebenen Szene.
            SceneManager.LoadSceneAsync(sceneIndex);
        }
    }
}
