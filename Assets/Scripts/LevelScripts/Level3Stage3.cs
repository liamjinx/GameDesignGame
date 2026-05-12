using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3Stage3 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameObject ghost1;
    private GameObject ghost2;
    private GameObject ghost3;

    private static bool hasShownStartExplanation;

    [SerializeField] private GameObject noteButton;
    [SerializeField] private GameObject ghostCount;
    [SerializeField] private GameObject petrifyButton;
    [SerializeField] private GameObject timer;
    [SerializeField] private GameObject timerExplaination;
    [SerializeField] private GameObject menuReturn;
    [SerializeField] private TimerManager timerManager;

    private AudioSource popUpAudio;
    private CharacterManager characterManager;

    private int max;

    private int lastIndex;
    void Awake()
    {
        characterManager = GetComponent<CharacterManager>();
        max = transform.childCount;
        lastIndex = max - 1;
        int ghostnumber1 = Random.Range(0, max);
        int ghostnumber2 = Random.Range(0, max);
        int ghostnumber3 = Random.Range(0, max);
        while (ghostnumber1 == ghostnumber2 || ghostnumber1 == ghostnumber3 || ghostnumber2 == ghostnumber3)
        {
            ghostnumber2 = Random.Range(0, max);
            ghostnumber3 = Random.Range(0, max);
        }
        ghost1 = transform.GetChild(ghostnumber1).gameObject;
        ghost2 = transform.GetChild(ghostnumber2).gameObject;
        ghost3 = transform.GetChild(ghostnumber3).gameObject;
        ghost1.tag = "Ghost";
        ghost2.tag = "Ghost";
        //ghost3.tag = "Ghost";
        ActivatePhantom();
        ActivateNuckelavee();
        //ActivateWraith();
        for (int i = 0; i < max; ++i)
        {
            GameObject character = transform.GetChild(i).gameObject;
            if (character.CompareTag("Ghost")) { characterManager.ghosts.Add(character); }
            else { characterManager.subjects.Add(character); }
            if (character.CompareTag("Untagged")) { characterManager.honest.Add(character); }
            else if (character.CompareTag("Lying")) { characterManager.lying.Add(character); }
        }
        popUpAudio = GameObject.FindGameObjectWithTag("PopUpAudio").GetComponent<AudioSource>();
    }

    private void ActivatePhantom()
    {
        ghost1.layer = LayerMask.NameToLayer("Phantom");

        int currentPos = ghost1.transform.GetSiblingIndex();
        int beforePos; int afterPos;
        if (currentPos == 0) { beforePos = lastIndex; afterPos = currentPos + 1; }
        else if (currentPos == lastIndex) { beforePos = currentPos - 1; afterPos = 0; }
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
     private void ActivateNuckelavee()
    {
        ghost2.layer = LayerMask.NameToLayer("Nuckelavee");

        int currentPos = ghost2.transform.GetSiblingIndex();
        int beforePos; int afterPos;
        if (currentPos == 0) { beforePos = lastIndex; afterPos = currentPos + 1; }
        else if (currentPos == lastIndex) { beforePos = currentPos - 1; afterPos = 0; }
        else { beforePos = currentPos - 1; afterPos = currentPos + 1; }
        if (transform.GetChild(beforePos).gameObject.CompareTag("Untagged"))
        {
            transform.GetChild(beforePos).gameObject.tag = "Lying";
        }
        if (transform.GetChild(afterPos).gameObject.CompareTag("Untagged"))
        {
            transform.GetChild(afterPos).gameObject.tag = "Lying";
        }
    }

    void Start()
    {
        if (timerManager != null)
        {
            timerManager.StartTimer();
        }
    }

    public void ToggleExplanation()
    {
        noteButton.SetActive(!noteButton.activeSelf);
        ghostCount.SetActive(!ghostCount.activeSelf);
        petrifyButton.SetActive(!petrifyButton.activeSelf);
        timer.SetActive(!timer.activeSelf);
        timerExplaination.SetActive(!timerExplaination.activeSelf);
        menuReturn.SetActive(!menuReturn.activeSelf);
        popUpAudio.Play();
    }
}
