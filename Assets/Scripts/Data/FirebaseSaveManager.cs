using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using Firebase.Database;

public class FirebaseSaveManager : MonoBehaviour {
    private FirebaseDatabase _database;
    private DatabaseReference _ref;
    public FirebaseUpdatedEvent OnDataUpdated = new FirebaseUpdatedEvent();

    private void Start() {
        _database = FirebaseDatabase.DefaultInstance;
        _ref = _database.GetReference(Constants.DEVICE_KEY);
        _ref.ValueChanged += HandleValueChanged;
    }

    private void OnDestroy() {
        _ref.ValueChanged -= HandleValueChanged;
        _ref = null;
        _database = null;
    }

    public void Save(DeviceModel device) {
        _database.GetReference(Constants.DEVICE_KEY).SetRawJsonValueAsync(JsonUtility.ToJson(device));
    }

    public async Task<DeviceModel?> Load() {
        var dataSnapshot = await _database.GetReference(Constants.DEVICE_KEY).GetValueAsync();
        if(!dataSnapshot.Exists) {
            return null;
        }
        return JsonUtility.FromJson<DeviceModel>(dataSnapshot.GetRawJsonValue());
    }

    public async Task<bool> IsSaveExist() {
        var dataSnapshot = await _database.GetReference(Constants.DEVICE_KEY).GetValueAsync();
        return dataSnapshot.Exists;
    }

    public void EraseSave() {
        _database.GetReference(Constants.DEVICE_KEY).RemoveValueAsync();
    }

    private void HandleValueChanged(object sender, ValueChangedEventArgs e) {
        var json = e.Snapshot.GetRawJsonValue();
        if(!string.IsNullOrEmpty(json)) {
            var device = JsonUtility.FromJson<DeviceModel>(json);
            OnDataUpdated.Invoke(device);
        }
    }
}
 
public class FirebaseUpdatedEvent : UnityEvent<DeviceModel> {}
