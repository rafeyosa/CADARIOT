using UnityEngine;
using Firebase;
using Firebase.Analytics;

public class App : MonoBehaviour {
    void Start() {
        FirebaseInit();
    }

    void FirebaseInit() {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith( task => {
            FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
        });
    }
}
