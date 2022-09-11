using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using Firebase;
using Firebase.Database;

public class DeviceSaveManager : MonoBehaviour {
    private const string DEVICE_KEY = "DEVICE_KEY";
    private FirebaseDatabase _database;
    public DeviceData LastDeviceData { get; private set;}
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

    public void SaveDevice(DeviceData device) {
        if(!device.Equals(LastDeviceData)) {
            _database.GetReference(DEVICE_KEY).SetRawJsonValueAsync(JsonUtility.ToJson(device));
        }
    }

    public async Task<DeviceData?> LoadDevice() {
        var dataSnapshot = await _database.GetReference(DEVICE_KEY).GetValueAsync();
        if(!dataSnapshot.Exists) {
            return null;
        }
        return JsonUtility.FromJson<DeviceData>(dataSnapshot.GetRawJsonValue());
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
            var deviceData = JsonUtility.FromJson<DeviceData>(json);
            LastDeviceData = deviceData;
            OnDeviceUpdated.Invoke(deviceData);
        }
    }
}
 
public class DeviceUpdatedEvent : UnityEvent<DeviceData> {}
