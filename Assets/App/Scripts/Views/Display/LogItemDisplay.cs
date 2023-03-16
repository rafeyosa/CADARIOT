using System;
using UnityEngine;
using UnityEngine.UI;

public class LogItemDisplay : MonoBehaviour {
    public Text TextTitle;
    public Text TextDescription;
    public Text TextTime;

    public void Display(ErrorModel errorModel) {
        if (TextTitle != null) {
            TextTitle.text = errorModel.message;
        }
        if (TextDescription != null) {
            TextDescription.text = errorModel.description;
        }
        if (TextTime != null) {
            TextTime.text = errorModel.createdAt;
        }
    }
}
