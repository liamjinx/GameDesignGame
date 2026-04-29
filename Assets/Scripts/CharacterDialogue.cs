using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CharacterDialogue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText;
    TextMeshProUGUI mainText;
    private PetrifyManager petrifyManager;
    private Canvas UICanvas;
    private Canvas lostStage;
    private Canvas beatStage;
    private CharacterManager ghostCount;
    
    
    // lives code 
    [SerializeField] private Sprite NoLife;

    private static Image Life1;
    private static Image Life2;
    private static Image Life3;

    private static int lives = 3;
    private static bool isSetup = false;
    
    [SerializeField] private Sprite FullLife;
   
    private static Sprite noLifeStatic;
    private static Sprite fullLifeStatic;
    
    //end of lives
    
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
        
        if (noLifeStatic == null && NoLife != null)
            noLifeStatic = NoLife;

        if (fullLifeStatic == null && FullLife != null)
            fullLifeStatic = FullLife;
        
        if (!isSetup)
        {
            Life1 = GameObject.Find("Life1")?.GetComponent<Image>();
            Life2 = GameObject.Find("Life2")?.GetComponent<Image>();
            Life3 = GameObject.Find("Life3")?.GetComponent<Image>();

            isSetup = true;

            Debug.Log("Hearts setup ONCE");
        }
        
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
                //GetComponentInParent<PetrifyAnimation>().playPetrifyAnimation();
                // placement
                var anim = GetComponentInParent<PetrifyAnimation>();

                if (anim != null)

                {

                    anim.playPetrifyAnimation();

                }
                // end placement
                LoseLife();
                
                if (lives <= 0)
                {
                    UICanvas.enabled = false;
                    lostStage.enabled = true;
                }
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

    private void LoseLife()
    {

        if (lives <= 0) return;

        lives--;

        Debug.Log("Lives now: " + lives);

        if (lives == 2 && Life3 != null)
            Life3.sprite = noLifeStatic;

        else if (lives == 1 && Life2 != null)
            Life2.sprite = noLifeStatic;

        else if (lives == 0 && Life1 != null)
            Life1.sprite = noLifeStatic;
    }
    
}