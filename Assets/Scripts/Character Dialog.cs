using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CharacterDialogue : MonoBehaviour
{
    [TextArea]
    public string dialogue;

    [SerializeField] private TextMeshProUGUI dialogueText;

    public static CharacterDialogue selectedCharacter;
    public void Start()
    {
        
    }

    public void Update()
    {
        
    }

    public void OnMouseUpAsButton()
    {
        Speak();
    }
    public void Speak()
    {
        dialogueText.text = dialogue;
        selectedCharacter = this;
    }
}