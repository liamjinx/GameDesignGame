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
        max = transform.parent.childCount - 1; 
        characterManager = transform.parent.GetComponent<CharacterManager>();
        if (gameObject.tag != "Untagged") { SpeakLies(); }
        else { SpeakTruth(); }
        accused2Number = Random.Range(0, max);
        accused2 = gameObject.transform.parent.GetChild(accused2Number).gameObject;
        while ((accused2.tag == "Lying" && gameObject.tag != "Untagged") || (accused2.tag == "Ghost" && gameObject.tag == "Untagged") || accused2.name == accused1.name)
        {
            accused2Number = Random.Range(0, max);
            accused2 = gameObject.transform.parent.GetChild(accused2Number).gameObject;
        }
        dialogue = accused1.name + " and " + accused2.name + " could be lying subjects";
        gameObject.GetComponent<CharacterDialogue>().Speak(dialogue);
    }
    public void OnMouseUpAsButton()
    {
        gameObject.GetComponent<CharacterDialogue>().Petrify();
    }
    public void SpeakTruth()
    {
        accused1Number = Random.Range(0, characterManager.lying.Count - 1);
        accused1 = characterManager.lying[accused1Number];
    }
    public void SpeakLies()
    {
        accused1Number = Random.Range(0, characterManager.ghosts.Count - 1);
        accused1 = characterManager.ghosts[accused1Number];
    }
}
