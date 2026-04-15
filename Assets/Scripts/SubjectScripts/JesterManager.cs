using UnityEngine;

public class JesterManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private string dialogue;
    private GameObject accused;
    void Start()
    {
        int accusedNumber = Random.Range(0, 5);
        accused = gameObject.transform.parent.GetChild(accusedNumber).gameObject;
        Debug.Log(accused.name);
        while (gameObject.tag == "Ghost" && accused.tag == "Ghost")
        {
            accusedNumber = Random.Range(0, 5);
            accused = gameObject.transform.parent.GetChild(accusedNumber).gameObject;
            //Debug.Log(accused.name);
        } 
        while (gameObject.tag != "Ghost" && accused.tag != "Ghost")
        {
            accusedNumber = Random.Range(0, 5);
            accused = gameObject.transform.parent.GetChild(accusedNumber).gameObject;
            Debug.Log(accused.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMouseUpAsButton()
    {
        Speak();
    }

    public void Speak()
    {
        CharacterDialogue character = gameObject.GetComponent<CharacterDialogue>();
        character.Petrify();
        dialogue = "Either I am the ghost or " + accused.name + " is the ghost";
        character.dialogue = dialogue;
        character.Speak();

    }
}
