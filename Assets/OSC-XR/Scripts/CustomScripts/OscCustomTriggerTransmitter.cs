using UnityEngine;
using VRTK;
using DxR;
using OSCXR;

public class OscCustomTriggerTransmitter : OscPointerTriggerTransmitter
{ 
    public Mark Mark { get; set; }

    private static int counter = 0;

    public void OnEnable()
    {
        controllerID = counter;
        counter++;
        Mark = GetComponent<Mark>();
    }
}
