using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorAnimatorController : MonoBehaviour {
    public DeviceData deviceData;
    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    void Start() {

    }
    
    void Update() {
        
    }
}
