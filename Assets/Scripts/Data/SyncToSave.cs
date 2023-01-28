using UnityEngine;

public class SyncToSave : MonoBehaviour {
    [SerializeField]
    private FirebaseSaveManager _firebaseSaveManager;
    [SerializeField]
    private DeviceData _deviceData;

    private void Start() {
        _firebaseSaveManager.OnDataUpdated.AddListener(HandleFirebaseDataUpdated);
        _deviceData.OnDeviceUpdated.AddListener(HandleDeviceUpdated);
    }

    private void Reset() {
        _firebaseSaveManager = FindObjectOfType<FirebaseSaveManager>();
    }

    private void HandleFirebaseDataUpdated(DeviceModel device) {
        _deviceData.UpdateDevice(device);
    }

    private void HandleDeviceUpdated() {
        _firebaseSaveManager.Save(_deviceData.Device);
    }

}
