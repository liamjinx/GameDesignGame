using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float startSeconds = 90f;
    private float remainingSeconds;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        remainingSeconds = startSeconds;
    }

    // Update is called once per frame
    void Update()
    {
        if (remainingSeconds > 0f)
        {
            remainingSeconds -= Time.deltaTime;
            if (remainingSeconds < 0f)
            {
                remainingSeconds = 0f;
            }
        }

        if (timerText != null)
        {
            timerText.text = remainingSeconds.ToString("F0") + " Seconds";
        }
        
    }
}
