using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorHandler : MonoBehaviour {
    private static ErrorHandler instance;

    void Start() {
        if (instance != null && instance != this) {
            Destroy(this);
        } else {
            instance = this;
        }
    }

    public ErrorHandler GetInstance() {
        if (instance == null) {
            instance = new ErrorHandler();
        }
        return instance;
    }
    
    public void CheckError(DeviceModel device) {
        string errorCode = device.errorCode;
        string timestamp = device.updateAt;

        if (errorCode != Constants.noErrorCode && string.IsNullOrEmpty(errorCode)) {
            foreach (var errorType in ErrorTypeData.errorTypeList) {
                if (errorCode == errorType.errorCode) {
                    AddErrorToDatabase(
                        new ErrorModel {
                            errorCode = errorType.errorCode, 
                            message = errorType.message,
                            description = errorType.description,
                            createdAt = timestamp
                        }
                    );
                    break;
                }
            }
        }
    }

    private void AddErrorToDatabase(ErrorModel error) {
        // TODO add to local database
    }
}