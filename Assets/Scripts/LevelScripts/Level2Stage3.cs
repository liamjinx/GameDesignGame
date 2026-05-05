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
    private int max;
    void Awake()
    {
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
        ActivatePhantom();
        for (int i = 0; i <= max; ++i)
        {
            GameObject character = transform.GetChild(i).gameObject;
            if (character.tag == "Ghost") { ghosts.Add(character); }
            else { subjects.Add(character); }
            if (character.tag == "Untagged") { honest.Add(character); }
            else if (character.tag == "Lying") { lying.Add(character); }
        }
    }
    private void ActivatePhantom()
    {
        int currentPos = ghost1.transform.GetSiblingIndex();
        int beforePos; int afterPos;
        if (currentPos == 0) { beforePos = max; afterPos = currentPos + 1; }
        else if (currentPos == max) { beforePos = currentPos - 1; afterPos = 0; }
        else { beforePos = currentPos - 1; afterPos = currentPos + 1; }
        if (transform.GetChild(beforePos).gameObject.tag == "Untagged")
        {
            transform.GetChild(beforePos).gameObject.tag = "Lying";
        }
        else if (transform.GetChild(afterPos).gameObject.tag == "Untagged")
        {
            transform.GetChild(afterPos).gameObject.tag = "Lying";
        }
    }
    private void ActivateWraith()
    {
        int affected = Random.Range(0, max);
        GameObject affectedSubject = transform.GetChild(affected).gameObject;
        while (affectedSubject.tag != "Untagged")
        {
            affected = Random.Range(0, max);
            affectedSubject = transform.GetChild(affected).gameObject;
        }
        affectedSubject.tag = "Lying";
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
