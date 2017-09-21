using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class STimer : MonoBehaviour
{
    public float fTimer;        // 타이머 시간
    int nTime;
    int nSeconds;
    float fMillisecond;
    public Text TimerText = null;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!SGameMng.I.bPause)
        {
            Timer();
        }
    }

    void Timer()
    {
        if (fTimer > 0)
        {
            fTimer -= Time.deltaTime;
            nTime = (int)fTimer;
            nSeconds = nTime % 60;
            fMillisecond = fTimer * 100;
            fMillisecond = (fMillisecond % 100);
            TimerText.text = string.Format("{0:0}:{1:00}", nSeconds, fMillisecond);
        }
        if (fTimer <= 0)
        {
            TimerText.text = string.Format("{0:0}:{1:00}", 0, 0);
        }
    }
}
