using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterManager : MonoBehaviour
{
    public bool isActive = false;
    private GameObject ghost1;
    private GameObject ghost2;
    public GameObject selectedCharacter;
    InputAction safeAction;
    InputAction neutralAction;
    InputAction suspicousAction;
    void Awake()
    {
        int max = transform.childCount - 1;
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
    }
    private void Start()
    {
        safeAction = InputSystem.actions.FindAction("Safe");
        neutralAction = InputSystem.actions.FindAction("Neutral");
        suspicousAction = InputSystem.actions.FindAction("Suspicous");
    }
    private void Update()
    {
        if (selectedCharacter == null)
        {
            return;
        }
        if (safeAction.WasPressedThisFrame())
        {
            selectedCharacter.GetComponent<SpriteRenderer>().color = Color.green;
        }
        if (neutralAction.WasPressedThisFrame())
        {
            selectedCharacter.GetComponent<SpriteRenderer>().color = Color.white;
        }
        if (suspicousAction.WasPressedThisFrame())
        {
            selectedCharacter.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

}
