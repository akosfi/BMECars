let fieldGroupCounter = 0;

function AddNewCarInvidualFields() {
    fieldGroupCounter++;
    $("#inputGroupContainer").append(
        "<div class='inputGroup row' name='inputGroup" + fieldGroupCounter + "'>"
        + "<div class='col-6 col-md-3'>"
        + "<input type='text' class='form-control' name='inviduals[" + fieldGroupCounter + "].Plate' >"
        + "</div>"
        + "<div class='col-6 col-md-3'>"
        + "<select id='countrySelect" + fieldGroupCounter + "' name='inviduals[" + fieldGroupCounter + "].Country' class='form-control'></select>"
        + "</div>"
        + "<div class='col-6 col-md-3'>"
        + "<select name='inviduals[" + fieldGroupCounter + "].City' class='form-control'><option value='Teszt'>Teszt</option></select>"
        + "</div>"
        + "<div class='col-6 col-md-3'>"
        + "<select name='inviduals[" + fieldGroupCounter + "].PickUp' class='form-control'><option value='Teszt'>Teszt</option></select>"
        + "</div>"
        + "</div>"
    );
    document.getElementById("countrySelect" + fieldGroupCounter).innerHTML =
        document.getElementById("countrySelect" + fieldGroupCounter).innerHTML
        + document.getElementById("countrySelect0").innerHTML;
}

