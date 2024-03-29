using UnityEngine;
using UnityEngine.Events;

public class ViewCallback : MonoBehaviour {
    public UnityEvent<string?> Callback = new UnityEvent<string?>();

    private void WhenComplete() {
        Callback.Invoke(null);
    }

    private void Then(string value) {
        Callback.Invoke(value);
    }
}
