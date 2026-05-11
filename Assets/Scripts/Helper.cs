using UnityEngine;

public class Helper : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var stage2 = GetComponent<Level3Stage2>();
        var stage3 = GetComponent<Level3Stage3>();
        var stage4 = GetComponent<Level3Stage4>();

        if (stage2 != null)
        {
            stage2.enabled = true;
        }
        if (stage3 != null)
        {
            stage3.enabled = true;
        }
        if (stage4 != null)
        {
            stage4.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
