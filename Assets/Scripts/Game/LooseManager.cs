using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LooseManager : MonoBehaviour
{
    private bool isTouchingStage = false;  // Ob der Spieler das Stage-Tag berührt
    private float touchTime = 0f;  // Zeit, wie lange der Spieler das Tag berührt

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Player"))
    //     {
    //         if (!isTouchingStage)
    //         {
    //             // Startet die Coroutine, wenn der Spieler das Stage-Tag berührt
    //             StartCoroutine(TouchTimer());
    //         }
    //     }
    // }
    

    // private void OnCollisionExit2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Player"))
    //     {
    //         // Stoppt die Coroutine und setzt die Zeit zurück, wenn der Spieler das Stage-Tag verlässt
    //         StopCoroutine(TouchTimer());
    //         touchTime = 0f;
    //         isTouchingStage = false;
    //         Debug.Log("Not touching stage");
    //     }
    // }


    private void OnCollisionExit2D(Collision2D collision)
    {
                if (collision.gameObject.CompareTag("Player"))
        {
        touchTime = 0f;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           touchTime += Time.deltaTime;
            if (touchTime >= 1f)
            {
                SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
                // Ruft die Methode zum Laden der nächsten Szene auf
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
            }

        }
    }

    private IEnumerator TouchTimer()
    {
        isTouchingStage = true;
Debug.Log("coroutine started");
        // Solange der Spieler das Tag berührt, erhöhe die Zeit
        while (isTouchingStage)
        {
            touchTime += Time.deltaTime;
            if (touchTime >= 1f)
            {
                SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
                // Ruft die Methode zum Laden der nächsten Szene auf
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
                yield break; // Beendet die Coroutine nach dem Laden der nächsten Szene
            }

            yield return null; // Wartet bis zum nächsten Frame
        }
    }
}