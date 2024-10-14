using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogicAeroCoin : MonoBehaviour
{

    public Sprite sprite1AeroCoin;
 
 

    public System.Random rAeroCoin = new System.Random();
    public int speedAeroCoin;


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

    public Text scoreTextAeroCoin;
    private int currentScoreAeroCoin = 0;
    private int goalAeroCoin;
    public int currentDifAeroCoin = 0;


    public void StartGameAeroCoin(int difAeroCoin)
    {
        currentScoreAeroCoin = 0;
        GetComponent<TimerScriptAeroCoin>().RefreshTimerAeroCoin();
        
        GameObject.Find("RocketAeroCoin").GetComponent<RocketMoveAeroCoin>().InitRocketAeroCoin();
        CounterAeroCoin();
        for (int iAeroCoin = 1; iAeroCoin < 11; iAeroCoin++)
        {
            GameObject.Find("AeroCoin" + iAeroCoin).GetComponent<ObjectAeroCoin>().ResetAeroCoin();
        }
        CounterAeroCoin();
        goalAeroCoin = (difAeroCoin * 10) + 50;
        CounterAeroCoin();
        scoreTextAeroCoin.text = "Score " + currentScoreAeroCoin + "/" + goalAeroCoin;
        

    }
    public void CollisionAeroCoin()
    {
            CounterAeroCoin();
            currentScoreAeroCoin += 5;
            scoreTextAeroCoin.text = "Score " + currentScoreAeroCoin + "/" + goalAeroCoin;
            GameObject.Find("MainCameraAeroCoin").GetComponent<SoundManagerAeroCoin>().PlayPingAeroCoin();
            if (currentScoreAeroCoin>= goalAeroCoin)
            {
                GetComponent<JumpCanvasAeroCoin>().JumpAeroCoin("winAeroCoin");
            }

    }


    public Tuple<Sprite, bool> RandomSpriteAeroCoin()
    {
     
        return Tuple.Create(sprite1AeroCoin, true);
    }

}
