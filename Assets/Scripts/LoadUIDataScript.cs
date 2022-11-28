using System;
using UnityEngine;
using UnityEngine.UI;

public class LoadUIDataScript : MonoBehaviour {
    public DeviceBehaviour deviceBehaviour;

    public Text TextBucket1;
    public Text TextBucket2;
    public Text TextBucket3;
    public Text TextMotor;
    public Text TextServo1;
    public Text TextServo2;
    int i = 0;
    void Update() {
        try {
            TextBucket1.text = deviceBehaviour.DeviceData.container[0].data.value.ToString();
            TextBucket2.text = deviceBehaviour.DeviceData.container[1].data.value.ToString();
            TextBucket3.text = deviceBehaviour.DeviceData.container[2].data.value.ToString();
            TextMotor.text = deviceBehaviour.DeviceData.actuator[0].data.speed.ToString();
            TextServo1.text = deviceBehaviour.DeviceData.actuator[1].data.degree.ToString();
            TextServo2.text = deviceBehaviour.DeviceData.actuator[2].data.degree.ToString();
        } catch (NullReferenceException ex) {
            Debug.Log(ex.Message);
        }
    }
    public void setName() {
        deviceBehaviour.SetName("Rafeyosa " + i);
        i++;
    }
}
