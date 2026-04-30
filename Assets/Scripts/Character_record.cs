using UnityEngine;
using TMPro;

public class Character_record : MonoBehaviour
{
    public GameObject overlayPanel;
    public TextMeshProUGUI overlayText; 
    public CharacterDialogue[] characters;
   //public Sprite characterSprite;
    
    public void ToggleOverlay()
    {
        overlayPanel.SetActive(!overlayPanel.activeSelf);
    }

    void UpdateOverlay()
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
    }
}