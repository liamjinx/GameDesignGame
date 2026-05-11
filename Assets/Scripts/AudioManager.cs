using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    private AudioSource MainThemeAudio;
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
        MainThemeAudio = GetComponentInChildren<AudioSource>();
        petrifyAudio = GameObject.FindGameObjectWithTag("PetrifyAudio").GetComponent<AudioSource>();

    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log("MainThemeAudio isPlaying = " + MainThemeAudio.isPlaying);
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
        StopAllCoroutines();

        var petrifyObject = GameObject.FindGameObjectWithTag("PetrifyAudio");
        petrifyAudio = petrifyObject != null ? petrifyObject.GetComponent<AudioSource>() : null;

        if (petrifyAudio != null)
        {
            petrifyAudio.Stop();
        }

        if (MainThemeAudio == null)
        {
            return;
        }

        if (scene.buildIndex == 0)
        {
            StopMainThemeAudio();
            return;
        }

        StartCoroutine(StartMainThemeAfterLoad());
    }

    IEnumerator StartMainThemeAfterLoad()
    {
        yield return null;

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            yield break;
        }

        var petrifyManager = FindAnyObjectByType<PetrifyManager>();
        if (petrifyManager != null)
        {
            yield return StartCoroutine(petrifyManager.FadeToNormal());
            if (MainThemeAudio != null && MainThemeAudio.isPlaying)
            {
                yield break;
            }
        }

        if (MainThemeAudio == null)
        {
            yield break;
        }

        MainThemeAudio.Stop();
        MainThemeAudio.time = 0f;
        MainThemeAudio.mute = false;
        MainThemeAudio.volume = .5f;
        MainThemeAudio.Play();
    }

    void StopMainThemeAudio()
    {
        if (MainThemeAudio != null)
        {
            MainThemeAudio.Stop();
        }

        var taggedMainThemes = GameObject.FindGameObjectsWithTag("MainThemeAudio");
        foreach (var mainThemeObject in taggedMainThemes)
        {
            var audioSources = mainThemeObject.GetComponentsInChildren<AudioSource>(true);
            foreach (var audioSource in audioSources)
            {
                audioSource.Stop();
            }
        }

        var childSources = GetComponentsInChildren<AudioSource>(true);
        foreach (var audioSource in childSources)
        {
            audioSource.Stop();
        }
    }
}
