using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class InfoDetailDisplay : MonoBehaviour {
    public DeviceData deviceData;
    public Text TextName;
    public Text TextDescription;
    public Text TextStatus;
    public RawImage ImageDevice;
    private string lastImageUrl = "";

    void Start() {
        // string imageUrl = "https://firebasestorage.googleapis.com/v0/b/cadariot-e5c76.appspot.com/o/CADARIOT%20Marker%20v1.0a.png?alt=media&token=f8ebb9e8-b479-46d5-ab0c-c39b4d6728e2";
        // StartCoroutine(GetTexture(imageUrl));
    }

    void Update() {
        SetTextView();
        FetchImage();
    }

    private void FetchImage() {
        var imageUrl = deviceData.Device.imageUrl;
        if(imageUrl != lastImageUrl && !string.IsNullOrEmpty(imageUrl)) {
            lastImageUrl = imageUrl;
            StartCoroutine(GetTexture(imageUrl));
        }
    }

    IEnumerator GetTexture(string imageUrl) {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(imageUrl);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success) {
            Debug.Log(www.error);
        }
        else {
            Texture currentTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            ImageDevice.texture = currentTexture;
        }
    }

    private void SetTextView() {
        if (TextName != null) {
            TextName.text = deviceData.Device.name;
        }
        if (TextDescription != null) {
            TextDescription.text = deviceData.Device.description;
        }
        if (TextStatus != null) {
            bool status = deviceData.Device.connectionStatus;
            TextStatus.text = status ? "Status: Connected" : "Status: Disconnected";
        }
    }
}
