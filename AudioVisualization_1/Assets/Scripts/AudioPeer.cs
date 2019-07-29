﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class AudioPeer : MonoBehaviour
{

    AudioSource thisAudio;
    public static float[] samples = new float[512];
    public static float[] freqband = new float[8];
    public static float[] buffer = new float[8];
    float[] bufferDecrease = new float[8];

    // Start is called before the first frame update
    void Start()
    {
        thisAudio = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        GetSpectrumAudioSource();
        FrequencyBands();
        BandBuffer();
    }

    void GetSpectrumAudioSource()
    {
        thisAudio.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }

    void BandBuffer()
    {
        for (int g = 0; g < 8; g++)
        {
            if (freqband [g] > buffer [g])
            {
                buffer[g] = freqband[g];
                bufferDecrease[g] = 0.005f;
            }

            if (freqband[g] < buffer[g])
            {
                buffer[g] -= bufferDecrease [g];
                bufferDecrease[g] *= 1.2f;
            }

        }

    }

    void FrequencyBands()
    {
        int count = 0;

        for (int i = 0; i < 8; i++)
        {

            float average = 0;
            int samplecount = (int)Mathf.Pow(2, i) * 2;
            
            if (i == 7)
            {
                samplecount += 2;
            }

            for (int j = 0; j < samplecount; j++)
            {
                average += samples[count] * (count + 1);
                count++;
            }

            average /= count;

            freqband[i] = average * 10;


        }



    }


}
