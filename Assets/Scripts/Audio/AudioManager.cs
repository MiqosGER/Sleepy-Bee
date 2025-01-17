using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Header("---------- Audio Sources ----------")]
    [SerializeField] AudioSource MusicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("---------- Audio Mixer ----------")]
    [SerializeField] AudioMixer AudioMixer;


    [Header("---------- BGM Music ----------")]
    public AudioClip UI;
    public AudioClip Game;
    public AudioClip Loose;

    // Singleton instance
    public static AudioManager instance;


    private void Awake()
    {
        // Ensures only one instance of AudioManager exists throughout the game.
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Starts playing music when the game starts.
        if (SceneManager.GetActiveScene().name == "MainUI")
            PlayMusic(UI);
        else if (SceneManager.GetActiveScene().name == "MainGame")
            PlayMusic(Game);
        else if (SceneManager.GetActiveScene().name == "MainLost")
            PlayMusic(Loose);
        
    }

    // Plays a sound effect once.
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    // Plays music.
    public void PlayMusic(AudioClip clip)
    {
        MusicSource.clip = clip;
        MusicSource.Play();
    }

    // Changes the current playing music to a new clip.
    public void ChangeMusic(AudioClip newClip)
    {
        MusicSource.Stop();
        MusicSource.clip = newClip;
        MusicSource.Play();
    }

    // Changes the output audio mixer group of a specific sound
    public void ChangeSoundMixerGroup(string soundName, string mixerGroupName)
    {
        GameObject soundObject = GameObject.Find(soundName);
        if (soundObject != null)
        {
            AudioSource audioSource = soundObject.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.outputAudioMixerGroup = AudioMixer.FindMatchingGroups(mixerGroupName)[0];
            }
            else
            {
                Debug.LogError("AudioSource not found for sound: " + soundName);
            }
        }
        else
        {
            Debug.LogError("Sound not found: " + soundName);
        }
    }
}
