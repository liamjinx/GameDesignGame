using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Stage1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameObject ghost1;
    private GameObject ghost2;
    public GameObject[] characters;
    public GameObject[] subjects;
    public GameObject[] ghosts;
    public GameObject[] honest;
    public GameObject[] lying;
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
        for (int i = 0; i < max; ++i)
        {
            Debug.Log(transform.GetChild(i));
            string tag = transform.GetChild(i).tag; ;
            if (tag == "Untagged") { }
        }
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
