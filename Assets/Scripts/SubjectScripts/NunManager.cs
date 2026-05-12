using UnityEngine;

public class NunManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private string dialogue;
    private int max;
    private int accused1Number;
    private GameObject accused1;
    private int accused2Number;
    private GameObject accused2;
    private CharacterManager characterManager;
    void Start()
    {
        characterManager = transform.parent.GetComponent<CharacterManager>();
        max = transform.parent.childCount;
        if (!gameObject.CompareTag("Untagged")) { SpeakLies(); }
        else { SpeakTruth(); }
        dialogue = accused1.name + " and " + accused2.name + " could be ghosts";
        gameObject.GetComponent<CharacterDialogue>().Speak(dialogue);
    }
    
    public void OnMouseUpAsButton()
    {
        gameObject.GetComponent<CharacterDialogue>().Petrify();
    }
    public void SpeakTruth()
    {
        accused1Number = Random.Range(0, characterManager.ghosts.Count);
        accused1 = characterManager.ghosts[accused1Number];
        if (characterManager.ghosts.Count == 1)
        {
            accused2Number = Random.Range(0, characterManager.subjects.Count);
            accused2 = characterManager.subjects[accused2Number];
            return;
        }
        accused2Number = Random.Range(0, characterManager.ghosts.Count);
        accused2 = characterManager.ghosts[accused2Number];
        while (accused2.name == accused1.name)
        {
            accused2Number = Random.Range(0, characterManager.ghosts.Count);
            accused2 = characterManager.ghosts[accused2Number];
        }
    }
    public void SpeakLies()
    {
        accused1Number = Random.Range(0, characterManager.subjects.Count);
        accused1 = characterManager.subjects[accused1Number];
        accused2Number = Random.Range(0, characterManager.subjects.Count);
        accused2 = characterManager.subjects[accused2Number];
        while (accused2.name == accused1.name)
        {
            accused2Number = Random.Range(0, characterManager.subjects.Count);
            accused2 = characterManager.subjects[accused2Number];
        }
    }
}
