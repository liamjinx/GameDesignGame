using Unity.VisualScripting;
using UnityEngine;

public class BardManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private string dialogue;
    void Start()
    {
        int currentPos = transform.GetSiblingIndex();
        int max = transform.parent.childCount - 1;
        int beforePos; int afterPos; int distance = 0;
        if (currentPos == 0) { beforePos = max; afterPos = currentPos + 1; }
        else if (currentPos == max) { beforePos = currentPos - 1; afterPos = 0; }
        else { beforePos = currentPos - 1; afterPos = currentPos + 1; }
        for (int i = 0; i < max; ++i)
        {
            string before = transform.parent.GetChild(beforePos).gameObject.tag;
            string after = transform.parent.GetChild(afterPos).gameObject.tag;
            if (gameObject.tag == "Untagged")
            {
                if (before == "Ghost" || after == "Ghost") { distance = i+1; break; }
            }
            else
            {
                if (before != "Ghost" || after != "Ghost") { distance = i+1; break; }
            }
            if (beforePos == 0) { beforePos = max;}
            else { --beforePos; }
            if (afterPos == max) { afterPos = 0; }
            else { ++afterPos; }
        }
        dialogue = "I am " + distance + " spaces away from a ghost";
        gameObject.GetComponent<CharacterDialogue>().Speak(dialogue);
    }

    public void OnMouseUpAsButton()
    {
        gameObject.GetComponent<CharacterDialogue>().Petrify();
    }
}
