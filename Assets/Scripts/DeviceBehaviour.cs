using UnityEngine;
using UnityEngine.Events;

public class DeviceBehaviour : MonoBehaviour {
    [SerializeField]
    private DeviceModel _device;
    public DeviceModel DeviceData => _device;

    public UnityEvent OnDeviceUpdated = new UnityEvent();

    public void SetName(string name) {
        if (!string.IsNullOrEmpty(name)) {
            _device.name = name;
            OnDeviceUpdated.Invoke();
        }
    }

    public void UpdateDevice(DeviceModel device) {
        if (device != null) {
            if (!device.Equals(_device)) {
                _device = device;
                OnDeviceUpdated.Invoke();
            }
        }
    }
}
