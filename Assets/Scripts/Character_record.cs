using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Character_record : MonoBehaviour
{
    public GameObject overlayPanel;
    [SerializeField] private GameObject charactermanager;
    [SerializeField] private Button petrifyButton;
    [SerializeField] private GameObject dialoguept1;
    [SerializeField] private GameObject dialoguept2;
    [SerializeField] private GameObject characterpt1;
    [SerializeField] private GameObject characterpt2;
    [SerializeField] private AudioSource clickAudio;
    [SerializeField] private AudioSource PopUpAudio;
    //public TextMeshProUGUI overlayText; 
    //public CharacterDialogue[] characters;
    //public Sprite characterSprite;

    public void ToggleOverlay()
    {
        if (overlayPanel.activeSelf)
        {
            clickAudio.Play();
        }
        else
        {
            PopUpAudio.Play();
        }
        overlayPanel.SetActive(!overlayPanel.activeSelf);
        
        if (charactermanager.GetComponent<PetrifyManager>().isActive)
        {
            charactermanager.GetComponent<PetrifyManager>().isActive = false;
            petrifyButton.GetComponent<Image>().color = Color.white;
        }
    }
    public void ChangeDescription()
    {
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