using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mike : MonoBehaviour {
   
    public static float Mic1Loudness;

    [SerializeField]
    public float loudness;
    private int devicenr;



    private string _device;
    int nr = 0;
    int dnr;


    //mic initialization
    void InitMic()
    {
        foreach (var device in Microphone.devices)
        {
            Debug.Log(nr + "Name: " + device);

            if (device == "VoiceMeeter Output (VB-Audio VoiceMeeter VAIO)")
            {

                dnr = nr;
            }


            nr++;
        }
        if (_device == null) _device = Microphone.devices[dnr];
        _clipRecord = Microphone.Start(_device, true, 999, 44100);
    }
   

    void StopMicrophone()
    {
        Microphone.End(_device);
    }


    AudioClip _clipRecord = new AudioClip();
    int _sampleWindow = 128;

    //get data from microphone into audioclip
    float LevelMax()
    {
        float levelMax = 0;
        float[] waveData = new float[_sampleWindow];
        int micPosition = Microphone.GetPosition(_device) - (_sampleWindow + 1); 
        if (micPosition < 0) return 0;
        _clipRecord.GetData(waveData, micPosition);
        // Getting a peak on the last 128 samples
        for (int i = 0; i < _sampleWindow; i++)
        {
            float wavePeak = waveData[i] * waveData[i];
            if (levelMax < wavePeak)
            {
                levelMax = wavePeak;
            }
        }
        return levelMax;
    }



    void Update()
    {
        // levelMax equals to the highest normalized value power 2, a small number because < 1
        // pass the value to a static var so we can access it from anywhere

            Mic1Loudness = LevelMax();
            loudness = LevelMax();
       
       
    }

    bool _isInitialized;
    // start mic when scene starts
    void OnEnable()
    {
        InitMic();
        _isInitialized = true;
    }

    //stop mic when loading a new level or quit application
    void OnDisable()
    {
        StopMicrophone();
    }

    void OnDestroy()
    {
        StopMicrophone();
    }


    // make sure the mic gets started & stopped when application gets focused
    void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            Debug.Log("Focus");

            if (!_isInitialized)
            {
                Debug.Log("Init Mic");
                InitMic();
                _isInitialized = true;
            }
        }
        if (!focus)
        {
            Debug.Log("Pause");
            StopMicrophone();
            Debug.Log("Stop Mic");
            _isInitialized = false;

        }
    }
}

