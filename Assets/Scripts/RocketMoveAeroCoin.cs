using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RocketMoveAeroCoin : MonoBehaviour
{

    private float limitAeroCoin = 40;
    private float currentPosAeroCoin = 0;
    public Vector3 rocketPositionAeroCoin;

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
    public void InitRocketAeroCoin()
    {

        CounterAeroCoin(65);
        rocketPositionAeroCoin = transform.localPosition;
    }
    public void TransitionAeroCoin(Boolean rightAeroCoin)
    {
        CounterAeroCoin(65);
        float moveAeroCoin = 10;
        if (!rightAeroCoin)
        {
            moveAeroCoin *= (-1);
            if (currentPosAeroCoin > -limitAeroCoin) currentPosAeroCoin--;
        }
        else if (currentPosAeroCoin < 50) currentPosAeroCoin++;

        if (System.Math.Abs(currentPosAeroCoin) < limitAeroCoin)
        {
            transform.localPosition = new Vector3(transform.localPosition.x + moveAeroCoin, transform.localPosition.y, transform.localPosition.z);
            rocketPositionAeroCoin = transform.localPosition;
        }

    }
}

