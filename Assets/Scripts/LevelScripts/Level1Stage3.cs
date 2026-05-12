using UnityEngine;
using UnityEngine.SceneManagement;


public class Level1Stage3 : MonoBehaviour
{
    private GameObject ghost1;
    private GameObject ghost2;
    private CharacterManager characterManager;
    void Awake()
    {
        characterManager = GetComponent<CharacterManager>();
        int max = transform.childCount;

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
        for (int i = 0; i < max; ++i)
        {
            GameObject character = transform.GetChild(i).gameObject;
            if (character.CompareTag("Ghost")) { characterManager.ghosts.Add(character); }
            else { characterManager.subjects.Add(character); }
            if (character.CompareTag("Untagged")) { characterManager.honest.Add(character); }
            else if (character.CompareTag("Lying")) { characterManager.lying.Add(character); }
        }
    }
    
}