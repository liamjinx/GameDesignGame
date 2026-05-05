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
    void Start()
    {
        max = transform.parent.childCount - 1;
        accused1Number = Random.Range(0, max);
        accused1 = gameObject.transform.parent.GetChild(accused1Number).gameObject;
        accused2Number = Random.Range(0, max);
        accused2 = gameObject.transform.parent.GetChild(accused2Number).gameObject;
        accused3Number = Random.Range(0, max);
        accused3 = gameObject.transform.parent.GetChild(accused3Number).gameObject;
        if (gameObject.tag != "Untagged") { SpeakLies(); }
        else { SpeakTruth(); }
        while (accused2Number == accused1Number || accused2.tag == "Ghost")
        {
            accused2Number = Random.Range(0, max);
            accused2 = gameObject.transform.parent.GetChild(accused2Number).gameObject;
        }
        while (accused3Number == accused2Number || accused3Number == accused1Number || accused3.tag == "Ghost")
        {
            accused3Number = Random.Range(0, max);
            accused3 = gameObject.transform.parent.GetChild(accused3Number).gameObject;
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
        while (accused1.tag != "Ghost")
        {
            accused1Number = Random.Range(0, max);
            accused1 = gameObject.transform.parent.GetChild(accused1Number).gameObject;
        }
    }
    public void SpeakLies()
    {
        while (accused1.tag == "Ghost")
        {
            accused1Number = Random.Range(0, max);
            accused1 = gameObject.transform.parent.GetChild(accused1Number).gameObject;
        }
    }
}
