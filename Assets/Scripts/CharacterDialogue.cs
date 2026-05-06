using UnityEngine;
using UnityEngine.UI;
using TMPro;
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

    // Lives persist across scenes
    private static int lives = 3;

    private Image Life1;
    private Image Life2;
    private Image Life3;
    
    private static bool gameOver = false;
    private static bool shouldResetToStage1 = false;
    private bool isTutorial = false;

    public string lastSpokenLine = "";
    public string characterName;

    public void Start()
    {
        petrifyManager = GetComponentInParent<PetrifyManager>();
        ghostCount = GetComponentInParent<CharacterManager>();

        UICanvas = GameObject.FindGameObjectWithTag("UICanvas").GetComponent<Canvas>();
        lostStage = GameObject.FindGameObjectWithTag("LostStage").GetComponent<Canvas>();
        beatStage = GameObject.FindGameObjectWithTag("BeatStage").GetComponent<Canvas>();

        mainText = UICanvas.GetComponentInChildren<TextMeshProUGUI>();

        // 🔥 ALWAYS reassign hearts
        Life1 = GameObject.Find("Life1")?.GetComponent<Image>();
        Life2 = GameObject.Find("Life2")?.GetComponent<Image>();
        Life3 = GameObject.Find("Life3")?.GetComponent<Image>();
        
        int current = SceneManager.GetActiveScene().buildIndex;

        // Tutorial ignore
        if (current == 1)
        {
            isTutorial = true;
        }

        UpdateLivesUI();
    }

    public void Petrify()
    {
        if (petrifyManager.isActive)
        {
            if (gameObject.tag == "Ghost")
            {
                mainText.text = "Congratulations!\n You found a ghost!";

                var anim = GetComponentInParent<PetrifyAnimation>();
                if (anim != null)
                    anim.playPetrifyAnimation();

                ghostCount.ghostCount--;

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
                    anim.playPetrifyAnimation();

                LoseLife();

                if (UICanvas != null)
                    UICanvas.enabled = false;

                if (lostStage != null)
                    lostStage.enabled = true;
            }

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
        if (isTutorial)
        {
            Debug.Log("Tutorial: ignoring life loss");
            return;
        }

        lives--;

        if (lives < 0)
            lives = 0;

        Debug.Log("Lives now: " + lives);

        UpdateLivesUI();
    }
    
    private void UpdateLivesUI()
    {
        if (Life1 != null) Life1.enabled = (lives >= 1);
        if (Life2 != null) Life2.enabled = (lives >= 2);
        if (Life3 != null) Life3.enabled = (lives >= 3);
    }
    public bool IsGameOver()
    {
        return lives <= 0;
    }
    
    public void ResetLives()
    {
        lives = 3;
        UpdateLivesUI();
    }
}