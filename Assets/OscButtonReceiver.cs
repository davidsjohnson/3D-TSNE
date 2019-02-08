using UnityEngine;
using UnityEngine.UI;
using UnityOSC;

public class OscButtonReceiver : MonoBehaviour
{

    private Text text;

    private void OnEnable()
    {
        text = GetComponentInChildren<Text>();
    }

    public void PressedHandler(OSCMessage message)
    {
        text.text = "Processing";
    }

    public void DoneHandler(OSCMessage message)
    {
        text.text = "Update Vis";
    }
}
