using TMPro;
using UnityEngine;

public class TimeUpdater : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshProUi;  // Das TMP-Textfeld, das den Timer anzeigen wird
    private float countdown;  // Der Timer in Sekunden

    private static TimeUpdater instance;  // Singleton-Instanz für den Zugriff auf den Timer

    public static TimeUpdater Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            // Optional: Wenn du willst, dass das Objekt zwischen Szenen erhalten bleibt, verwende Don'tDestroyOnLoad
            // DontDestroyOnLoad(this.gameObject); 
        }
    }

    void Update()
    {
        // Inkrementiere den Timer jede Sekunde
        countdown += Time.deltaTime;

        // Zeige den gerundeten Timerwert im TextMeshPro an
        textMeshProUi.text = Mathf.Round(countdown).ToString();
    }
}
