using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectAeroCoin : MonoBehaviour
{
    public float startingPositionYAeroCoin;
    public float startingPositionXAeroCoin;
    public float speedAeroCoin = 5;
    private bool onceSeenAeroCoin = false;


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
    void Start()
    {
        startingPositionYAeroCoin = transform.localPosition.y;
        CounterAeroCoin(32);
        startingPositionXAeroCoin = transform.localPosition.x;
        ResetAeroCoin();
    }
    
    public void ResetAeroCoin() {
        onceSeenAeroCoin = false;
        CounterAeroCoin(87);
        int sighnAeroCoin = GameObject.Find("GameCanvasAeroCoin").GetComponent<GameLogicAeroCoin>().rAeroCoin.Next(0, 2);
        int spaceXAeroCoin = GameObject.Find("GameCanvasAeroCoin").GetComponent<GameLogicAeroCoin>().rAeroCoin.Next(0, 380);
        int spaceYAeroCoin = GameObject.Find("GameCanvasAeroCoin").GetComponent<GameLogicAeroCoin>().rAeroCoin.Next(50, 550);
        if (sighnAeroCoin == 0) { spaceXAeroCoin *= -1; }
        transform.localPosition = new Vector3(startingPositionXAeroCoin+ spaceXAeroCoin, startingPositionYAeroCoin+spaceYAeroCoin, transform.localPosition.z);
        var tempAeroCoin= GameObject.Find("GameCanvasAeroCoin").GetComponent<GameLogicAeroCoin>().RandomSpriteAeroCoin();
        GetComponent<Image>().sprite = tempAeroCoin.Item1;
        CounterAeroCoin(90);
        speedAeroCoin = GameObject.Find("GameCanvasAeroCoin").GetComponent<GameLogicAeroCoin>().speedAeroCoin;
    }

    bool CheckIfOnScreenAeroCoin()
    {
        Vector3 screenPointAeroCoin = Camera.main.WorldToViewportPoint(transform.position);
        CounterAeroCoin();
        return screenPointAeroCoin.x > 0 && screenPointAeroCoin.x < 1 && screenPointAeroCoin.y > 0 && screenPointAeroCoin.y < 1;
        
    }

    void CollisionCheckAeroCoin()
    {
        Vector3 rocketPosAeroCoin = GameObject.Find("RocketAeroCoin").GetComponent<RocketMoveAeroCoin>().rocketPositionAeroCoin;
        CounterAeroCoin(78);
        if (Math.Abs(transform.localPosition.y - rocketPosAeroCoin.y) <60) {
           if(Math.Abs(rocketPosAeroCoin.x - transform.localPosition.x) < 60)
            {
                ResetAeroCoin();
                GameObject.Find("GameCanvasAeroCoin").GetComponent<GameLogicAeroCoin>().CollisionAeroCoin();
            }
        }

    }

    
    void Update()
    {
        if(GameObject.Find("GameCanvasAeroCoin").GetComponent<Canvas>().enabled==true)
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y-speedAeroCoin, transform.localPosition.z);
        if (CheckIfOnScreenAeroCoin())
        {
            CounterAeroCoin(56);
            onceSeenAeroCoin = true;
        }
        if (onceSeenAeroCoin)
        {
            if(!CheckIfOnScreenAeroCoin()){ ResetAeroCoin(); }
        }
        CounterAeroCoin();
        CollisionCheckAeroCoin();
    }
}
