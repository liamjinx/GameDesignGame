using UnityEngine;

public class KnightManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private string dialogue;
    void Start()
    {
        int max = transform.parent.childCount - 1;
        int accused1Number = Random.Range(0, max);
        GameObject accused1 = gameObject.transform.parent.GetChild(accused1Number).gameObject;
        int accused2Number = Random.Range(0, max);
        GameObject accused2 = gameObject.transform.parent.GetChild(accused2Number).gameObject;
        if (accused1.CompareTag(gameObject.tag))
        {
            while (accused2.CompareTag(gameObject.tag))
            {
                accused2Number = Random.Range(0, max);
                accused2 = gameObject.transform.parent.GetChild(accused2Number).gameObject;
            }
        } else {
            while (accused2.tag == "Ghost")
            {
                accused2Number = Random.Range(0, max);
                accused2 = gameObject.transform.parent.GetChild(accused2Number).gameObject;
            }
        }
        dialogue = "If " + accused1.name + " is not the ghost, then the " + accused2.name + " is the ghost";
    }
    public void OnMouseUpAsButton()
    {
        int max = transform.parent.childCount - 1;
        int accused1Number = Random.Range(0, max);
        GameObject accused1 = gameObject.transform.parent.GetChild(accused1Number).gameObject;
        int accused2Number = Random.Range(0, max);
        GameObject accused2 = gameObject.transform.parent.GetChild(accused2Number).gameObject;
        if (accused1.CompareTag(gameObject.tag))
        {
            while (accused2.CompareTag(gameObject.tag))
            {
                accused2Number = Random.Range(0, max);
                accused2 = gameObject.transform.parent.GetChild(accused2Number).gameObject;
            }
        }
        else
        {
            while (accused2.tag == "Ghost")
            {
                accused2Number = Random.Range(0, max);
                accused2 = gameObject.transform.parent.GetChild(accused2Number).gameObject;
            }
        }
        dialogue = "If " + accused1.name + " is not the ghost, then the " + accused2.name + " is the ghost";
        Speak();
    }
    public void Speak()
    {
        gameObject.GetComponent<CharacterDialogue>().Speak(dialogue);
    }
}
