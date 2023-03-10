using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorPopUpController : MonoBehaviour {
    private Transform popUpContainer;
    public ErrorPopUpItemDisplay popUpItemDisplayPrefab;

    void Awake() {
        popUpContainer = transform.Find("PopUpContainer");
    }

    public void DisplayNewError(ErrorModel item) {
        ErrorPopUpItemDisplay display = (ErrorPopUpItemDisplay)Instantiate(popUpItemDisplayPrefab);
        display.transform.SetParent(popUpContainer, false);
        display.Display(item);
    }
}
