using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtomMovementAeroCoin : MonoBehaviour, IUpdateSelectedHandler, IPointerDownHandler, IPointerUpHandler
{
    public bool rightAeroCoin;
    public bool isPressedAeroCoin;

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
    public void OnUpdateSelected(BaseEventData data)
    {
        if (isPressedAeroCoin)
        {          
            OnClickAeroCoin();
        }
    }
    public void OnPointerDown(PointerEventData data)
    {
        isPressedAeroCoin = true;
        CounterAeroCoin(23);
    }
    public void OnPointerUp(PointerEventData data)
    {
        CounterAeroCoin(76);
        isPressedAeroCoin = false;
    }
    public void OnClickAeroCoin()
    {
            GameObject.Find("RocketAeroCoin").GetComponent<RocketMoveAeroCoin>().TransitionAeroCoin(rightAeroCoin);    
    }
}
