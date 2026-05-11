using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Unity.VisualScripting;
using System;

public class Menu : MonoBehaviour
{
    private AudioSource clickAudio;
    [SerializeField] private GameObject Levels;
    [SerializeField] private GameObject Level1Stages;
    [SerializeField] private GameObject Level2Stages;
    [SerializeField] private GameObject Level3Stages;

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
                Debug.Log("ClickAudio played from: " + Environment.StackTrace);

        clickAudio.Play();
        Level1Stages.SetActive(true);
        Levels.SetActive(false);
        //StartCoroutine(PlayClickThenLoad(2));
        //SceneManager.LoadScene(2,LoadSceneMode.Single);
    }

    public void LoadLevel2()
    {
                Debug.Log("ClickAudio played from: " + Environment.StackTrace);

        clickAudio.Play();
        Level2Stages.SetActive(true);
        Levels.SetActive(false);
        //StartCoroutine(PlayClickThenLoad(5));
        //SceneManager.LoadScene(5,LoadSceneMode.Single);
    }

    public void LoadLevel3()
    {
                Debug.Log("ClickAudio played from: " + Environment.StackTrace);

        clickAudio.Play();
        Level3Stages.SetActive(true);
        Levels.SetActive(false);
        //StartCoroutine(PlayClickThenLoad(9));
        //SceneManager.LoadScene(9,LoadSceneMode.Single);
    }
    public void Back()
    {
                Debug.Log("ClickAudio played from: " + Environment.StackTrace);

        clickAudio.Play();
        Levels.SetActive(true);
        Level1Stages.SetActive(false);
        Level2Stages.SetActive(false);
        Level3Stages.SetActive(false);
    }





     public void LoadLevel1Stage1()
    {
        StartCoroutine(PlayClickThenLoad(2));
        //SceneManager.LoadScene(2,LoadSceneMode.Single);
    }

    public void LoadLevel1Stage2()
    {
        StartCoroutine(PlayClickThenLoad(3));
        //SceneManager.LoadScene(3,LoadSceneMode.Single);
    }

    public void LoadLevel1Stage3()
    {
        StartCoroutine(PlayClickThenLoad(4));
        //SceneManager.LoadScene(4,LoadSceneMode.Single);
    }






      public void LoadLevel2Stage1()
    {
        StartCoroutine(PlayClickThenLoad(5));
        //SceneManager.LoadScene(5,LoadSceneMode.Single);
    }

    public void LoadLevel2Stage2()
    {
        StartCoroutine(PlayClickThenLoad(6));
        //SceneManager.LoadScene(6,LoadSceneMode.Single);
    }

    public void LoadLevel2Stage3()
    {
        StartCoroutine(PlayClickThenLoad(7));
        //SceneManager.LoadScene(7,LoadSceneMode.Single);
    }
        public void LoadLevel2Stage4()
    {
        StartCoroutine(PlayClickThenLoad(8));
        //SceneManager.LoadScene(8,LoadSceneMode.Single);
    }





      public void LoadLevel3Stage1()
    {
        StartCoroutine(PlayClickThenLoad(9));
        //SceneManager.LoadScene(9,LoadSceneMode.Single);
    }

    public void LoadLevel3Stage2()
    {
        StartCoroutine(PlayClickThenLoad(10));
        //SceneManager.LoadScene(10,LoadSceneMode.Single);
    }

    public void LoadLevel3Stage3()
    {
        StartCoroutine(PlayClickThenLoad(11));
        //SceneManager.LoadScene(11,LoadSceneMode.Single);
    }

        public void LoadLevel3Stage4()
    {
        StartCoroutine(PlayClickThenLoad(12));
        //SceneManager.LoadScene(12,LoadSceneMode.Single);
    }

    private IEnumerator PlayClickThenLoad(int sceneIndex)
    {
        Debug.Log("ClickAudio played from: " + Environment.StackTrace);

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
        int nextSceneNo = SceneManager.GetActiveScene().buildIndex + 1;
        StartCoroutine(PlayClickThenLoad(nextSceneNo));
        gameObject.GetComponent<Canvas>().enabled = false;
    }
    public void PlayAgain()
    {
        int sceneNo = SceneManager.GetActiveScene().buildIndex;
        int levelStart = 2;
        if (sceneNo >= 9) { levelStart = 9; }
        else if (sceneNo >= 5) { levelStart = 5; }
            CharacterDialogue cd = FindAnyObjectByType<CharacterDialogue>();
        if (cd != null && cd.IsGameOver())
        {
            cd.ResetLives();
            SceneManager.LoadScene(levelStart); // back to stage 1
        }
        else
        {
            SceneManager.LoadScene(sceneNo); // retry current stage
        }
        gameObject.GetComponent<Canvas>().enabled = false;
    }
    public void ReplayGame()
    {
        StartCoroutine(PlayClickThenLoad(2));
    }
}