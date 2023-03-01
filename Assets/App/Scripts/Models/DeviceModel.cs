using System;
using System.Collections.Generic;

[Serializable]
public class DeviceModel {
    public string name;
    public string description;
    public bool connectionStatus;
    public List<string> command;
    public List<ItemModel<ActuatorModel>> actuator;
    public List<ItemModel<ContainerModel>> container;
    public List<ItemModel<SensorModel>> sensor;
    public string updateAt;
    public string errorCode;
    public int position;
}
