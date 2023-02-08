using System;
using UnityEngine;
using UnityEngine.UI;

public class LoadDataController : MonoBehaviour {
    public DeviceData deviceData;

    public Text[] TextBucket;
    public Text TextMotor;
    public Image[] ImageColorServo;
    int i = 0;

    void Start() {
        setDefaultTextContainer();
        setDefaultImageColorServo();
    }
    
    void Update() {
        setTextContainer();
        setImageColorServo();
        
        // TextMotor.text = deviceData.Device.actuator[0].data.speed.ToString();
        // TextServo1.text = deviceData.Device.actuator[1].data.degree.ToString();
        // TextServo2.text = deviceData.Device.actuator[2].data.degree.ToString();
    }

    private void setDefaultTextContainer() {
        for (int i = 0; i < TextBucket.Length; i++) {
            TextBucket[i].text = Constants.defaultValue;
        }
    }

    private void setDefaultImageColorServo() {
        for (int i = 0; i < ImageColorServo.Length; i++) {
            ImageColorServo[i].color = new Color32(255,60,0,255);
        }
    }

    private void setTextContainer() {
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

    private void setImageColorServo() {
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
    
    public void setName() {
        deviceData.SetName("Rafeyosa " + i);
        i++;
    }
}
