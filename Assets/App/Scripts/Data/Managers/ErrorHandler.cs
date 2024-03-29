using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using SQLite4Unity3d;

public class ErrorHandler : MonoBehaviour {
    private static ErrorHandler instance;
    private DataService dataService;
    private string lastErrorCode;
    public UnityEvent<ErrorModel> OnNewErrorComing = new UnityEvent<ErrorModel>();

    void Start() {
        if (instance != null && instance != this) {
            Destroy(this);
        } else {
            instance = this;
            dataService = new DataService(Constants.localDatabase);
            // dataService.CreateDB();
        }
    }

    public ErrorHandler GetInstance() {
        if (instance == null) {
            instance = new ErrorHandler();
        }
        return instance;
    }

    private void ToConsole(IEnumerable<ErrorModel> errorList){
		foreach (var error in errorList) {
			ToConsole(error.ToString());
		}
	}

	private void ToConsole(string msg){
		// DebugText.text += System.Environment.NewLine + msg;
		Debug.Log (msg);
	}
    
    public void CheckError(DeviceModel device) {
        string errorCode = device.errorCode;
        string timestamp = device.updateAt;
        bool isValid = errorCode != lastErrorCode && !string.IsNullOrEmpty(errorCode);

        if (isValid) {
            lastErrorCode = errorCode;
            if (errorCode == Constants.noErrorCode) {
                return;
            }
            foreach (var errorType in ErrorTypeData.errorTypeList) {
                if (errorCode == errorType.errorCode) {
                    ErrorModel newError = new ErrorModel {
                        errorCode = errorType.errorCode, 
                        message = errorType.message,
                        description = errorType.description,
                        createdAt = timestamp
                    };
                    AddErrorToDatabase(newError);
                    OnNewErrorComing.Invoke(newError);
                    break;
                }
            }
        }
    }

    private void AddErrorToDatabase(ErrorModel errorModel) {
		dataService.AddErrorModel(errorModel);
	}

    public IEnumerable<ErrorModel> GetAllErrorList() {
		var errors = dataService.GetAllErrorList();
		ToConsole(errors);
        return errors;
	}
}