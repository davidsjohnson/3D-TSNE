using UnityEngine;
using UnityOSC;
using DxR;

public class OscTsneReceiver : MonoBehaviour
{
    private Vis vis;

    private float prevValueScale = 0f;
    private float prevValueX = 0;
    private float prevValueY = 0;
    private float prevValueZ = 0;

    private float prevValueRotX = 0;
    private float prevValueRotY = 0;
    private float prevValueRotZ = 0;

    private void Start()
    {
        vis = GetComponent<Vis>();

        //Register OSC Listeners
        OscReceiverManager.ReceiverManager.RegisterOscAddress("/zoomslider/value", OscZoomVis);
        OscReceiverManager.ReceiverManager.RegisterOscAddress("/rotationslider/x/value", OscRotateX);
        OscReceiverManager.ReceiverManager.RegisterOscAddress("/rotationslider/y/value", OscRotateY);
        OscReceiverManager.ReceiverManager.RegisterOscAddress("/rotationslider/z/value", OscRotateZ);
        OscReceiverManager.ReceiverManager.RegisterOscAddress("/rotationgrid/values", OscRotateXYZ);
    }

    public void OscReceivedHandler(OSCMessage message)
    {
        Debug.Log("T-SNE Processed");
        vis.UpdateVisSpecsFromTextSpecs();
    }

    public void OscZoomVis(OSCMessage message)
    {
        int id = (int)message.Data[0];
        float value = (float)message.Data[1];

        if (value > prevValueScale)
        { vis.Rescale(1.10f); }
        else if (value < prevValueScale)
        { vis.Rescale(.909f); }
           
        prevValueScale = value;
    }

    public void OscRotateX(OSCMessage message)
    {
        int id = (int)message.Data[0];
        float value = (float)message.Data[1];

        if (value > prevValueX)
        { vis.RotateAroundCenter(Vector3.right, -15); }
        else if (value < prevValueX)
        { vis.RotateAroundCenter(Vector3.right, 15); }

        prevValueX = value;
    }

    public void OscRotateY(OSCMessage message)
    {
        int id = (int)message.Data[0];
        float value = (float)message.Data[1];

        if (value > prevValueY)
        { vis.RotateAroundCenter(Vector3.up, -15); }
        else if (value < prevValueY)
        { vis.RotateAroundCenter(Vector3.up, 15); }

        prevValueY = value;
    }

    public void OscRotateZ(OSCMessage message)
    {
        int id = (int)message.Data[0];
        float value = (float)message.Data[1];

        if (value > prevValueZ)
        { vis.RotateAroundCenter(Vector3.forward, -15); }
        else if (value < prevValueZ)
        { vis.RotateAroundCenter(Vector3.forward, 15); }

        prevValueZ = value;
    }

    public void OscRotateXYZ(OSCMessage message)
    {
        int id = (int)message.Data[0];
        float x = (float)message.Data[1];
        float y = (float)message.Data[2];
        float z = (float)message.Data[3];

        if (x > prevValueRotX)
        { vis.RotateAroundCenter(Vector3.right, -15); }
        else if (x < prevValueRotX)
        { vis.RotateAroundCenter(Vector3.right, 15); }

        if (y > prevValueRotY)
        { vis.RotateAroundCenter(Vector3.up, -15); }
        else if (y < prevValueRotY)
        { vis.RotateAroundCenter(Vector3.up, 15); }

        if (z > prevValueRotZ)
        { vis.RotateAroundCenter(Vector3.forward, -15); }
        else if (z < prevValueRotZ)
        { vis.RotateAroundCenter(Vector3.forward, 15); }

        prevValueRotX = x;
        prevValueRotY = y;
        prevValueRotZ = z;
    }
}
