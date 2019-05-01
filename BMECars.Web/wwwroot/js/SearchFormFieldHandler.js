$(document).ready(async () => {
    if ($("#countrySelected").val() != "") {
        $("#Country").val($("#countrySelected").val());
    }

    if ($("#citySelected").val() != "") {
        await this.onPickUpCountrySelect({ value: $("#countrySelected").val() });
        $("#City").val($("#citySelected").val());        
    }

    if ($("#locationSelected").val() != "") {
        await this.onPickUpCitySelect({ value: $("#citySelected").val() });
        $("#Location").val($("#locationSelected").val());
    }

    if ($("#dropDownCountrySelected").val() != "") {
        $("#CountryDropDown").val($("#dropDownCountrySelected").val());
    }

    if ($("#dropDownCitySelected").val() != "") {
        await this.onDropDownCountrySelect({ value: $("#dropDownCountrySelected").val() });
        $("#CityDropDown").val($("#dropDownCitySelected").val());
    }

    if ($("#dropDownLocationSelected").val() != "") {
        await this.onDropDownCitySelect({ value: $("#dropDownCitySelected").val() });
        $("#LocationDropDown").val($("#dropDownLocationSelected").val());
    }
});


async function onPickUpCountrySelect(e) {
    await fetch("/ajax/GetCities?country=" + e.value)
        .then(response => response.json())
        .then(res => {
            changeDropDownValues('City', res, "Choose City");
        });
}

async function onDropDownCountrySelect(e) {
    await fetch("/ajax/GetCities?country=" + e.value)
        .then(response => response.json())
        .then(res => {
            changeDropDownValues('CityDropDown', res, "Choose City");
        });
}

async function onPickUpCitySelect(e) {
    let countrySelect = document.getElementById('Country');
    let selectedCountry = countrySelect.options[countrySelect.selectedIndex].value;


    await fetch("/ajax/GetLocations?country=" + selectedCountry + "&city=" + e.value)
        .then(response => response.json())
        .then(res => {
            console.log(JSON.stringify(res, null, 4));
            changeDropDownValues('Location', res, "Choose Location");
        })
        .catch(err => console.log("ASD"+ err));
}

async function onDropDownCitySelect(e) {
    let countrySelect = document.getElementById('CountryDropDown');
    let selectedCountry = countrySelect.options[countrySelect.selectedIndex].value;

    
    await fetch("/ajax/GetLocations?country=" + selectedCountry + "&city=" + e.value)
        .then(response => response.json())
        .then(res => {
            changeDropDownValues('LocationDropDown', res, "Choose Location");
        });
}

function changeDropDownValues(selectName, values, defaultText) {
    let select = document.getElementById(selectName);
    select.disabled = false;
    for (i = 0; i < select.options.length; i++)
        select.options[i] = null;

    select.options = [];
    var defaultOption = new Option(defaultText, "");
    defaultOption.disabled = true;
    select[0] = defaultOption;
    values.forEach((e) => {
        select.options[select.options.length] = new Option(e, e);
    });
    select.selectedIndex = 0;
}