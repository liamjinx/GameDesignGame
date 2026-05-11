using UnityEngine;
using TMPro;
using System.Linq;

public class LostManager : MonoBehaviour
{
    [SerializeField] private GameObject lostScreen;
    [SerializeField] private  TextMeshProUGUI Title;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var ghosts = GameObject.FindGameObjectsWithTag("Ghost");
        var ghostNames = ghosts.Select(g => g.name);
        if (ghostNames.Count() == 1)
        {
        Title.text = "Oh no!\nThat was one of the kingdom's innocent subjects!! \nThe ghost was: " + string.Join(", ", ghostNames);
            return;
        } else {
        Title.text = "Oh no!\nThat was one of the kingdom's innocent subjects!! \nThe ghosts were: " + string.Join(", ", ghostNames);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
