using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSoundsAeroCoin : MonoBehaviour
{
    public Sprite onAeroCoin;
    public Sprite offAeroCoin;
    public bool isSoundAeroCoin;
    public bool isOnAeroCoin=true;

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
    public void onClickAeroCoin()
    {
        isOnAeroCoin=!isOnAeroCoin;
        CounterAeroCoin(49);
        if (isSoundAeroCoin) GameObject.Find("MainCameraAeroCoin").GetComponent<SoundManagerAeroCoin>().soundIsOnAeroCoin = isOnAeroCoin;
        else GameObject.Find("MainCameraAeroCoin").GetComponent<SoundManagerAeroCoin>().musicIsOnAeroCoin = isOnAeroCoin;
        GameObject.Find("MainCameraAeroCoin").GetComponent<SoundManagerAeroCoin>().changedAeroCoin = true;
        if (isOnAeroCoin) GetComponent<Image>().sprite = onAeroCoin;
        else GetComponent<Image>().sprite = offAeroCoin;



    }
}
