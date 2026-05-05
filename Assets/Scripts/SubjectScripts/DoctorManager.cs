using UnityEngine;

public class DoctorManager : MonoBehaviour
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
        accused1Number = Random.Range(0, characterManager.honest.Count-1);
        accused1 = characterManager.honest[accused1Number];
        if (gameObject.tag != "Untagged") { SpeakLies(); }
        else { SpeakTruth(); }
        dialogue = accused1.name + " is an honest subject, " + accused2.name + " is a lying subject, and " + accused3.name + " is a ghost";
        gameObject.GetComponent<CharacterDialogue>().Speak(dialogue);
    }
    public void OnMouseUpAsButton()
    {
        gameObject.GetComponent<CharacterDialogue>().Petrify();
    }
    public void SpeakTruth()
    {
        accused2Number = Random.Range(0, characterManager.lying.Count - 1);
        accused2 = characterManager.lying[accused2Number];
        accused3Number = Random.Range(0, characterManager.ghosts.Count - 1);
        accused3 = characterManager.ghosts[accused3Number];
    }
    public void SpeakLies()
    {
        accused2Number = Random.Range(0, characterManager.ghosts.Count - 1);
        accused2 = characterManager.ghosts[accused2Number];
        accused3Number = Random.Range(0, characterManager.lying.Count - 1);
        accused3 = characterManager.lying[accused3Number];
    }
}
