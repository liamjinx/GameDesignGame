using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    private AudioSource mainAudio;
    private AudioSource petrifyAudio;
    private static AudioManager instance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
            instance = this;
            DontDestroyOnLoad(gameObject); 
        //mainAudio = GameObject.FindGameObjectWithTag("MainThemeAudio").GetComponent<AudioSource>();

    }

    void Awake()
    {
        mainAudio = GameObject.FindGameObjectWithTag("MainThemeAudio").GetComponent<AudioSource>();
        petrifyAudio = GameObject.FindGameObjectWithTag("PetrifyAudio").GetComponent<AudioSource>();

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += sceneloaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= sceneloaded;
    }

    void sceneloaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Menu")
        {
            mainAudio.Stop();
        } else if (!mainAudio.isPlaying)
        {
            mainAudio.Play();
        }

        if (scene.name == "Menu" && petrifyAudio.isPlaying)
        {
            petrifyAudio.Stop();
        }

    }
}
