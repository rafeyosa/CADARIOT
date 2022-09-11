using UnityEngine;
using UnityEngine.Events;

public class DeviceBehaviour : MonoBehaviour {
    [SerializeField]
    private DeviceData _deviceData;
    public DeviceData DeviceData => _deviceData;
    public string Name => _deviceData.name;
    public string Color => _deviceData.color;

    public UnityEvent OnDeviceUpdated = new UnityEvent();

    public void UpdateDevice(DeviceData deviceData) {
        if (!deviceData.Equals(_deviceData)) {
            _deviceData = deviceData;
            OnDeviceUpdated.Invoke();
        }
    }
}
