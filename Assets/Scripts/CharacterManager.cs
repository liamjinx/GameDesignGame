using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool isActive = false;
    private GameObject ghost1;
    private GameObject ghost2;
    void Awake()
    {
        int ghostnumber1 = Random.Range(0, 5);
        int ghostnumber2 = Random.Range(0, 5);
        while (ghostnumber1 == ghostnumber2)
        {
            ghostnumber2 = Random.Range(0, 5);
        }
        ghost1 = gameObject.transform.GetChild(ghostnumber1).gameObject;
        ghost2 = gameObject.transform.GetChild(ghostnumber2).gameObject;
        ghost1.tag = "Ghost";
        ghost2.tag = "Ghost";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
