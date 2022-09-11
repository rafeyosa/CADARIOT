using UnityEngine;
using UnityEngine.UI;

public class LoadUIDataScript : MonoBehaviour {
    public DeviceBehaviour device;

    public Text Text1;
    public Text Text2;
    public InputField InputField;
    public Button Button;
    void Update() {
        Text1.text = device.DeviceData.name;
        Text2.text = device.DeviceData.color;
    }

    public void SetName() {
        var name = InputField.text;
        device.SetName(name);
    }
}
