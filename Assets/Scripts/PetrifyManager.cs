using UnityEngine;
using UnityEngine.UI;

public class PetrifyManager : MonoBehaviour
{
    public bool isActive = false;
    [SerializeField] private Button petrifyButton;
    void Start()
    {
        
    }
    public void ButtonSelect()
    {
        if (!isActive) { ActivatePetrify(); }
        else { DeactivatePetrify(); }
    }

    void ActivatePetrify()
    {
        isActive = true;
        petrifyButton.GetComponent<Image>().color = Color.red;
    }

    void DeactivatePetrify()
    {
        isActive = false;
        petrifyButton.GetComponent<Image>().color = Color.white;
    }
}
