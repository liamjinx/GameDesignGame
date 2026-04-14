using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterDialogue : MonoBehaviour
{
    [TextArea]
    public string dialogue;

    public TextMeshProUGUI dialogueText;

    public static CharacterDialogue selectedCharacter;

    public void Speak()
    {
        dialogueText.text = dialogue;
        selectedCharacter = this;
    }
}