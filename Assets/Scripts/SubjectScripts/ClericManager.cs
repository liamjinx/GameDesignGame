using UnityEngine;

public class ClericManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private string dialogue;
    void Start()
    {
        int max = transform.parent.childCount - 1;
        int accused1Number = Random.Range(0, max);
        GameObject accused1 = gameObject.transform.parent.GetChild(accused1Number).gameObject;
        while (accused1.tag == "Ghost" && gameObject.tag == "Ghost")
        {
            accused1Number = Random.Range(0, max);
            accused1 = gameObject.transform.parent.GetChild(accused1Number).gameObject;
        }
        int accused2Number = Random.Range(0, max);
        GameObject accused2 = gameObject.transform.parent.GetChild(accused2Number).gameObject;
        if (gameObject.tag == "Ghost")
        {
            while (accused1Number == accused2Number || accused2.tag == "Ghost" || accused2 == gameObject)
            {
                accused2Number = Random.Range(0, max);
                accused2 = gameObject.transform.parent.GetChild(accused2Number).gameObject;
            }
        } else if (gameObject.tag != "Ghost")
        {
            while (accused1Number == accused2Number || accused2.tag != "Ghost")
            {
                accused2Number = Random.Range(0, max);
                accused2 = gameObject.transform.parent.GetChild(accused2Number).gameObject;
            }
        }
        dialogue = accused1.name + " and " + accused2.name + " could be ghosts";
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
