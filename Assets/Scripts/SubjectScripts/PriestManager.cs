using UnityEngine;

public class PriestManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private string dialogue;
    void Start()
    {
        int max = transform.parent.childCount - 1;
        int accused1Number = Random.Range(0, max);
        GameObject accused1 = gameObject.transform.parent.GetChild(accused1Number).gameObject;
        while (accused1.CompareTag(gameObject.tag))
        {
            accused1Number = Random.Range(0, max);
            accused1 = gameObject.transform.parent.GetChild(accused1Number).gameObject;
        }
        int accused2Number = Random.Range(0, max);
        GameObject accused2 = gameObject.transform.parent.GetChild(accused2Number).gameObject;
        while (accused2Number == accused1Number || accused2.tag == "Ghost")
        {
            accused2Number = Random.Range(0, max);
            accused2 = gameObject.transform.parent.GetChild(accused2Number).gameObject;
        }
        int accused3Number = Random.Range(0, max);
        GameObject accused3 = gameObject.transform.parent.GetChild(accused3Number).gameObject;
        while (accused3Number == accused2Number || accused3Number == accused1Number || accused2.tag == "Ghost")
        {
            accused3Number = Random.Range(0, max);
            accused3 = gameObject.transform.parent.GetChild(accused3Number).gameObject;
        }
        dialogue = "Only one of " + accused1.name + ", " + accused2.name + ", or " + accused3.name + " is a ghost";
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
