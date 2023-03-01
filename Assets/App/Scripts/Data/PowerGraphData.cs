using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerGraphData : GraphData {
    private static PowerGraphData instance;

    void Start() {
        if (instance != null && instance != this) {
            Destroy(this);
        } else {
            instance = this;
        }
    }

    public override GraphData GetInstance() {
        if (instance == null) {
            instance = new PowerGraphData();
        }
        return instance;
    }
    
    public override void InsertGraphList(DeviceModel device) {
        float volt = device.sensor[4].data.volt;
        float amp = device.sensor[4].data.amp;
        UpdateGraphList(volt * amp);
    }
}
