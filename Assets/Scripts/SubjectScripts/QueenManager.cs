using UnityEngine;

public class QueenManager : MonoBehaviour
{
    // Start is called once beforePos the first execution of Update afterPos the MonoBehaviour is created
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
        string after = transform.parent.GetChild (afterPos).gameObject.tag;
        if (gameObject.tag == "Ghost")
        {
            if (before == "Ghost" || after == "Ghost") {  dialogue = "I am next to no ghosts"; }
            else { dialogue = "I am next to at least one ghost"; }
        } else
        {
            if (before == "Ghost" || after == "Ghost") { dialogue = "I am next to at least one ghost"; }
            else { dialogue = "I am next to no ghosts"; }
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
