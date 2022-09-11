using UnityEngine;

public class DeviceSaveManager : MonoBehaviour {
    private const string DEVICE_KEY = "DEVICE_KEY";

    public void SaveDevice(DeviceData device) {
        PlayerPrefs.SetString(DEVICE_KEY, JsonUtility.ToJson(device));
    }

    public DeviceData? LoadDevice() {
        if(SaveExist()) {
            return JsonUtility.FromJson<DeviceData>(PlayerPrefs.GetString(DEVICE_KEY));
        }
        return null;
    }

    public bool SaveExist() {
        return PlayerPrefs.HasKey(DEVICE_KEY);
    }
}
