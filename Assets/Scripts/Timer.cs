using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] public Image timeoutPanel; 
    private float totalTime = 30f;
    private float currentTime = 0f;
    private bool timerActive = true;

    void Start()
    {
        currentTime = totalTime;
    }

    void Update()
    {
        if (timerActive)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0f)
            {
                currentTime = 0f;
                timerActive = false;
                EndGame();
            }

            UpdateTimerDisplay();
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    
    private void EndGame()
    {
        Time.timeScale = 0f;
        timeoutPanel.gameObject.SetActive(true);
    }
}
