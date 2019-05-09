let fieldGroupCounter = 0;

function AddNewCarInvidualFields() {
    fieldGroupCounter++;
    $("#plateContainer").append(
        "<div class='form-inline py-3' style='position: relative;'>" + 
            "<span>" + (fieldGroupCounter + 1) + ". Plate: </span>" + 
            "<input type='text' class='form-control float-right' name='inviduals[" + fieldGroupCounter + "].Plate' style='position: absolute; right: 0;'>" + 
        "</div>"
    );
    document.getElementById("countrySelect" + fieldGroupCounter).innerHTML =
        document.getElementById("countrySelect" + fieldGroupCounter).innerHTML
        + document.getElementById("countrySelect0").innerHTML;
}

