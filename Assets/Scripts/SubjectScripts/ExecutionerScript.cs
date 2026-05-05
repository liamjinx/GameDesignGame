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
    void Start()
    {
        max = transform.parent.childCount - 1;
        accused1Number = Random.Range(0, max);
        accused1 = gameObject.transform.parent.GetChild(accused1Number).gameObject;
        accused2Number = Random.Range(0, max);
        accused2 = gameObject.transform.parent.GetChild(accused2Number).gameObject;
        if (gameObject.tag != "Untagged") { SpeakLies(); }
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
        if (accused1.tag == "Ghost") { SpeakLies(); return; }
        while (accused2.tag == "Ghost")
        {
            accused2Number = Random.Range(0, max);
            accused2 = gameObject.transform.parent.GetChild(accused2Number).gameObject;
        }
    }
    public void SpeakLies()
    {
        while (accused2.tag != "Ghost" || accused2Number == accused1Number)
        {
            accused2Number = Random.Range(0, max);
            accused2 = gameObject.transform.parent.GetChild(accused2Number).gameObject;
        }
    }
}
