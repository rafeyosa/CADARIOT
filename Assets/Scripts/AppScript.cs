using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Analytics;

public class AppScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        FirebaseInit();
    }

    void FirebaseInit() {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith( task => {
            FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
        });
    }
}
