using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float startSeconds = 120f;
    private float remainingSeconds;
    private bool countdownStarted;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        remainingSeconds = startSeconds;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerText == null || !timerText.gameObject.activeInHierarchy)
        {
            return;
        }

        if (!countdownStarted)
        {
            countdownStarted = true;
        }

        if (remainingSeconds > 0f)
        {
            remainingSeconds -= Time.deltaTime;
            if (remainingSeconds < 0f)
            {
                remainingSeconds = 0f;
            }
        }

        timerText.text = remainingSeconds.ToString("F0") + " Seconds";
        
    }
}
