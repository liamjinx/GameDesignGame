using UnityEngine;

public class ManservantManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private string dialogue;
    void Start()
    {
        int max = transform.parent.childCount - 1;
        int accusedNumber = Random.Range(0, max);
        GameObject accused = gameObject.transform.parent.GetChild(accusedNumber).gameObject;
        while (!accused.CompareTag(gameObject.tag) || accused  == gameObject)
        {
            accusedNumber = Random.Range(0, max);
            accused = gameObject.transform.parent.GetChild(accusedNumber).gameObject;
        }
        dialogue = accused.name + " is a subject";
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
