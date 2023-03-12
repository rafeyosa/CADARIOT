using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorAnimator : MonoBehaviour {
    public DeviceData deviceData;
    public GameObject item;
    private Animator animator;
    private Renderer itemRenderer;
    private bool isNewStart = false;
    private bool isError = false;

    private void Awake() {
        animator = GetComponent<Animator>();
        itemRenderer = item.GetComponent<Renderer>();
    }

    void Start() {
        SetDefaultColorItem();
    }
    
    void Update() {
        try {
            PositionAnimate();
            DetechError();
        } catch (Exception e) {}
    }

    private void PositionAnimate() {
        int position = deviceData.Device.position;
        bool slider1 = deviceData.Device.actuator[1].data.isActive;
        bool slider2 = deviceData.Device.actuator[2].data.isActive;

        bool isSliding = slider1 || slider2;
        SetAnimation(position, isSliding);

        if (position == 2) {
            SetColorItem();
        }
        if (isSliding || position == 4) {
            EnableNewStartAnimation();
        }
    }

    private void SetAnimation(int step, bool isSliderActive) {
        animator.SetInteger("stepDetect", step);
        animator.SetBool("isSliderActive", isSliderActive);
    }

    private void SetNewStartAnimation() {
        animator.SetBool("isNewStart", isNewStart);
    }

    private void EnableNewStartAnimation() {
        isNewStart = true;
    }

    private void DisableNewStartAnimation() {
        isNewStart = false;
    }

    private void SetEnableNewStartAnimation() {
        EnableNewStartAnimation();
        SetNewStartAnimation();
    }
    
    private void SetDisableNewStartAnimation() {
        DisableNewStartAnimation();
        SetNewStartAnimation();
    }

    private void SetDefaultColorItem() {
        Color color = Color.gray;
        itemRenderer.material.SetColor("_Color", color);
    }

    private void SetColorItem() {
        string colorType = deviceData.Device.sensor[0].data.color;
        Color color = Color.gray;

        switch(colorType) {
            case Constants.redColor:
                color = Color.red;
                break;
            case Constants.blueColor:
                color = Color.blue;
                break;
            case Constants.greenColor:
                color = Color.green;
                break;
            case Constants.whiteColor:
                color = Color.white;
                break;
            default:
                break;
        }
        itemRenderer.material.SetColor("_Color", color);
    }

    private void DetechError() {
        string errorCode = deviceData.Device.errorCode;
        int position = deviceData.Device.position;
        
        switch(errorCode) {
            case Constants.newDetechErrorCode:
                SetEnableNewStartAnimation();
                break;
            case Constants.lostItemErrorCode:
                isError = true;
                break;
            case Constants.failedReadColorErrorCode:
                isError = true;
                break;
            case Constants.noErrorCode:
                break;
            default:
                break;
        }

        if (isError && position == 0) {
            SetEnableNewStartAnimation();
            isError = false;
        }
    }
}
