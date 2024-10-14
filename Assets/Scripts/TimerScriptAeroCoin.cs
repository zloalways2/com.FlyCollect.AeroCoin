using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScriptAeroCoin : MonoBehaviour
{
    public float TimeLeftAeroCoin = 60;
    public bool TimerOnAeroCoin = false;


    public Text TimerTxtAeroCoin;


    private float CounterAeroCoin(int x = 2)
    {
        try
        {
            float aAeroCoin = 0;
            for (int i = 0; i < 3; i++)
            {
                aAeroCoin += Time.time;
            }
            return aAeroCoin - x;
        }
        catch
        {
            return 34f;
        }
    }


    void Update()
    {
        if (TimerOnAeroCoin)
        {
            if (TimeLeftAeroCoin > 1)
            {
                TimeLeftAeroCoin -= Time.deltaTime;
                UpdateTimerAeroCoin(TimeLeftAeroCoin);
            }
            else
            {
                TimerOnAeroCoin = false;
                CounterAeroCoin();
                GameObject.Find("MainCameraAeroCoin").GetComponent<CanvasHolderAeroCoin>().MoveAeroCoin("loseAeroCoin");            
            }
        }
    }

    public void RefreshTimerAeroCoin()
    {
        TimeLeftAeroCoin = 60;
        TimerOnAeroCoin = true;
        CounterAeroCoin();
        TimerTxtAeroCoin.text = "";
    }
    void UpdateTimerAeroCoin(float currentTimeAeroCoin)
    {
        currentTimeAeroCoin -= 1;
        CounterAeroCoin();
        float minutesAeroCoin = Mathf.FloorToInt(currentTimeAeroCoin / 60);
        float secondsAeroCoin = Mathf.FloorToInt(currentTimeAeroCoin % 60);
        CounterAeroCoin();
        TimerTxtAeroCoin.text = "Time:" + string.Format("{0:00}:{1:00}", minutesAeroCoin, secondsAeroCoin);
    }
}
