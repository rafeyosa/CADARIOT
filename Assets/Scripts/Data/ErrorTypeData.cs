using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ErrorTypeData {
    public static List<ErrorModel> errorTypeList = new List<ErrorModel>() {
        new ErrorModel{
            errorCode = "eE", 
            message = ""
        },
        new ErrorModel {
            errorCode = "eN", 
            message = "Error: New Detect!"
        },
        new ErrorModel {
            errorCode = "eL", 
            message = "Error: Lost Item Color"
        },
        new ErrorModel {
            errorCode = "eR", 
            message = "Error: Failed Read Color"
        }
    };
}
