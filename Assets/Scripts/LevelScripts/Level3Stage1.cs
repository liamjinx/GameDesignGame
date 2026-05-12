using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3Stage1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameObject ghost1;
    private GameObject ghost2;
    private static bool hasShownStartExplanation;

    [SerializeField] private GameObject noteButton;
    [SerializeField] private GameObject ghostCount;
    [SerializeField] private GameObject petrifyButton;
    [SerializeField] private GameObject timer;
    [SerializeField] private GameObject timerExplaination;
    [SerializeField] private GameObject menuReturn;
    [SerializeField] private TimerManager timerManager;
    private AudioSource popUpAudio;
    private AudioSource clickAudio;



    private CharacterManager characterManager;
    private int max;
    private int lastIndex;
    

    void Awake()
    {
       characterManager = GetComponent<CharacterManager>();
        max = transform.childCount;
        lastIndex = max - 1;
        int ghostnumber1 = Random.Range(0, max);
        int ghostnumber2 = Random.Range(0, max);
        while (ghostnumber1 == ghostnumber2)
        {
            ghostnumber2 = Random.Range(0, max);
        }
        ghost1 = transform.GetChild(ghostnumber1).gameObject;
        ghost2 = transform.GetChild(ghostnumber2).gameObject;
        ghost1.tag = "Ghost";
        ghost2.tag = "Ghost";
        ActivateWraith();
        for (int i = 0; i < max; ++i)
        {
            GameObject character = transform.GetChild(i).gameObject;
            if (character.CompareTag("Ghost")) { characterManager.ghosts.Add(character); }
            else { characterManager.subjects.Add(character); }
            if (character.CompareTag("Untagged")) { characterManager.honest.Add(character); }
            else if (character.CompareTag("Lying")) { characterManager.lying.Add(character); }
        }
        popUpAudio = GameObject.FindGameObjectWithTag("PopUpAudio").GetComponent<AudioSource>();
        clickAudio = GameObject.FindGameObjectWithTag("ClickAudio").GetComponent<AudioSource>();
    }

    private void ActivateWraith()
    {
        ghost1.layer = LayerMask.NameToLayer("Wraith");

        int affected = UnityEngine.Random.Range(0, max);
        GameObject affectedSubject = transform.GetChild(affected).gameObject;
        while (!affectedSubject.CompareTag("Untagged"))
        {
            affected = UnityEngine.Random.Range(0, max);
            affectedSubject = transform.GetChild(affected).gameObject;
        }
        affectedSubject.tag = "Lying";
    }

    private bool isLoading = false;
    public void PlayAgain()
    {
        if (isLoading) return; // prevents double click

        isLoading = true;

        Debug.Log("PlayAgain clicked");

        CharacterDialogue cd = FindAnyObjectByType<CharacterDialogue>();

        if (cd != null && cd.IsGameOver())
        {
            cd.ResetLives();
            SceneManager.LoadScene(9); // back to stage 1
        }
        else
        {
            SceneManager.LoadScene(9); // retry stage 1
        }
    }

    public void LoadMenu()
    {
        CharacterDialogue cd = FindAnyObjectByType<CharacterDialogue>();

        if (cd != null)
        {
            cd.ResetLives();
        }
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
    void Start()
    {
        if (!hasShownStartExplanation)
        {
            ShowExplanation();
            hasShownStartExplanation = true;
        } else {
            HideExplanation();
        }
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(10, LoadSceneMode.Single);
    }
    public void ShowExplanation()
    {
        noteButton.SetActive(false);
        ghostCount.SetActive(false);
        petrifyButton.SetActive(false);
        timer.SetActive(false);
        timerExplaination.SetActive(true);
        menuReturn.SetActive(false);
        popUpAudio.Play();
    }

    public void HideExplanation()
    {
        noteButton.SetActive(true);
        ghostCount.SetActive(true);
        petrifyButton.SetActive(true);
        timer.SetActive(true);
        timerExplaination.SetActive(false);
        menuReturn.SetActive(true);
               // Debug.Log("ClickAudio played from: " + Environment.StackTrace);

        clickAudio.Play();
        if (timerManager != null)
        {
            timerManager.StartTimer();
        }
    }

        public void ToggleExplanation()
    {
        noteButton.SetActive(!noteButton.activeSelf);
        ghostCount.SetActive(!ghostCount.activeSelf);
        petrifyButton.SetActive(!petrifyButton.activeSelf);
       // timer.SetActive(!timer.activeSelf);
        timerExplaination.SetActive(!timerExplaination.activeSelf);
        menuReturn.SetActive(!menuReturn.activeSelf);
              //  Debug.Log("ClickAudio played from: " + Environment.StackTrace);

        clickAudio.Play();
    }
}
