using UnityEngine;

public class Level1Stage3 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameObject ghost1;
    private GameObject ghost2;
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
}
