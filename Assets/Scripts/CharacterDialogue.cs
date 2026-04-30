using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class CharacterDialogue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText;
    TextMeshProUGUI mainText;
    private PetrifyManager petrifyManager;
    private Canvas UICanvas;
    private Canvas lostStage;
    private Canvas beatStage;
    private CharacterManager ghostCount;
    
    public string lastSpokenLine = "";
    public string characterName;
    
    public void Start()
    {
        
        petrifyManager = GetComponentInParent<PetrifyManager>();
        UICanvas = GameObject.FindGameObjectWithTag("UICanvas").GetComponent<Canvas>();
        lostStage = GameObject.FindGameObjectWithTag("LostStage").GetComponent<Canvas>();
        beatStage = GameObject.FindGameObjectWithTag("BeatStage").GetComponent<Canvas>();
        ghostCount = GetComponentInParent<CharacterManager>();
        mainText = UICanvas.GetComponentInChildren<TextMeshProUGUI>();
        
    }
    public void Petrify()
    {
        if (petrifyManager.isActive)
        {
            if (gameObject.tag == "Ghost")
            {
                mainText.text = "Congratulations!\n You found a ghost!";
                //GetComponentInParent<PetrifyAnimation>().playPetrifyAnimation();
                // placement
                var anim = GetComponentInParent<PetrifyAnimation>();
                if (anim != null)
                {
                    anim.playPetrifyAnimation();
                }
                // end placement
                
                --ghostCount.ghostCount;
                if (ghostCount.ghostCount <= 0)
                {
                    UICanvas.enabled = false;
                    beatStage.enabled = true;
                }
            }
            else
            {
                mainText.text = "Oh no!\n You petrified a subject!";

                var anim = GetComponentInParent<PetrifyAnimation>();
                if (anim != null)
                {
                    anim.playPetrifyAnimation();
                }
                
                // show popup
                UICanvas.enabled = false;
                lostStage.enabled = true;
            }
            //Destroy(gameObject);
            return;
        }
        transform.GetComponentInParent<CharacterManager>().selectedCharacter = gameObject;
    }
    public void Speak(string dialogue)
    {
        dialogueText.text = dialogue;
        
        lastSpokenLine = dialogue;
        characterName = gameObject.name;
    }
    
    
   
}