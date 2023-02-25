using UnityEngine;
using Firebase;
using Firebase.Analytics;

public class AppScript : MonoBehaviour {
    void Start() {
        FirebaseInit();
    }

    void FirebaseInit() {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith( task => {
            FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
        });
    }
}
