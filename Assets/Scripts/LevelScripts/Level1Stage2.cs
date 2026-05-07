using UnityEngine;
using UnityEngine.SceneManagement;


public class Level1Stage2 : MonoBehaviour
{
    private GameObject ghost1;

    void Awake()
    {
        int max = transform.childCount;
        int ghostnumber1 = Random.Range(0, max);

        ghost1 = transform.GetChild(ghostnumber1).gameObject;
        ghost1.tag = "Ghost";
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
            SceneManager.LoadScene(3); // retry stage 2
        }
    }
    
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(4, LoadSceneMode.Single);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }
    
    public void LoadMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}