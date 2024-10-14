using System;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;


public class CanvasHolderAeroCoin : MonoBehaviour
{
    public Canvas loadingCanvasAeroCoin;
    public Canvas menuCanvasAeroCoin;
    public Canvas settingsCanvasAeroCoin;
    public Canvas rulesCanvasAeroCoin;
    public Canvas gameCanvasAeroCoin;
    public Canvas winCanvasAeroCoin;
    public Canvas loseCanvasAeroCoin;
    public Canvas levelChoiceCanvasAeroCoin;


    private float CounterAeroCoin(int x = 5)
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


    public bool activeAeroCoin = true;

    Timer tAeroCoin;

    public Stack<string> currentStackAeroCoin;
    public int levelsAeroCoin = 2;

    void Start()
    {    
        menuCanvasAeroCoin.enabled = false; 
        settingsCanvasAeroCoin.enabled = false;
        rulesCanvasAeroCoin.enabled = false;
         CounterAeroCoin();
        gameCanvasAeroCoin.enabled = false;
        winCanvasAeroCoin.enabled = false;
        levelChoiceCanvasAeroCoin.enabled = false;
         CounterAeroCoin(56);
        loseCanvasAeroCoin.enabled = false;
        currentStackAeroCoin = new Stack<string>();
        currentStackAeroCoin.Push("menuAeroCoin");

        HideTimerAeroCoin();
    }

 
    public void EndLoadAeroCoin()
    {
        CounterAeroCoin();
        loadingCanvasAeroCoin.enabled = false;
        menuCanvasAeroCoin.enabled = true;
    }




    public void HideTimerAeroCoin()
    {
        tAeroCoin = new Timer(1500);
        tAeroCoin.AutoReset = false;
        CounterAeroCoin();
        tAeroCoin.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        tAeroCoin.Start();

    }
    private async void OnTimedEvent(object? sender, ElapsedEventArgs e)
    {
       
        try
        {
             CounterAeroCoin();
            EndLoadAeroCoin();
        }
        finally
        {
             CounterAeroCoin();
            tAeroCoin.Enabled = false;
        }
    }

    public void MoveBackAeroCoin()
    {
        currentStackAeroCoin.Pop();
         CounterAeroCoin();
        MoveAeroCoin(currentStackAeroCoin.Peek(), true);
    }
    public void MoveAeroCoin(string destinationAeroCoin, bool backmoveAeroCoin = false, int difAeroCoin =0)
    {

        menuCanvasAeroCoin.enabled = false;
        settingsCanvasAeroCoin.enabled = false;
         CounterAeroCoin();
        rulesCanvasAeroCoin.enabled = false;
        gameCanvasAeroCoin.enabled = false;
        loseCanvasAeroCoin.enabled = false;
        winCanvasAeroCoin.enabled = false;
        levelChoiceCanvasAeroCoin.enabled = false;

        if (destinationAeroCoin == "winAeroCoin")
        {
            if (!backmoveAeroCoin&&levelsAeroCoin<10) levelsAeroCoin++;
            winCanvasAeroCoin.enabled = true;
            CounterAeroCoin(72);
            winCanvasAeroCoin.GetComponent<WinScriptAeroCoin>().WinScreenAeroCoin(true);
           backmoveAeroCoin = true;
        }

        if (destinationAeroCoin == "loseAeroCoin")
        {
            loseCanvasAeroCoin.enabled = true;
            loseCanvasAeroCoin.GetComponent<WinScriptAeroCoin>().WinScreenAeroCoin(false);
            backmoveAeroCoin = true;
        }


         CounterAeroCoin();

        if (destinationAeroCoin == "menuAeroCoin")
        {
            menuCanvasAeroCoin.enabled = true;
            activeAeroCoin = false;
        }
        else if (destinationAeroCoin == "settingsAeroCoin")
        {
            settingsCanvasAeroCoin.enabled = true;
        }
        else if (destinationAeroCoin == "levelsAeroCoin")
        {   
            levelChoiceCanvasAeroCoin.GetComponent<LevelScriptAeroCoin>().ActivateButtonsAeroCoin();
            levelChoiceCanvasAeroCoin.enabled = true;
        }
        else if (destinationAeroCoin == "gameAeroCoin")
        {
             CounterAeroCoin();
            gameCanvasAeroCoin.enabled = true;
            if (!backmoveAeroCoin) 
                gameCanvasAeroCoin.GetComponent<GameLogicAeroCoin>().StartGameAeroCoin(difAeroCoin);
        }
        else if (destinationAeroCoin == "exitAeroCoin")
        {
            CounterAeroCoin(39);
            rulesCanvasAeroCoin.enabled = true;
        }
        if (!backmoveAeroCoin) { currentStackAeroCoin.Push(destinationAeroCoin); }
         CounterAeroCoin();
     
    }

    void Update()
    {



        if (Application.platform == RuntimePlatform.Android)
        {
            try
            {
                if (Input.GetKey(KeyCode.Escape))
                {
                    if (currentStackAeroCoin.Count == 1)
                    {
                         CounterAeroCoin();
                        AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
                        activity.Call<bool>("moveTaskToBack", true);
                    }
                    else
                    {
                        MoveBackAeroCoin();
                    }

                }
            }
            catch (Exception eAeroCoin)
            {

            }
        }
    }


}
