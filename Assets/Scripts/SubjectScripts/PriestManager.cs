using UnityEngine;

public class PriestManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private string dialogue;
    private int max;
    private int accused1Number;
    private GameObject accused1;
    private int accused2Number;
    private GameObject accused2;
    private int accused3Number;
    private GameObject accused3;
    private CharacterManager characterManager;
    void Start()
    {
        characterManager = transform.parent.GetComponent<CharacterManager>();
        max = transform.parent.childCount;
        accused2Number = Random.Range(0, characterManager.subjects.Count);
        accused2 = characterManager.subjects[accused2Number];
        accused3Number = Random.Range(0, characterManager.subjects.Count);
        accused3 = characterManager.subjects[accused3Number];
        if (!gameObject.CompareTag("Untagged")) { SpeakLies(); }
        else { SpeakTruth(); }
        while (accused2.name == accused1.name)
        {
            accused2Number = Random.Range(0, characterManager.subjects.Count);
            accused2 = characterManager.subjects[accused2Number];
        }
        while (accused3.name == accused1.name || accused3.name == accused2.name)
        {
            accused3Number = Random.Range(0, characterManager.subjects.Count);
            accused3 = characterManager.subjects[accused3Number];
        }
        dialogue = "Only one of " + accused1.name + ", " + accused2.name + ", or " + accused3.name + " is a ghost";
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
    }
    public void SpeakLies()
    {
        accused1Number = Random.Range(0, characterManager.subjects.Count);
        accused1 = characterManager.subjects[accused1Number];
    }
}
