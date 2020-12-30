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

    private System.DateTime timeEnd;

    public bool isRunning()
    {
        return (timeEnd - System.DateTime.Now).TotalSeconds > 0;
    }

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning())
        {
            int timeLeft = (int)(timeEnd - System.DateTime.Now).TotalSeconds;
            int hours = Mathf.FloorToInt(timeLeft / 3600);
            int min = Mathf.FloorToInt((timeLeft % 3600) / 60);
            int sec = Mathf.FloorToInt((timeLeft % 3600) % 60);
            //Debug.Log((timeEnd - System.DateTime.Now).ToString("HH:mm:ss"));
            //Debug.Log((timeEnd - System.DateTime.Now));
            timerText.text = $"{hours:00}:{min:00}:{sec:00}";
            //time -= Time.deltaTime;
        }
        else
        {
            timerText.text = "00:00:00";
        }

    }

    public void SetTimer(float seconds)
    {
        timeEnd = System.DateTime.Now;
        timeEnd = timeEnd.AddSeconds(seconds);
        Debug.Log(System.DateTime.Now.Second - timeEnd.Second);
        time = seconds;
    }
}
