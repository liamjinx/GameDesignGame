using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TimerManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI timerTitleText;

    [SerializeField] private TextMeshProUGUI timerExplanationText;
    [SerializeField] private TextMeshProUGUI timerRetryText;

    [SerializeField] private float startSeconds = 120f;
    [SerializeField] private Level3Stage1 level3Stage1;
    private float remainingSeconds;
    private bool countdownStarted;
    private bool timerEnded;
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

        if (!timerEnded && remainingSeconds <= 0f)
        {
            timerEnd();
        }
        
    }

    void timerEnd()
    {
        timerEnded = true;

        if (level3Stage1 != null)
        {
            level3Stage1.ShowTimerExplanation();
        }

        if (timerExplanationText != null)
        {
            timerTitleText.text = "Game Over";
            timerExplanationText.text = "Time's up! The ghosts have taken over the castle!";
            timerRetryText.text = "Try Again?";
        }

         
    }

    public void RetryLevel()
    {
        if (!timerEnded)
        {
            return;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
