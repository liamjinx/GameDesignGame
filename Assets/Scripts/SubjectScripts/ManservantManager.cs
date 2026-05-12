using UnityEngine;

public class ManservantManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private string dialogue;
    private int max;
    private int accusedNumber;
    private GameObject accused;
    private CharacterManager characterManager;
    void Start()
    {
        characterManager = transform.parent.GetComponent<CharacterManager>();
        max = transform.parent.childCount;
        if (!gameObject.CompareTag("Untagged")) { SpeakLies(); }
        else { SpeakTruth(); }
        dialogue = accused.name + " is a subject";
        gameObject.GetComponent<CharacterDialogue>().Speak(dialogue);
    }

    public void OnMouseUpAsButton()
    {
        gameObject.GetComponent<CharacterDialogue>().Petrify();
    }
    public void SpeakTruth()
    {
        accusedNumber = Random.Range(0, characterManager.subjects.Count);
        accused = characterManager.subjects[accusedNumber];
        while (accused.name == gameObject.name)
        {
            accusedNumber = Random.Range(0, characterManager.subjects.Count);
            accused = characterManager.subjects[accusedNumber];
        }
    }
    public void SpeakLies()
    {
        accusedNumber = Random.Range(0, characterManager.ghosts.Count);
        accused = characterManager.ghosts[accusedNumber];
    }
}
