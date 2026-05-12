using UnityEngine;

public class KingManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private string dialogue;
    void Start()
    {
        int currentPos = transform.GetSiblingIndex();
        int max = transform.parent.childCount - 1;
        int beforePos; int afterPos;
        if (currentPos == 0) { beforePos = max; afterPos = currentPos + 1; }
        else if (currentPos == max) { beforePos = currentPos - 1; afterPos = 0; }
        else { beforePos = currentPos - 1; afterPos = currentPos + 1; }
        string before = transform.parent.GetChild(beforePos).gameObject.tag;
        string after = transform.parent.GetChild(afterPos).gameObject.tag;
        int subjectCount = 0;
        if (gameObject.CompareTag("Untagged"))
        {
            if (before != "Ghost") { ++subjectCount; }
            if (after != "Ghost") { ++subjectCount; }
        } else
        {
            if (before == "Ghost" || after == "Ghost") { subjectCount = 2; }
            else { subjectCount = 0; }
        }
        dialogue = "I am next to " + subjectCount + " subjects";
        gameObject.GetComponent<CharacterDialogue>().Speak(dialogue);
    }
    public void OnMouseUpAsButton()
    {
        gameObject.GetComponent<CharacterDialogue>().Petrify();
    }
}
