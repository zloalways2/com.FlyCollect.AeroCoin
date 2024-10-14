using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScriptAeroCoin : MonoBehaviour
{

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

    public void ActivateButtonsAeroCoin()
    {

        for (int iAeroCoin = 2; iAeroCoin < GameObject.Find("MainCameraAeroCoin").GetComponent<CanvasHolderAeroCoin>().levelsAeroCoin+1; iAeroCoin++)
        {
            CounterAeroCoin(32);
            GameObject.Find("PlayButtonAeroCoin" + iAeroCoin).GetComponent<Button>().interactable = true;
        }


    }


}
