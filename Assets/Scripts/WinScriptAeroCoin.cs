using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class WinScriptAeroCoin : MonoBehaviour
{
  
    public Text ScoreTxtAeroCoin;
    public Text DifTxtAeroCoin;

    public Text ScoreTxtOriginalAeroCoin;
    public Text DifTxtOriginalAeroCoin;

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
    public void WinScreenAeroCoin(bool win)
    {
        ScoreTxtAeroCoin.text = ScoreTxtOriginalAeroCoin.text;

        if (win)
            DifTxtAeroCoin.text = DifTxtOriginalAeroCoin.text;
        else DifTxtAeroCoin.text = "Time:00s";
        CounterAeroCoin(23);
    }

}
