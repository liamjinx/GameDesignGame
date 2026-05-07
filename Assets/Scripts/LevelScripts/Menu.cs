using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Menu : MonoBehaviour
{
    [SerializeField] private AudioSource ClickAudio;
    public void LoadTutorial()
    {
        StartCoroutine(PlayClickThenLoad(1));
        //SceneManager.LoadScene(1,LoadSceneMode.Single);
    }

    public void LoadLevel1()
    {
        StartCoroutine(PlayClickThenLoad(2));
        //SceneManager.LoadScene(2,LoadSceneMode.Single);
    }

    public void LoadLevel2()
    {
        StartCoroutine(PlayClickThenLoad(5));
        //SceneManager.LoadScene(5,LoadSceneMode.Single);
    }

    public void LoadLevel3()
    {
        StartCoroutine(PlayClickThenLoad(9));
        //SceneManager.LoadScene(9,LoadSceneMode.Single);
    }

    private IEnumerator PlayClickThenLoad(int sceneIndex)
    {
        ClickAudio.Play();
        yield return new WaitForSeconds(ClickAudio.clip.length);
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }
}