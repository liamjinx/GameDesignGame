using UnityEngine;

public class MaidManager : MonoBehaviour
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
        dialogue = accused.name + " is lying";
        Speak();
    }
    
    public void OnMouseUpAsButton()
    {
        gameObject.GetComponent<CharacterDialogue>().Petrify();
    }
    public void Speak()
    {
        gameObject.GetComponent<CharacterDialogue>().Speak(dialogue);
    }
}
