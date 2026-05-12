using System.Collections.Generic;
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
    InputAction lyingAction;
    InputAction clickAction;
    public int ghostCount = 0;
    [SerializeField] private TextMeshProUGUI ghostNumber;
    private Color selectedColor = new Color(0.76f, 0.76f, 0.76f);
    public List<GameObject> subjects = new List<GameObject>();
    public List<GameObject> ghosts = new List<GameObject>();
    public List<GameObject> honest = new List<GameObject>();
    public List<GameObject> lying = new List<GameObject>();
    private void Start()
    {
        safeAction = InputSystem.actions.FindAction("Safe");
        neutralAction = InputSystem.actions.FindAction("Neutral");
        susAction = InputSystem.actions.FindAction("Sus");
        lyingAction = InputSystem.actions.FindAction("Lying");
        clickAction = InputSystem.actions.FindAction("Click");
        ghostCount = GameObject.FindGameObjectsWithTag("Ghost").Length;
    }
    private void Update()
    {
        if (ghostNumber != null) { ghostNumber.text = "Ghosts Left: " + ghostCount.ToString(); }
        if (clickAction.WasPressedThisFrame())
        {
            if (Camera.main != null && Mouse.current != null)
            {
                Vector2 mouseWorld = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
                RaycastHit2D hit = Physics2D.Raycast(mouseWorld, Vector2.zero);
                if (hit.collider != null)
                {
                    ToggleSelection(hit.collider.gameObject);
                }
            }
        }

        if (selectedCharacter == null)
        {
            return;
        }

        if (safeAction.WasPressedThisFrame())
        {
            selectedCharacter.GetComponent<SpriteRenderer>().color = new Color(0.69f, 1f, 0.64f);
        }
        if (neutralAction.WasPressedThisFrame())
        {
            selectedCharacter.GetComponent<SpriteRenderer>().color = Color.white;
        }
        if (susAction.WasPressedThisFrame())
        {
            selectedCharacter.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.416f, 0.412f);
        }
        if (lyingAction.WasPressedThisFrame())
        {
            selectedCharacter.GetComponent<SpriteRenderer>().color = new Color(0.996f, 1.0f, 0.573f);
        }
    }

    private void ToggleSelection(GameObject target)
    {
        if (target == selectedCharacter)
        {
            target.GetComponent<SpriteRenderer>().color = Color.white;
            selectedCharacter = null;
            return;
        }

        if (selectedCharacter != null)
        {
            selectedCharacter.GetComponent<SpriteRenderer>().color = Color.white;
        }

        selectedCharacter = target;
        selectedCharacter.GetComponent<SpriteRenderer>().color = selectedColor;
    }

}
