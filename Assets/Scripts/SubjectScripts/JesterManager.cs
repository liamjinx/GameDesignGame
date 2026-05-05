using UnityEngine;

public class JesterManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private string dialogue;
    private int max;
    private int accusedNumber;
    private GameObject accused;
    void Start()
    {
        max = transform.parent.childCount - 1;
        accusedNumber = Random.Range(0, max);
        accused = gameObject.transform.parent.GetChild(accusedNumber).gameObject;
        if (gameObject.tag != "Untagged") { SpeakLies(); }
        else { SpeakTruth(); }
        dialogue = "Either I am the ghost or " + accused.name + " is the ghost";
        gameObject.GetComponent<CharacterDialogue>().Speak(dialogue);
    }

    public void OnMouseUpAsButton()
    {
        gameObject.GetComponent<CharacterDialogue>().Petrify();
    }
    public void SpeakTruth()
    {
        while (accused.tag != "Ghost")
        {
            accusedNumber = Random.Range(0, max);
            accused = gameObject.transform.parent.GetChild(accusedNumber).gameObject;
        }
    }
    public void SpeakLies()
    {
        while (accused.tag == "Ghost")
        {
            accusedNumber = Random.Range(0, max);
            accused = gameObject.transform.parent.GetChild(accusedNumber).gameObject;
        }
    }
}
