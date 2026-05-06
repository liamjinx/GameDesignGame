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
    void Awake()
    {
        int max = transform.childCount - 1;
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
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }
    

    public void ShowTimerExplanation()
    {
        noteButton.SetActive(false);
        ghostCount.SetActive(false);
        petrifyButton.SetActive(false);
        timer.SetActive(false);
        timerExplaination.SetActive(true);
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
