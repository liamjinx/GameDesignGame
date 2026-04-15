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