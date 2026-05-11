using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Stage1 : MonoBehaviour
{
    private GameObject ghost1;
    private static bool hasShownExplanation;

    [SerializeField] private GameObject explanation;

    void Awake()
    {
        int max = transform.childCount;
        int ghostnumber1 = Random.Range(0, max);

        ghost1 = transform.GetChild(ghostnumber1).gameObject;
        ghost1.tag = "Ghost";
    }

    private bool isLoading = false;
    
    void Start()
    {
        if (!hasShownExplanation)
        {
            explanation.SetActive(true);
            hasShownExplanation = true;
        }
    }

    public void CloseExplanation()
    {
        explanation.SetActive(false);
    }
    
    public void PlayAgain()
    {
        if (isLoading) return; // prevents double click

        isLoading = true;

        Debug.Log("PlayAgain clicked");
        
        CharacterDialogue cd = FindAnyObjectByType<CharacterDialogue>();

        if (cd != null && cd.IsGameOver())
        {
            cd.ResetLives();
            SceneManager.LoadScene(2); // back to stage 1
        }
        else
        {
            SceneManager.LoadScene(2); // retry stage 1
        }
    }
    
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
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
}