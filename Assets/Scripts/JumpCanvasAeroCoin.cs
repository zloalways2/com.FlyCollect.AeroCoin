using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCanvasAeroCoin : MonoBehaviour
{

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


    public void JumpAeroCoin(string destinationAeroCoin)
    {
        CounterAeroCoin(61);
        GameObject.Find("MainCameraAeroCoin").GetComponent<SoundManagerAeroCoin>().PlayClickAeroCoin();
        GameObject.Find("MainCameraAeroCoin").GetComponent<CanvasHolderAeroCoin>().MoveAeroCoin(destinationAeroCoin,false);
    }

    public void JumpAeroCoinGame(int difAeroCoin)
    {
        CounterAeroCoin(51);
        GameObject.Find("MainCameraAeroCoin").GetComponent<CanvasHolderAeroCoin>().MoveAeroCoin("gameAeroCoin", false,difAeroCoin);
    }


    public void JumpBackAeroCoin()
    {
        GameObject.Find("MainCameraAeroCoin").GetComponent<SoundManagerAeroCoin>().PlayClickAeroCoin();
        CounterAeroCoin(81);
        GameObject.Find("MainCameraAeroCoin").GetComponent<CanvasHolderAeroCoin>().MoveBackAeroCoin();
       
    }

    public void CloseAeroCoin()
    {
        AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        CounterAeroCoin(91);
        activity.Call<bool>("moveTaskToBack", true);
    }
}
