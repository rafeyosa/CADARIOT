using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGravityScript : MonoBehaviour {
    public GameObject target;
    public Transform target2;
    private Vector3 movement;
    private Rigidbody rb;

    void Start() {
        rb = this.GetComponent<Rigidbody>();
    }

    void Update() {
        Vector3 direction = target2.localPosition - transform.position;
        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate() {
        SetGravity();
        MoveItem(movement);
    }

    void SetGravity() {
        Vector3 gravityDirection = target.transform.localPosition;
        Physics.gravity = gravityDirection;
        // Vector3 lookTarget = transform.position + gravityDirection;
        // transform.LookAt(lookTarget);

        // transform.Translate(Vector3.forward * 20 * Time.deltaTime);
    }

    void MoveItem(Vector3 movement) {
         transform.Translate(movement * 10 * Time.deltaTime);
        // rb.velocity = movement * 10;
    }

    public void OnTrackingLost() {
        this.GetComponent<Rigidbody>().useGravity = false;
    }
    public void OnTrackingFound() {
        this.GetComponent<Rigidbody>().useGravity = true;
        SetGravity();
    }
}
