using UnityEngine;
using UnityEngine.SceneManagement;


public class Level1Stage3 : MonoBehaviour
{
    private GameObject ghost1;
    private GameObject ghost2;

    void Awake()
    {
        int max = transform.childCount;

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

    private bool isLoading = false;
    public void PlayAgain()
    {
        if (isLoading) return; // prevents double click

        isLoading = true;

        Debug.Log("PlayAgain clicked");
        
        CharacterDialogue cd = FindObjectOfType<CharacterDialogue>();

        if (cd != null && cd.IsGameOver())
        {
            cd.ResetLives();
            SceneManager.LoadScene(2); // back to stage 1
        }
        else
        {
            SceneManager.LoadScene(4); // retry stage 3
        }
    }
    
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(5, LoadSceneMode.Single);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(4, LoadSceneMode.Single);
    }
}