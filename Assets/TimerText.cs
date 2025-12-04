using UnityEngine;
using TMPro;

public class TimerText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;

    private float timeElapsed = 0f;
    private bool timerRunning = true;

    private void Update()
    {
        if (!timerRunning) return;

        timeElapsed += Time.deltaTime;

        int minutes = Mathf.FloorToInt(timeElapsed / 60);
        int seconds = Mathf.FloorToInt(timeElapsed % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void StopTimer()
    {
        timerRunning = false;
    }

    public float GetTime()
    {
        return timeElapsed;
    }
}
