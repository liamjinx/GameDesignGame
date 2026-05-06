using UnityEngine;

public class ChefManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private string dialogue;
    private int accused1Number;
    private GameObject accused1;
    private CharacterManager characterManager;
    void Start()
    {
        characterManager = transform.parent.GetComponent<CharacterManager>();
        if (gameObject.tag != "Untagged") { SpeakLies(); }
        else { SpeakTruth(); }
        dialogue = accused1.name + " is an honest subject";
        gameObject.GetComponent<CharacterDialogue>().Speak(dialogue);
    }
    public void SpeakTruth()
    {
        accused1Number = Random.Range(0, characterManager.honest.Count - 1);
        accused1 = characterManager.honest[accused1Number];
    }
    public void SpeakLies()
    {
        accused1Number = Random.Range(0, characterManager.lying.Count - 1);
        accused1 = characterManager.lying[accused1Number];
    }
}
