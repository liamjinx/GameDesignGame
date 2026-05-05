using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Level2Stage3 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameObject ghost1;
    private GameObject ghost2;
    public List<GameObject> subjects = new List<GameObject>();
    public List<GameObject> ghosts = new List<GameObject>();
    public List<GameObject> honest = new List<GameObject>();
    public List<GameObject> lying = new List<GameObject>();
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
        for (int i = 0; i <= max; ++i)
        {
            GameObject character = transform.GetChild(i).gameObject;
            if (character.tag == "Ghost") { ghosts.Add(character); }
            else { subjects.Add(character); }
            if (character.tag == "Untagged") { honest.Add(character); }
            else if (character.tag == "Lying") { lying.Add(character); }
        }
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }
}
