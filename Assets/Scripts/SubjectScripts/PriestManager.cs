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
