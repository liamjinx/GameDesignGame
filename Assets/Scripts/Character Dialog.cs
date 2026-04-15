using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CharacterDialogue : MonoBehaviour
{
    [TextArea] public string dialogue;
    [SerializeField] private TextMeshProUGUI dialogueText;
    public static CharacterDialogue selectedCharacter;
    [SerializeField] private PetrifyManager petrifyManager;
    public void Start()
    {
        petrifyManager = GetComponentInParent<PetrifyManager>();
    }
    public void Update()
    {
        //Debug.Log(petrifyManager.isActive);
    }
    public void OnMouseUpAsButton()
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
            return;
        }
        Speak();
    }
    public void Speak()
    {
        dialogueText.text = dialogue;
        selectedCharacter = this;
    }
}