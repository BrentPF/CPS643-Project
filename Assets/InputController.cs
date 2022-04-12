using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class InputController : MonoBehaviour
{
    public GameObject rightControllerObject;
    public GameObject leftControllerObject;
    private InputDevice rightController;
    private InputDevice leftController;
    public bool triggerRPressed = false;
    public bool triggerLPressed = false;
    public bool gripRPressed = false;
    public bool gripLPressed = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("START");
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics controllerDeviceCharacteristics = InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(controllerDeviceCharacteristics, devices);
        Debug.Log("FOUND DEVICES: " + devices.Count);
        foreach (InputDevice device in devices)
        {
            Debug.Log(device.characteristics);
            if ((device.characteristics & InputDeviceCharacteristics.Right) == InputDeviceCharacteristics.Right)
            {
                Debug.Log("FOUND RIGHT");
                rightController = device;
            }
            else if ((device.characteristics & InputDeviceCharacteristics.Left) == InputDeviceCharacteristics.Left)
            {
                Debug.Log("FOUND LEFT");
                leftController = device;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Right controller
        rightController.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerR);
        if (triggerR)
        {
            triggerRPressed = true;
            Debug.Log("right trigger");
        }
        else
        {
            triggerRPressed = false;
        }
        rightController.TryGetFeatureValue(CommonUsages.gripButton, out bool gripR);
        if (gripR)
        {
            gripRPressed = true;
            Debug.Log("right grip");
        }
        else
        {
            gripRPressed = false;
        }
        // Left controller
        leftController.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerL);
        if (triggerL)
        {
            triggerLPressed = true;
            Debug.Log("left trigger");
        }
        else
        {
            triggerLPressed = false;
        }
        rightController.TryGetFeatureValue(CommonUsages.gripButton, out bool gripL);
        if (gripL)
        {
            gripLPressed = true;
            Debug.Log("left grip");
        }
        else
        {
            gripLPressed = false;
        }

    }
}
