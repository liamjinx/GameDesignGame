using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CharacterDialogue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText;
    public static CharacterDialogue selectedCharacter;
    private PetrifyManager petrifyManager;
    public void Start()
    {
        petrifyManager = GetComponentInParent<PetrifyManager>();
    }
    public void Petrify()
    {
        if (petrifyManager.isActive)
        {
            if (gameObject.tag == "Ghost")
            {
                dialogueText.text = "Congratulations! You found a ghost!";
            }
            else
            {
                dialogueText.text = "Oh no! You petrified a subject!";
            }
            Destroy(gameObject);
        }
    }
    public void Speak(string dialogue)
    {
        Petrify();
        dialogueText.text = dialogue;
        selectedCharacter = this;
    }
}