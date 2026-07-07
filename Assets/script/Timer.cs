using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float remainingTime = 60f;

    public GameObject gameOverPanel;

    private bool timerStarted = false;
    private bool timerStopped = false;

    void Start()
    {
        UpdateTimerUI();
    }

    void Update()
    {
        if (timerStarted && !timerStopped)
        {
            remainingTime -= Time.deltaTime;

            if (remainingTime <= 0)
            {
                remainingTime = 0;
                timerStopped = true;

                // Tampilkan Game Over
                gameOverPanel.SetActive(true);

                // Pause game
                Time.timeScale = 0f;
            }

            UpdateTimerUI();
        }
    }

    public void StartTimer()
    {
        timerStarted = true;
    }

    public void StopTimer()
    {
        timerStopped = true;
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            StopTimer();
        }
    }
}