let fieldGroupCounter = 0;

function AddNewCarInvidualFields() {
    fieldGroupCounter++;
    $("#plateContainer").append(
        "<div class='col-6 form-inline py-2'>" +
            "<span>" + fieldGroupCounter + ".:  </span >" +
            "<input type='text' class='form-control' name='inviduals[" + fieldGroupCounter + "].Plate'>" + 
        "</div>"  
    );
    document.getElementById("countrySelect" + fieldGroupCounter).innerHTML =
        document.getElementById("countrySelect" + fieldGroupCounter).innerHTML
        + document.getElementById("countrySelect0").innerHTML;
}

