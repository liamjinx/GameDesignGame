using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Level1Stage3 : MonoBehaviour
{
    private GameObject ghost1;
    private GameObject ghost2;

    private CharacterManager characterManager;
    private int max;

    void Awake()
    {
        characterManager = GetComponent<CharacterManager>();

        max = transform.childCount - 1;

        int ghostnumber1 = Random.Range(0, max + 1);
        int ghostnumber2 = Random.Range(0, max + 1);

        while (ghostnumber1 == ghostnumber2)
        {
            ghostnumber2 = Random.Range(0, max + 1);
        }

        ghost1 = transform.GetChild(ghostnumber1).gameObject;
        ghost2 = transform.GetChild(ghostnumber2).gameObject;

        ghost1.tag = "Ghost";
        ghost2.tag = "Ghost";

        for (int i = 0; i <= max; ++i)
        {
            GameObject character = transform.GetChild(i).gameObject;

            if (character.tag == "Ghost")
            {
                characterManager.ghosts.Add(character);
            }
            else
            {
                characterManager.subjects.Add(character);
            }

            if (character.tag == "Untagged")
            {
                characterManager.honest.Add(character);
            }
            else if (character.tag == "Lying")
            {
                characterManager.lying.Add(character);
            }
        }
    }

    public void PlayAgain()
    {
        CharacterDialogue cd = FindAnyObjectByType<CharacterDialogue>();

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