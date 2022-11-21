using System;

[Serializable]
public class ItemModel<T> {
    public string name;
    public string type;
    public T data;
}
