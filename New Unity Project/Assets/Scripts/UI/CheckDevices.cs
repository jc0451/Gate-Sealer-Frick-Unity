using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDevices : MonoBehaviour{
    // Get list of Microphone devices and print the names to the log
    int nr = 0;
    void Start()
    {
        foreach (var device in Microphone.devices)
        {
            Debug.Log(nr+ "Name: " + device);
            nr++;
        }
    }
}
