using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void LoadTutorial()
    {
        SceneManager.LoadScene(1,LoadSceneMode.Single);
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene(2,LoadSceneMode.Single);
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene(5,LoadSceneMode.Single);
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene(8,LoadSceneMode.Single);
    }
}