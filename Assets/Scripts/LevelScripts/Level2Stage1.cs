using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;


public class Level2Stage1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameObject ghost1;
    private GameObject ghost2;
    private CharacterManager characterManager;
    private int max;
    void Awake()
    {
        characterManager = GetComponent<CharacterManager>();
        max = transform.childCount - 1;
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
        for (int i = 0; i <= max; ++i)
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
        ghost1.name = "Wraith";
        int affected = Random.Range(0, max);
        GameObject affectedSubject = transform.GetChild(affected).gameObject;
        while (affectedSubject.tag != "Untagged")
        {
            affected = Random.Range(0, max);
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
        
        CharacterDialogue cd = FindObjectOfType<CharacterDialogue>();

        if (cd != null && cd.IsGameOver())
        {
            cd.ResetLives();
            SceneManager.LoadScene(5); // back to stage 1
        }
        else
        {
            SceneManager.LoadScene(5); // retry stage 1
        }
    }
    
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(6, LoadSceneMode.Single); //load stage 2
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
