using UnityEngine;

public class PetrifyManager : MonoBehaviour
{
    public bool isActive = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
