using Unity.VisualScripting;
using UnityEngine;

public class TutorialUIManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject noteButton;
    [SerializeField] private GameObject instructionsButton;
    [SerializeField] private GameObject petrifyButton;
    [SerializeField] private GameObject instructions;
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
    }
    public void HideInstructions()
    {
        noteButton.SetActive(!noteButton.activeSelf);
        instructionsButton.SetActive(!instructionsButton.activeSelf);
        petrifyButton.SetActive(!petrifyButton.activeSelf);
        instructions.SetActive(!instructions.activeSelf);
    }
}
