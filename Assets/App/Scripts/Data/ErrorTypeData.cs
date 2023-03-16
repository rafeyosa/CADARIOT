using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ErrorTypeData {
    public static List<ErrorModel> errorTypeList = new List<ErrorModel>() {
        new ErrorModel {
            errorCode = "eN", 
            message = "Error: New Detect!",
            description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus elementum ante tortor, a ultricies tellus pulvinar et. Cras hendrerit justo gravida velit tincidunt, id ullamcorper sapien eleifend. Maecenas ullamcorper interdum elit, eget cursus justo auctor non. Aenean imperdiet lectus et elit porta sollicitudin a eget orci.",
            createdAt = ""
        },
        new ErrorModel {
            errorCode = "eL", 
            message = "Error: Lost Item Color",
            description = "Vivamus ex felis, eleifend et arcu in, rhoncus commodo enim. Cras sodales tortor eu ultrices laoreet. In vel venenatis quam. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nam luctus interdum felis, id accumsan odio pellentesque et. Quisque a velit leo.",
            createdAt = ""
        },
        new ErrorModel {
            errorCode = "eR", 
            message = "Error: Failed Read Color",
            description = "Pellentesque commodo, dolor gravida dignissim consectetur, turpis augue iaculis purus, vitae eleifend nisi lectus at urna. In bibendum mauris at neque accumsan, at dapibus erat auctor. Curabitur lobortis nisi sit amet est consectetur, non eleifend urna finibus.",
            createdAt = ""
        }
    };
}
