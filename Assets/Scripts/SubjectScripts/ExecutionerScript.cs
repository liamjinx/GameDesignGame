using UnityEngine;

public class ExecutionerScript : MonoBehaviour
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
        accused1Number = Random.Range(0, max);
        accused1 = gameObject.transform.parent.GetChild(accused1Number).gameObject;
        while (accused1.name == gameObject.name)
        {
            accused1Number = Random.Range(0, max);
            accused1 = gameObject.transform.parent.GetChild(accused1Number).gameObject;
        }
        if (!gameObject.CompareTag("Untagged")) { SpeakLies(); }
        else { SpeakTruth(); }
        dialogue = accused2.name + " is a subject if and only if " + accused1.name + " is a subject";
        gameObject.GetComponent<CharacterDialogue>().Speak(dialogue);
    }

    public void OnMouseUpAsButton()
    {
        gameObject.GetComponent<CharacterDialogue>().Petrify();
    }
    public void SpeakTruth()
    {
        if (accused1.CompareTag("Ghost")) { SpeakLies(); return; }
        accused2Number = Random.Range(0, characterManager.subjects.Count);
        accused2 = characterManager.subjects[accused2Number];
        while (accused2.name == accused1.name)
        {
            accused2Number = Random.Range(0, characterManager.subjects.Count);
            accused2 = characterManager.subjects[accused2Number];
        }
    }
    public void SpeakLies()
    {
        accused2Number = Random.Range(0, characterManager.ghosts.Count);
        accused2 = characterManager.ghosts[accused2Number];
        while (characterManager.ghosts.Count > 1 && accused2.name == accused1.name)
        {
            accused2Number = Random.Range(0, characterManager.ghosts.Count);
            accused2 = characterManager.ghosts[accused2Number];
        }
    }
}
