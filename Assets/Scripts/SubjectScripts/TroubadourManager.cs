using UnityEngine;

public class TroubadourManager : MonoBehaviour
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
        max = transform.parent.childCount; 
        characterManager = transform.parent.GetComponent<CharacterManager>();
        if (!gameObject.CompareTag("Untagged")) { SpeakLies(); }
        else { SpeakTruth(); }
        dialogue = accused1.name + " and " + accused2.name + " could be lying subjects";
        gameObject.GetComponent<CharacterDialogue>().Speak(dialogue);
    }
    public void OnMouseUpAsButton()
    {
        gameObject.GetComponent<CharacterDialogue>().Petrify();
    }
    public void SpeakTruth()
    {
        accused1Number = Random.Range(0, characterManager.lying.Count);
        accused1 = characterManager.lying[accused1Number];
        if (characterManager.lying.Count == 1)
        {
            accused2Number = Random.Range(0, characterManager.honest.Count);
            accused2 = characterManager.honest[accused2Number];
            return;
        }
        accused2Number = Random.Range(0, characterManager.lying.Count);
        accused2 = characterManager.lying[accused2Number];
        while (accused2.name == accused1.name)
        {
            accused2Number = Random.Range(0, characterManager.lying.Count);
            accused2 = characterManager.lying[accused2Number];
        }
    }
    public void SpeakLies()
    {
        accused1Number = Random.Range(0, characterManager.honest.Count);
        accused1 = characterManager.honest[accused1Number];
        accused2Number = Random.Range(0, characterManager.honest.Count);
        accused2 = characterManager.honest[accused2Number];
        while (accused2.name == accused1.name)
        {
            accused2Number = Random.Range(0, characterManager.honest.Count);
            accused2 = characterManager.honest[accused2Number];
        }
    }
}
