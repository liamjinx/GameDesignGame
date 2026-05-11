using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using TMPro;


public class TimerManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI timerTitleText;

    [SerializeField] private TextMeshProUGUI timerExplanationText;
    [SerializeField] private TextMeshProUGUI timerRetryText;

    private float startSeconds = 5f;
    [SerializeField] private UnityEvent onTimerEnd;
    private AudioSource popUpAudio;
    private float remainingSeconds;
    private bool countdownStarted;
    private bool timerEnded;
    private bool timerRunning;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //popUpAudio = GameObject.FindGameObjectWithTag("PopUpAudio").GetComponent<AudioSource>();
        remainingSeconds = startSeconds;
        timerRunning = false;
    }

    void Awake()
    {
        popUpAudio = GameObject.FindGameObjectWithTag("PopUpAudio").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!timerRunning)
        {
            timerText.text = remainingSeconds.ToString("F0") + " Seconds";
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

        onTimerEnd?.Invoke();

        if (timerExplanationText != null)
        {
            popUpAudio.Play();
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

    public void StartTimer()
    {
        remainingSeconds = startSeconds;
        timerEnded = false;
        countdownStarted = false;
        timerRunning = true;
    }

}
