using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ErrorTypeData {
    public static List<ErrorModel> errorTypeList = new List<ErrorModel>() {
        new ErrorModel {
            errorCode = "eN", 
            message = "Error: New Detect!",
            description = "this A",
            createdAt = ""
        },
        new ErrorModel {
            errorCode = "eL", 
            message = "Error: Lost Item Color",
            description = "this B",
            createdAt = ""
        },
        new ErrorModel {
            errorCode = "eR", 
            message = "Error: Failed Read Color",
            description = "this C",
            createdAt = ""
        }
    };
}
