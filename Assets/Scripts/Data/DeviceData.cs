using UnityEngine;
using UnityEngine.Events;

public class DeviceData : MonoBehaviour {
    [SerializeField]
    private DeviceModel _device;
    public DeviceModel Device => _device;

    public UnityEvent OnDeviceUpdated = new UnityEvent();

    public void UpdateDevice(DeviceModel device) {
        if (device != null) {
            if (!device.Equals(_device)) {
                _device = device;
            }
        }
    }

    public void SetName(string name) {
        if (!string.IsNullOrEmpty(name)) {
            _device.name = name;
            OnDeviceUpdated.Invoke();
        }
    }
}
