using UnityEngine;

public class PetrifyManager : MonoBehaviour
{
    public bool isActive = false;
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
        Debug.Log("active");
    }

    void DeactivatePetrify()
    {
        isActive = false;
        Debug.Log("inactive");
    }
}
