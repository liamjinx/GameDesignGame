using Unity.VisualScripting;
using UnityEngine;

public class TutorialUIManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject noteButton;
    [SerializeField] private GameObject instructionsButton;
    [SerializeField] private GameObject petrifyButton;
    [SerializeField] private GameObject ghostCount;
    [SerializeField] private GameObject instructions;
    [SerializeField] private GameObject menuReturn;
    [SerializeField] private AudioSource popUpAudio;
    [SerializeField] private AudioSource clickAudio;
    void Start()
    {
        clickAudio = GameObject.FindGameObjectWithTag("ClickAudio").GetComponent<AudioSource>();
        popUpAudio = GameObject.FindGameObjectWithTag("PopUpAudio").GetComponent<AudioSource>();
        ShowInstructions();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowInstructions()
    {
        noteButton.SetActive(!noteButton.activeSelf);
        instructionsButton.SetActive(!instructionsButton.activeSelf);
        petrifyButton.SetActive(!petrifyButton.activeSelf);
        instructions.SetActive(!instructions.activeSelf);
        ghostCount.SetActive(!ghostCount.activeSelf);
        menuReturn.SetActive(!menuReturn.activeSelf);
        popUpAudio.Play();
    }
    public void HideInstructions()
    {
        noteButton.SetActive(!noteButton.activeSelf);
        instructionsButton.SetActive(!instructionsButton.activeSelf);
        petrifyButton.SetActive(!petrifyButton.activeSelf);
        instructions.SetActive(!instructions.activeSelf);
        ghostCount.SetActive(!ghostCount.activeSelf);
        menuReturn.SetActive(!menuReturn.activeSelf);
        clickAudio.Play();
    }
}
