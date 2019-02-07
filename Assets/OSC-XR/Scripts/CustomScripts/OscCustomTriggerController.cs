using UnityEngine;
using VRTK;
using DxR;
using OSCXR;

public class OscCustomTriggerController : BaseOscTransmitter
{

    [Header("Trigger Pointers")]
    [Tooltip("Pointer to Trigger the Object (one of right hand or left hand must be populated)")]
    public VRTK_DestinationMarker leftHandPointer;
    [Tooltip("Pointer to Trigger the Object (one of right hand or left hand must be populated)")]
    public VRTK_DestinationMarker rightHandPointer;

    public static int counter = 0;

    public Mark mark;

    public void OnEnable()
    {
        controllerID = counter;
        counter++;
        mark = GetComponent<Mark>();
    }

    public void Start()
    { 
        oscAddress = string.IsNullOrEmpty(oscAddress) ? "/trigger" : oscAddress;
    }
}
