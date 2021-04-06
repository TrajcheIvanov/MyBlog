function validateForm() {
    var requiredElements = document.querySelectorAll('[required]');
    var result = true;
    var elementNames = [];

    for (var i = 0; i < requiredElements.length; i++) {
        var elementValue = requiredElements[i].value;
        var elementName = requiredElements[i].getAttribute("name");
        if (elementValue == null || elementValue.trim().length == 0) {
            result = false;
            elementNames.push(elementName);
            //alert(elementName + " is required");
            //break;
        }

    }

    var alertMessage = " ";
    for (var i = 0; i < elementNames.length; i++) {
        alertMessage += elementNames[i] + ";";
    }

    if (!result) {
        if (elementNames.length == 1) {
            alert(alertMessage + " field is required");
        } else
            alert(alertMessage + " fields are required");
    }
    return result;
}