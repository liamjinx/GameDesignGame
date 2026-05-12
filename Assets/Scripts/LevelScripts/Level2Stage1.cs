using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;


public class Level2Stage1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameObject ghost1;
    private CharacterManager characterManager;
    private static bool hasShownExplanation;
    [SerializeField] private GameObject noteButton;
    [SerializeField] private GameObject ghostCount;
    [SerializeField] private GameObject petrifyButton;
    [SerializeField] private GameObject explanation;
    [SerializeField] private GameObject menuReturn;
    [SerializeField] private AudioSource popUpAudio;
    private int max;
    void Awake()
    {
        characterManager = GetComponent<CharacterManager>();
        max = transform.childCount;
        int ghostnumber1 = Random.Range(0, max);
        int ghostnumber2 = Random.Range(0, max);
        while (ghostnumber1 == ghostnumber2)
        {
            ghostnumber2 = Random.Range(0, max);
        }
        ghost1 = transform.GetChild(ghostnumber1).gameObject;
        ghost1.tag = "Ghost";
        ActivateWraith();
        for (int i = 0; i < max; ++i)
        {
            GameObject character = transform.GetChild(i).gameObject;
            if (character.CompareTag("Ghost")) { characterManager.ghosts.Add(character); }
            else { characterManager.subjects.Add(character); }
            if (character.CompareTag("Untagged")) { characterManager.honest.Add(character); }
            else if (character.CompareTag("Lying")) { characterManager.lying.Add(character); }
        }
        popUpAudio = GameObject.FindGameObjectWithTag("PopUpAudio").GetComponent<AudioSource>();
    }
    private void ActivateWraith()
    {
        ghost1.layer = LayerMask.NameToLayer("Wraith");

        int affected = Random.Range(0, max);
        GameObject affectedSubject = transform.GetChild(affected).gameObject;
        while (!affectedSubject.CompareTag("Untagged"))
        {
            affected = Random.Range(0, max);
            affectedSubject = transform.GetChild(affected).gameObject;
        }
        affectedSubject.tag = "Lying";
    }
    void Start()
    {
        if (!hasShownExplanation)
        {
            ToggleExplanation();
            hasShownExplanation = true;
        }
    }
    public void ToggleExplanation()
    {
        noteButton.SetActive(!noteButton.activeSelf);
        ghostCount.SetActive(!ghostCount.activeSelf);
        petrifyButton.SetActive(!petrifyButton.activeSelf);
        explanation.SetActive(!explanation.activeSelf);
        menuReturn.SetActive(!menuReturn.activeSelf);
        popUpAudio.Play();
    }
}
