using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphData : MonoBehaviour {
    [SerializeField] private List<float> _graphList;
    public List<float> GraphList => _graphList;
    [HideInInspector] public float min = 0f;
    [HideInInspector] public float max = 0f;
    private int maxCount = 20;

    public virtual GraphData GetInstance() {
        return this;
    }

    public virtual void SetMaxCount(int maxCount) {
        this.maxCount = maxCount;
    }
    
    public virtual void InsertGraphList(DeviceModel device) {}

    protected void UpdateGraphList(float value) {
        if (_graphList.Count >= maxCount) {
            _graphList.RemoveAt(0);
        }
        _graphList.Add(value);

        min = _graphList[0];
        foreach (float i in _graphList) {
            min = i < min ? i : min;
        }
        max = _graphList[0];
        foreach (float i in _graphList) {
            max = i > max ? i : max;
        }
    }
}
