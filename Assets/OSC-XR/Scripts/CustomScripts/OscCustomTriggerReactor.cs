using UnityEngine;
using VRTK;
using OSCXR;

public class OscCustomTriggerReactor : OscPointerTriggerReactor
{
    public OscCustomTriggerTransmitter customTrigger;

    public override void DestinationMarkerEnter(object sender, DestinationMarkerEventArgs e)
    {
        Debug.Log(string.Format("Fpath: {0}", customTrigger.Mark.datum["fpath"]));
        oscTriggerTest.SendOSCMessage(string.Format("{0}/enter", oscTriggerTest.oscAddress), customTrigger.Mark.datum["fpath"]);
    }

    public override void DestinationMarkerHover(object sender, DestinationMarkerEventArgs e)
    {
        //oscTrigger.SendOSCMessage(string.Format("{0}/hover", oscTrigger.oscAddress), oscTrigger.mark.datum["fpath"]);
    }

    public override void DestinationMarkerExit(object sender, DestinationMarkerEventArgs e)
    {
        oscTriggerTest.SendOSCMessage(string.Format("{0}/exit", oscTriggerTest.oscAddress), customTrigger.Mark.datum["fpath"]);
    }

    public override void DestinationMarkerSet(object sender, DestinationMarkerEventArgs e)
    {
        oscTriggerTest.SendOSCMessage(string.Format("{0}/selected", oscTriggerTest.oscAddress), customTrigger.Mark.datum["fpath"]);
    }

    protected override void DebugLogger(uint index, string action, Transform target, RaycastHit raycastHit, float distance, Vector3 tipPosition)
    {
        string targetName = (target ? target.name : "<NO VALID TARGET>");
        string colliderName = (raycastHit.collider ? raycastHit.collider.name : "<NO VALID COLLIDER>");
        VRTK_Logger.Info("Controller on index '" + index + "' is " + action + " at a distance of " + distance + " on object named [" + targetName + "] on the collider named [" + colliderName + "] - the pointer tip position is/was: " + tipPosition);
    }
}