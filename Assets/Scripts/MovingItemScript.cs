using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingItemScript : MonoBehaviour {
    public Transform target;
    void Start() {
        
    }

    void Update() {
        Vector3 direction = target.position - transform.position;
        Debug.Log(direction);
    }
}
