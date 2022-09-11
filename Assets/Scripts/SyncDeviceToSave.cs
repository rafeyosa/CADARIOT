using System.Collections;
using System.Collections.Generic;
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
        var deviceData = _deviceSaveManager.LoadDevice();
        if(deviceData.HasValue) {
            _device.UpdateDevice(deviceData.Value);
        }
        _device.OnDeviceUpdated.AddListener(HandleDeviceUpdated);
    }

    private void HandleDeviceUpdated() {
        _deviceSaveManager.SaveDevice(_device.DeviceData);
    }
}
