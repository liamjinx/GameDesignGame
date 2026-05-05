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
    void Start()
    {
        max = transform.parent.childCount - 1;
        accused1Number = Random.Range(0, max);
        accused1 = gameObject.transform.parent.GetChild(accused1Number).gameObject;
        accused2Number = Random.Range(0, max);
        accused2 = gameObject.transform.parent.GetChild(accused2Number).gameObject;
        if (gameObject.tag != "Untagged") { SpeakLies(); }
        else { SpeakTruth(); Debug.Log(gameObject.tag); }
        dialogue = accused1.name + " and " + accused2.name + " could be ghosts";
        gameObject.GetComponent<CharacterDialogue>().Speak(dialogue);
        while ((accused2.tag == "Ghost" && gameObject.tag != "Untagged") || accused2Number == accused1Number || accused2 == gameObject)
        {
            accused2Number = Random.Range(0, max);
            accused2 = gameObject.transform.parent.GetChild(accused2Number).gameObject;
        }
    }
    
    public void OnMouseUpAsButton()
    {
        gameObject.GetComponent<CharacterDialogue>().Petrify();
    }
    public void SpeakTruth()
    {
        while (accused1.tag == "Untagged")
        {
            accused1Number = Random.Range(0, max);
            accused1 = gameObject.transform.parent.GetChild(accused1Number).gameObject;
        }
    }
    public void SpeakLies()
    {
        Debug.Log(gameObject.tag);
        while (accused1.tag == "Ghost")
        {
            accused1Number = Random.Range(0, max);
            accused1 = gameObject.transform.parent.GetChild(accused1Number).gameObject;
        }
    }
}
