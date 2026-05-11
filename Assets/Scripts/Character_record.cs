using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Character_record : MonoBehaviour
{
    public GameObject overlayPanel;
    private GameObject petrifyManager;
    [SerializeField] private Button petrifyButton;
    [SerializeField] private GameObject dialoguept1;
    [SerializeField] private GameObject dialoguept2;
    [SerializeField] private GameObject characterpt1;
    [SerializeField] private GameObject characterpt2;
    private AudioSource clickAudio;
    private AudioSource popUpAudio;
    //private AudioSource mainAudio;
    //public TextMeshProUGUI overlayText; 
    //public CharacterDialogue[] characters;
    //public Sprite characterSprite;
    public void Start()
    {
        clickAudio = GameObject.FindGameObjectWithTag("ClickAudio").GetComponent<AudioSource>();
        popUpAudio = GameObject.FindGameObjectWithTag("PopUpAudio").GetComponent<AudioSource>();
        //mainAudio = GameObject.FindGameObjectWithTag("MainThemeAudio").GetComponent<AudioSource>();
        petrifyManager = FindAnyObjectByType<PetrifyManager>().gameObject;
    }
    public void ToggleOverlay()
    {
        if (overlayPanel.activeSelf)
        {
        Debug.Log("ClickAudio played from: " + Environment.StackTrace);

           clickAudio.Play();
        }
        else
        {
            popUpAudio.Play();
        }
        overlayPanel.SetActive(!overlayPanel.activeSelf);
        
        if (petrifyManager.GetComponent<PetrifyManager>().isActive)
        {
            petrifyManager.GetComponent<PetrifyManager>().StartCoroutine(
            petrifyManager.GetComponent<PetrifyManager>().FadeToNormal());

            petrifyManager.GetComponent<PetrifyManager>().isActive = false;
            petrifyButton.GetComponent<Image>().color = Color.white;
        }
    }
    public void ChangeDescription()
    {
        Debug.Log("ClickAudio played from: " + Environment.StackTrace);

        clickAudio.Play();
        dialoguept1.SetActive(!dialoguept1.activeSelf);
        dialoguept2.SetActive(!dialoguept2.activeSelf);
        characterpt1.SetActive(!characterpt1.activeSelf);
        characterpt2.SetActive(!characterpt2.activeSelf);
    }

    /*void UpdateOverlay()
    {
        string fullText = "";

        foreach (CharacterDialogue character in characters)
        {
            if (!string.IsNullOrEmpty(character.lastSpokenLine))
            {
                fullText += character.name + ": " + character.lastSpokenLine + "\n\n";
            }
        }

        overlayText.text = fullText;
    }*/
}