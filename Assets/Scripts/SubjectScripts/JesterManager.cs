using UnityEngine;

public class JesterManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private string dialogue;
    void Start()
    {
        int max = transform.parent.childCount - 1;
        int accusedNumber = Random.Range(0, max);
        GameObject accused = gameObject.transform.parent.GetChild(accusedNumber).gameObject;
        while (accused.CompareTag(gameObject.tag))
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
