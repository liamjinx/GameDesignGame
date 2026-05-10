using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Menu : MonoBehaviour
{
    private AudioSource clickAudio;
    private void Start()
    {

        clickAudio = GameObject.FindGameObjectWithTag("ClickAudio").GetComponent<AudioSource>();
    }
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
        clickAudio.Play();
        yield return new WaitForSeconds(clickAudio.clip.length);
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }
    public void LoadMenu()
    {
        StartCoroutine(PlayClickThenLoad(0));
    }
    public void LoadNextLevel()
    {
        int sceneNo = SceneManager.GetActiveScene().buildIndex + 1;
        StartCoroutine(PlayClickThenLoad(sceneNo));
    }
    public void ReplayLevel()
    {

    }
    public void ReplayGame()
    {
        StartCoroutine(PlayClickThenLoad(2));
    }
}