using UnityEngine;
using UnityEngine.SceneManagement;


public class Level1Stage2 : MonoBehaviour
{
    private GameObject ghost1;
    private CharacterManager characterManager;
    void Awake()
    {
        characterManager = GetComponent<CharacterManager>();
        int max = transform.childCount;
        int ghostnumber1 = Random.Range(0, max);

        ghost1 = transform.GetChild(ghostnumber1).gameObject;
        ghost1.tag = "Ghost";
        for (int i = 0; i < max; ++i)
        {
            GameObject character = transform.GetChild(i).gameObject;
            if (character.CompareTag("Ghost")) { characterManager.ghosts.Add(character); }
            else { characterManager.subjects.Add(character); }
            if (character.CompareTag("Untagged")) { characterManager.honest.Add(character); }
            else if (character.CompareTag("Lying")) { characterManager.lying.Add(character); }
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
        CharacterDialogue cd = FindAnyObjectByType<CharacterDialogue>();

        if (cd != null)
        {
            cd.ResetLives();
        }
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}