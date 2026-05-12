using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Stage1 : MonoBehaviour
{
    private GameObject ghost1;
    private static bool hasShownExplanation;

    [SerializeField] private GameObject explanation;
    private CharacterManager characterManager;
    void Awake()
    {
        characterManager = GetComponent<CharacterManager>();
        int max = transform.childCount;
        int ghostnumber1 = Random.Range(0, max);

        ghost1 = transform.GetChild(ghostnumber1).gameObject;
        ghost1.tag = "Ghost";
        for (int i = 0; i < max; ++i)
        {
            GameObject character = transform.GetChild(i).gameObject;
            if (character.CompareTag("Ghost")) { characterManager.ghosts.Add(character); }
            else { characterManager.subjects.Add(character); }
            if (character.CompareTag("Untagged")) { characterManager.honest.Add(character); }
            else if (character.CompareTag("Lying")) { characterManager.lying.Add(character); }
        }
    }    
    void Start()
    {
        if (!hasShownExplanation)
        {
            explanation.SetActive(true);
            hasShownExplanation = true;
        }
    }

    public void CloseExplanation()
    {
        explanation.SetActive(false);
    }
}