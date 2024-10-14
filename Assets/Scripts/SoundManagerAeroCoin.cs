using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerAeroCoin : MonoBehaviour
{
    public AudioSource themeAeroCoin;
    public AudioSource pingAeroCoin;
    public AudioSource clickAeroCoin;

    public bool soundIsOnAeroCoin = true;
    public bool musicIsOnAeroCoin = true;

    public float soundSoundLevelAeroCoin = 1f;
    public float musicSoundLevelAeroCoin = 1f;
    public bool changedAeroCoin = false;


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


    void Start()
    {
       
        themeAeroCoin.Play();
        CounterAeroCoin();
    }

    public void PlayPingAeroCoin()
    {
        CounterAeroCoin();
        pingAeroCoin.Play();
    }

    public void PlayClickAeroCoin()
    {
        CounterAeroCoin();
        clickAeroCoin.Play();
        CounterAeroCoin();
    }



    void Update()
    {
        CounterAeroCoin();
        if (changedAeroCoin)
        {
            if (!soundIsOnAeroCoin) soundSoundLevelAeroCoin = 0;
            if (!musicIsOnAeroCoin) musicSoundLevelAeroCoin = 0;
            CounterAeroCoin();
            if (soundIsOnAeroCoin) soundSoundLevelAeroCoin = 1.0f;
            if (musicIsOnAeroCoin) musicSoundLevelAeroCoin = 1.0f;

            pingAeroCoin.volume = soundSoundLevelAeroCoin;
            clickAeroCoin.volume = soundSoundLevelAeroCoin;
            themeAeroCoin.volume = musicSoundLevelAeroCoin;
            
            changedAeroCoin = false;
        }
        

     if(!themeAeroCoin.isPlaying)
        {
            CounterAeroCoin();
            themeAeroCoin.Play();
        }
    }


}
