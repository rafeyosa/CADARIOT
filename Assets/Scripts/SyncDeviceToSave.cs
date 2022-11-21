using UnityEngine;

public class SyncDeviceToSave : MonoBehaviour {
    [SerializeField]
    private DeviceSaveManager _deviceSaveManager;
    [SerializeField]
    private DeviceBehaviour _device;

    private void Reset() {
        _deviceSaveManager = FindObjectOfType<DeviceSaveManager>();
    }

    private void Start() {
        _deviceSaveManager.OnDeviceUpdated.AddListener(HandleDeviceSaveUpdated);
        _device.OnDeviceUpdated.AddListener(HandleDeviceUpdated);
        _device.UpdateDevice(_deviceSaveManager.LastDeviceData);
    }

    private void HandleDeviceUpdated() {
        _deviceSaveManager.SaveDevice(_device.DeviceData);
    }

    private void HandleDeviceSaveUpdated(DeviceModel device) {
        _device.UpdateDevice(device);
    }
}
