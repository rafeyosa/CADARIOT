using UnityEngine;

public class TrackingHandlerScript : MonoBehaviour {

    public void OnTrackingLost() {
        GameObject[] boxes;
        boxes = GameObject.FindGameObjectsWithTag("Box");

        foreach (GameObject box in boxes) {
            // box.GetComponent<Rigidbody>().useGravity = false;
            box.GetComponent<TargetGravityScript>().OnTrackingLost();
        }
    }

    public void OnTrackingFound() {
        GameObject[] boxes;
        boxes = GameObject.FindGameObjectsWithTag("Box");

        foreach (GameObject box in boxes) {
            // box.GetComponent<Rigidbody>().useGravity = true;
            box.GetComponent<TargetGravityScript>().OnTrackingFound();
        }
    }
}
