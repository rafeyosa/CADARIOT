using System;
using UnityEngine;
using UnityEngine.UI;

public class LoadDataController : MonoBehaviour {
    public DeviceData deviceData;

    public Text TextBucket1;
    public Text TextBucket2;
    public Text TextBucket3;
    public Text TextMotor;
    public Text TextServo1;
    public Text TextServo2;
    int i = 0;
    void Update() {
        try {
            TextBucket1.text = deviceData.Device.container[0].data.value.ToString();
            TextBucket2.text = deviceData.Device.container[1].data.value.ToString();
            TextBucket3.text = deviceData.Device.container[2].data.value.ToString();
            // TextMotor.text = deviceData.Device.actuator[0].data.speed.ToString();
            // TextServo1.text = deviceData.Device.actuator[1].data.degree.ToString();
            // TextServo2.text = deviceData.Device.actuator[2].data.degree.ToString();
        } catch (NullReferenceException ex) {
            // Debug.Log(ex.Message);
        }
    }
    public void setName() {
        deviceData.SetName("Rafeyosa " + i);
        i++;
    }
}
