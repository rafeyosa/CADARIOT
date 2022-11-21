using System;
using UnityEngine;
using UnityEngine.UI;

public class LoadUIDataScript : MonoBehaviour {
    public DeviceBehaviour deviceBehaviour;

    public Text Text1;
    public Text Text2;
    public InputField InputField;
    public Button Button;
    void Update() {
        try {
            Text1.text = deviceBehaviour.DeviceData.name;
            Text2.text = deviceBehaviour.DeviceData.description;
        } catch (NullReferenceException ex) {
            Debug.Log(ex.Message);
        }
    }

    public void SetName() {
        var name = InputField.text;
        deviceBehaviour.SetName(name);
    }
}
