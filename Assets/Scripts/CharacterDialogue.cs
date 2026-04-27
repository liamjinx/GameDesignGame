using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CharacterDialogue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText;
    private PetrifyManager petrifyManager;
    private Canvas UICanvas;
    private Canvas lostStage;
    private Canvas beatStage;
    private int remainingGhosts;

    
    public string lastSpokenLine = "";
    public string characterName;
    
    public void Start()
    {
        petrifyManager = GetComponentInParent<PetrifyManager>();
        UICanvas = GameObject.FindGameObjectWithTag("UICanvas").GetComponent<Canvas>();
        lostStage = GameObject.FindGameObjectWithTag("LostStage").GetComponent<Canvas>();
        beatStage = GameObject.FindGameObjectWithTag("BeatStage").GetComponent<Canvas>();
        remainingGhosts = GetComponentInParent<CharacterManager>().ghostCount;
    }
    public void Petrify()
    {
        if (petrifyManager.isActive)
        {
            if (gameObject.tag == "Ghost")
            {
                dialogueText.text = "Congratulations! You found a ghost!";
                //gameObject.GetComponent<QueenManager>().PetrifyAnimation();
                --remainingGhosts;
                if (remainingGhosts <= 0)
                {
                    UICanvas.enabled = false;
                    beatStage.enabled = true;
                }
            }
            else
            {
                dialogueText.text = "Oh no! You petrified a subject!";
                gameObject.GetComponent<NunManager>()?.PetrifyAnimation();
                gameObject.GetComponent<QueenManager>().PetrifyAnimation();
                UICanvas.enabled = false;
                lostStage.enabled = true;
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