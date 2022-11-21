using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using Firebase;
using Firebase.Database;

public class DeviceSaveManager : MonoBehaviour {
    private const string DEVICE_KEY = "device/cadariot-e5c76";
    private FirebaseDatabase _database;
    public DeviceModel LastDeviceData { get; private set;}
    public DeviceUpdatedEvent OnDeviceUpdated = new DeviceUpdatedEvent();
    private DatabaseReference _ref;

    private void Start() {
        _database = FirebaseDatabase.DefaultInstance;
        _ref = _database.GetReference(DEVICE_KEY);
        _ref.ValueChanged += HandleValueChanged;
    }

    private void OnDestroy() {
        _ref.ValueChanged -= HandleValueChanged;
        _ref = null;
        _database = null;
    }

    public void SaveDevice(DeviceModel device) {
        if(!device.Equals(LastDeviceData)) {
            Debug.Log("rafeyosa json: " + JsonUtility.ToJson(device));
            _database.GetReference(DEVICE_KEY).SetRawJsonValueAsync(JsonUtility.ToJson(device));
        }
    }

    public async Task<DeviceModel?> LoadDevice() {
        var dataSnapshot = await _database.GetReference(DEVICE_KEY).GetValueAsync();
        if(!dataSnapshot.Exists) {
            Debug.Log("Json: null");
            return null;
        }
        Debug.Log("Json: " + dataSnapshot.GetRawJsonValue());
        return JsonUtility.FromJson<DeviceModel>(dataSnapshot.GetRawJsonValue());
    }

    public async Task<bool> SaveExist() {
        var dataSnapshot = await _database.GetReference(DEVICE_KEY).GetValueAsync();
        return dataSnapshot.Exists;
    }

    public void EraseSave() {
        _database.GetReference(DEVICE_KEY).RemoveValueAsync();
    }

    private void HandleValueChanged(object sender, ValueChangedEventArgs e) {
        var json = e.Snapshot.GetRawJsonValue();
        if(!string.IsNullOrEmpty(json)) {
            var device = JsonUtility.FromJson<DeviceModel>(json);
            LastDeviceData = device;
            OnDeviceUpdated.Invoke(device);
        }
    }
}
 
public class DeviceUpdatedEvent : UnityEvent<DeviceModel> {}
