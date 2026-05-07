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
    [SerializeField] private AudioSource PopUpAudio;


    private CharacterManager characterManager;
    private int max;
    private int childCount;
    private int lastIndex;
    

    void Awake()
    {
       characterManager = GetComponent<CharacterManager>();
        childCount = transform.childCount;
        lastIndex = childCount - 1;
        max = transform.childCount;
        int ghostnumber1 = Random.Range(0, childCount);
        int ghostnumber2 = Random.Range(0, childCount);
        while (ghostnumber1 == ghostnumber2)
        {
            ghostnumber2 = Random.Range(0, childCount);
        }
        ghost1 = transform.GetChild(ghostnumber1).gameObject;
        ghost2 = transform.GetChild(ghostnumber2).gameObject;
        ghost1.tag = "Ghost";
        ghost2.tag = "Ghost";
        ActivateWraith();
        ActivateNuckelavee();
        for (int i = 0; i < childCount; ++i)
        {
            GameObject character = transform.GetChild(i).gameObject;
            if (character.tag == "Ghost") { characterManager.ghosts.Add(character); }
            else { characterManager.subjects.Add(character); }
            if (character.tag == "Untagged") { characterManager.honest.Add(character); }
            else if (character.tag == "Lying") { characterManager.lying.Add(character); }
        }
    }

     private void ActivateWraith()
    {
        int affected = Random.Range(0, childCount);
        GameObject affectedSubject = transform.GetChild(affected).gameObject;
        while (affectedSubject.tag != "Untagged")
        {
            affected = Random.Range(0, childCount);
            affectedSubject = transform.GetChild(affected).gameObject;
        }
        affectedSubject.tag = "Lying";
    }

    private void ActivateNuckelavee()
    {
        int currentPos = ghost1.transform.GetSiblingIndex();
        int beforePos; int afterPos;
        if (currentPos == 0) { beforePos = lastIndex; afterPos = currentPos + 1; }
        else if (currentPos == lastIndex) { beforePos = currentPos - 1; afterPos = 0; }
        else { beforePos = currentPos - 1; afterPos = currentPos + 1; }
        if (transform.GetChild(beforePos).gameObject.tag == "Untagged")
        {
            transform.GetChild(beforePos).gameObject.tag = "Lying";
        }
        if (transform.GetChild(afterPos).gameObject.tag == "Untagged")
        {
            transform.GetChild(afterPos).gameObject.tag = "Lying";
        }
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
            ShowTimerExplanation();
            hasShownStartExplanation = true;
        }
        else
        {
            HideTimerExplanation();
        }
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(10, LoadSceneMode.Single);
    }
    

    public void ShowTimerExplanation()
    {
        noteButton.SetActive(false);
        ghostCount.SetActive(false);
        petrifyButton.SetActive(false);
        timer.SetActive(false);
        timerExplaination.SetActive(true);
        PopUpAudio.Play();
    }
    public void HideTimerExplanation()
    {
        noteButton.SetActive(true);
        ghostCount.SetActive(true);
        petrifyButton.SetActive(true);
        timer.SetActive(true);
        timerExplaination.SetActive(false);
    }
}
