using System;
using UnityEngine;
using UnityEngine.UI;


public class ConveyorUiDisplay : MonoBehaviour {
    public DeviceData deviceData;
    public Text[] TextBucket;
    public Image[] ImageColorServo;

    void Start() {
        SetDefaultTextContainer();
        SetDefaultImageColorServo();
    }
    
    void Update() {
        SetTextContainer();
        SetImageColorServo();
    }

    private void SetDefaultTextContainer() {
        for (int i = 0; i < TextBucket.Length; i++) {
            TextBucket[i].text = Constants.defaultValue;
        }
    }

    private void SetDefaultImageColorServo() {
        for (int i = 0; i < ImageColorServo.Length; i++) {
            ImageColorServo[i].color = new Color32(255,60,0,255);
        }
    }

    private void SetTextContainer() {
        var containerList = deviceData.Device.container;
        int indexContainer = 0;
        int indexText = 0;

        while (indexText < TextBucket.Length && indexContainer < containerList.Count) {
            var container = containerList[indexContainer];
            if (container.type == Constants.BucketContainerType) {
                TextBucket[indexText].text = string.Format("{0}\n{1}", container.data.description, container.data.value);
                indexText++;
            }
            indexContainer++;
        }
    }

    private void SetImageColorServo() {
        var servoList = deviceData.Device.actuator;
        int indexServo = 0;
        int indexImage = 0;

        while (indexImage < ImageColorServo.Length && indexServo < servoList.Count) {
            var servo = servoList[indexServo];
            if (servo.type == Constants.ServoActuatorType) {
                if (servo.data.isActive) {
                    ImageColorServo[indexImage].color = new Color32(60,255,0,255);
                } else {
                    ImageColorServo[indexImage].color = new Color32(255,60,0,255);
                }
                indexImage++;
            }
            indexServo++;
        }
    }
}
