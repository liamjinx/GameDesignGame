using UnityEngine;

public class JesterManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private string dialogue;
    private GameObject accused;
    void Start()
    {
        int max = transform.parent.childCount - 1;
        int accusedNumber = Random.Range(0, max);
        accused = gameObject.transform.parent.GetChild(accusedNumber).gameObject;
        while (gameObject.tag == "Ghost" && accused.tag == "Ghost")
        {
            accusedNumber = Random.Range(0, max);
            accused = gameObject.transform.parent.GetChild(accusedNumber).gameObject;
        } 
        while (gameObject.tag != "Ghost" && accused.tag != "Ghost")
        {
            accusedNumber = Random.Range(0, max);
            accused = gameObject.transform.parent.GetChild(accusedNumber).gameObject;
        }
        dialogue = "Either I am the ghost or " + accused.name + " is the ghost";
    }
    public void OnMouseUpAsButton()
    {
        Speak();
    }

    public void Speak()
    {
        gameObject.GetComponent<CharacterDialogue>().Speak(dialogue);
    }
}
