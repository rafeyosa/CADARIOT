using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ErrorTypeData {
    public static List<ErrorModel> errorTypeList = new List<ErrorModel>() {
        new ErrorModel {
            errorCode = "eN", 
            message = "Error: New Detect!",
            description = "New Item Detected, queue got messed up, maybe you need to check it.",
            createdAt = ""
        },
        new ErrorModel {
            errorCode = "eL", 
            message = "Error: Lost Item Color",
            description = "Missing items, the machine will reset again in a few seconds, you need to check what happened to the machine.",
            createdAt = ""
        },
        new ErrorModel {
            errorCode = "eR", 
            message = "Error: Failed Read Color",
            description = "Failed to read item color. Item color not identified, will be forwarded.",
            createdAt = ""
        }
    };
}
