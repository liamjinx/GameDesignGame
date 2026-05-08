using Unity.VisualScripting;
using UnityEngine;

public class TutorialUIManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject noteButton;
    [SerializeField] private GameObject instructionsButton;
    [SerializeField] private GameObject petrifyButton;
    [SerializeField] private GameObject instructions;
    [SerializeField] private AudioSource PopUpAudio;
    [SerializeField] private AudioSource ClickAudio;
    void Start()
    {
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
        PopUpAudio.Play();
    }
    public void HideInstructions()
    {
        noteButton.SetActive(!noteButton.activeSelf);
        instructionsButton.SetActive(!instructionsButton.activeSelf);
        petrifyButton.SetActive(!petrifyButton.activeSelf);
        instructions.SetActive(!instructions.activeSelf);
        ClickAudio.Play();
    }
}
