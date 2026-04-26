using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CharacterDialogue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText;
    private PetrifyManager petrifyManager;
    
    public string lastSpokenLine = "";
    public string characterName;
    
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
                gameObject.GetComponent<QueenManager>().PetrifyAnimation();
            }
            //Destroy(gameObject);
        }
    }
    public void Speak(string dialogue)
    {
        dialogueText.text = dialogue;
        
        lastSpokenLine = dialogue;
        characterName = gameObject.name;
        transform.GetComponentInParent<CharacterManager>().selectedCharacter = gameObject;
        Petrify();
    }
}