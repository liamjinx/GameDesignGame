using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PetrifyManager : MonoBehaviour
{
    [SerializeField] private AudioSource clickAudio;
    [SerializeField] private AudioSource petrifyAudio;
    [SerializeField] private AudioSource mainAudio;
    public bool isActive = false;
    private GameObject petrifyButton;
    void Start()
    {
        petrifyButton = GameObject.FindGameObjectWithTag("Petrify");
    }
    public void ButtonSelect()
    {
        if (!isActive) { ActivatePetrify(); }
        else { DeactivatePetrify(); }
    }

    void ActivatePetrify()
    {  
        StartCoroutine(FadeToPetrify());
        isActive = true;
        petrifyButton.GetComponent<Image>().color = Color.red;
    }

    void DeactivatePetrify()
    {
        StartCoroutine(FadeToNormal());
        isActive = false;
        petrifyButton.GetComponent<Image>().color = Color.white;
    }

    private IEnumerator FadeToPetrify()
    {
        clickAudio.Play();

        petrifyAudio.volume = 0; 
        petrifyAudio.Play();

        float elapsed = 0f;
        float duration = 1f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float time = elapsed / duration;

            mainAudio.volume = 1f - time; 
            petrifyAudio.volume = time;

            yield return null;
        }
        
    }

    private IEnumerator FadeToNormal()
    {
        clickAudio.Play();

        mainAudio.volume = 0; 
        mainAudio.Play();

        float elapsed = 0f;
        float duration = 1f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float time = elapsed / duration;

            petrifyAudio.volume = 1f - time; 
            mainAudio.volume = time;

            yield return null;
        }
        
    }
}
