using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Stage2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameObject ghost1;
    private GameObject ghost2;
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

    public void PlayAgain()
    {
        CharacterDialogue cd = FindObjectOfType<CharacterDialogue>();

        if (cd != null && cd.IsGameOver())
        {
            cd.ResetLives();
            SceneManager.LoadScene(5); // back to stage 1
        }
        else
        {
            SceneManager.LoadScene(6); // retry stage 2
        }
    }
    
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(7, LoadSceneMode.Single);
    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(6, LoadSceneMode.Single);
    }
}
