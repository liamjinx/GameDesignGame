using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterManager : MonoBehaviour
{
    public bool isActive = false;
    public GameObject selectedCharacter;
    InputAction safeAction;
    InputAction neutralAction;
    InputAction susAction;
    public int ghostCount = 0;
    [SerializeField] private TextMeshProUGUI ghostNumber;
    private void Start()
    {
        safeAction = InputSystem.actions.FindAction("Safe");
        neutralAction = InputSystem.actions.FindAction("Neutral");
        susAction = InputSystem.actions.FindAction("Sus");
        ghostCount = GameObject.FindGameObjectsWithTag("Ghost").Length;
    }
    private void Update()
    {
        if (ghostNumber != null) { ghostNumber.text = "Ghosts Left: " + ghostCount.ToString(); }
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
        if (susAction.WasPressedThisFrame())
        {
            selectedCharacter.GetComponent<SpriteRenderer>().color = Color.red;
        }
        Debug.Log(ghostNumber.name);
    }

}
