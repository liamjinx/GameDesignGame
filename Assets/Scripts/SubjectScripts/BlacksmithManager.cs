using UnityEngine;

public class BlacksmithManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private string dialogue;
    void Start()
    {
        int currentPos = transform.GetSiblingIndex();
        int max = transform.parent.childCount - 1;
        int beforePos; int afterPos; int distance = 0;
        string spaceD = "space";
        if (currentPos == 0) { beforePos = max; afterPos = currentPos + 1; }
        else if (currentPos == max) { beforePos = currentPos - 1; afterPos = 0; }
        else { beforePos = currentPos - 1; afterPos = currentPos + 1; }
        for (int i = 0; i < max; ++i)
        {
            string before = transform.parent.GetChild(beforePos).gameObject.tag;
            string after = transform.parent.GetChild(afterPos).gameObject.tag;
            if (gameObject.tag == "Untagged")
            {
                if (before == "Lying" || after == "Lying") { distance = i + 1; break; }
            }
            else
            {
                if (before == "Ghost" || after == "Ghost") { distance = i + 1; break; }
            }
            if (beforePos == 0) { beforePos = max; }
            else { --beforePos; }
            if (afterPos == max) { afterPos = 0; }
            else { ++afterPos; }
            spaceD = "spaces";
        }
        dialogue = "I am " + distance + " " + spaceD + " away from a lying subject";
        gameObject.GetComponent<CharacterDialogue>().Speak(dialogue);
    }

    public void OnMouseUpAsButton()
    {
        gameObject.GetComponent<CharacterDialogue>().Petrify();
    }
}
