using System.Collections;
using UnityEngine;

public class SyncDeviceToSave : MonoBehaviour {
    [SerializeField]
    private DeviceSaveManager _deviceSaveManager;
    [SerializeField]
    private DeviceBehaviour _device;

    private void Reset() {
        _deviceSaveManager = FindObjectOfType<DeviceSaveManager>();
    }

    private IEnumerator Start() {
        var deviceDataTask = _deviceSaveManager.LoadDevice();
        yield return new WaitUntil(() => deviceDataTask.IsCompleted);
        var deviceData = deviceDataTask.Result;

        if(deviceData.HasValue) {
            _device.UpdateDevice(deviceData.Value);
        }
        _device.OnDeviceUpdated.AddListener(HandleDeviceUpdated);
    }

    private void HandleDeviceUpdated() {
        _deviceSaveManager.SaveDevice(_device.DeviceData);
    }
}
