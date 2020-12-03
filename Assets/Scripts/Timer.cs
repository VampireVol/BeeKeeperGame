using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    public Text timerText;

    [SerializeField]
    float time;
    private bool isRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        isRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            if (time > 0)
            {
                int hours = Mathf.FloorToInt(time / 3600);
                int min = Mathf.FloorToInt((time % 3600) / 60);
                int sec = Mathf.FloorToInt((time % 3600) % 60);
                timerText.text = $"{hours:00}:{min:00}:{sec:00}";
                time -= Time.deltaTime;
            }
            else
            {
                timerText.text = $"00:00:00";
                isRunning = false;
            }
        }
    }

    void SetTimer(float seconds)
    {
        isRunning = true;
        time = seconds;
    }
}
