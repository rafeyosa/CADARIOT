using UnityEngine;
using UnityEngine.Events;
using Firebase;
using Firebase.Extensions;
using Firebase.Analytics;

public class FirebaseInit : MonoBehaviour {
    public UnityEvent OnFirebaseInitialized = new UnityEvent();

    void Start() {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task => {
            if(task.Exception != null) {
                Debug.LogError($"Failed to initialize Firebase with {task.Exception}");
                return;
            }
            FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
            OnFirebaseInitialized.Invoke();
        });
    }
}
