using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmpGraphData : GraphData {
    private static AmpGraphData instance;

    void Start() {
        if (instance != null && instance != this) {
            Destroy(this);
        } else {
            instance = this;
        }
    }

    public override GraphData GetInstance() {
        if (instance == null) {
            instance = new AmpGraphData();
        }
        return instance;
    }

    public override void InsertGraphList(DeviceModel device) {
        float value = device.sensor[4].data.amp;
        UpdateGraphList(value);
    }
}
