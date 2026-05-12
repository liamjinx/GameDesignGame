using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Level2Stage3 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameObject ghost1;
    private GameObject ghost2;
    private CharacterManager characterManager;
    private int max;
    void Awake()
    {
        characterManager = GetComponent<CharacterManager>();
        max = transform.childCount;
        int ghostnumber1 = Random.Range(0, max);
        int ghostnumber2 = Random.Range(0, max);
        while (ghostnumber1 == ghostnumber2)
        {
            ghostnumber2 = Random.Range(0, max);
        }
        ghost1 = transform.GetChild(ghostnumber1).gameObject;
        ghost2 = transform.GetChild(ghostnumber2).gameObject;
        ghost1.tag = "Ghost";
        ghost2.tag = "Ghost";
        ActivatePhantom();
        for (int i = 0; i < max; ++i)
        {
            GameObject character = transform.GetChild(i).gameObject;
            if (character.CompareTag("Ghost")) { characterManager.ghosts.Add(character); }
            else { characterManager.subjects.Add(character); }
            if (character.CompareTag("Untagged")) { characterManager.honest.Add(character); }
            else if (character.CompareTag("Lying")) { characterManager.lying.Add(character); }
        }
    }
    private void ActivatePhantom()
    {
        ghost1.layer = LayerMask.NameToLayer("Phantom");

        int currentPos = ghost1.transform.GetSiblingIndex();
        int beforePos; int afterPos;
        if (currentPos == 0) { beforePos = max - 1; afterPos = currentPos + 1; }
        else if (currentPos == max - 1) { beforePos = currentPos - 1; afterPos = 0; }
        else { beforePos = currentPos - 1; afterPos = currentPos + 1; }
        if (transform.GetChild(beforePos).gameObject.CompareTag("Untagged"))
        {
            transform.GetChild(beforePos).gameObject.tag = "Lying";
        }
        else if (transform.GetChild(afterPos).gameObject.CompareTag("Untagged"))
        {
            transform.GetChild(afterPos).gameObject.tag = "Lying";
        }
    }
    private void ActivateWraith()
    {
        ghost2.layer = LayerMask.NameToLayer("Wraith");
        int affected = Random.Range(0, max);
        GameObject affectedSubject = transform.GetChild(affected).gameObject;
        while (!affectedSubject.CompareTag("Untagged"))
        {
            affected = Random.Range(0, max);
            affectedSubject = transform.GetChild(affected).gameObject;
        }
        affectedSubject.tag = "Lying";
    }
}
