function onPickUpCountrySelect(e) {
    fetch("/ajax/GetCities?country=" + e.value)
        .then(response => response.json())
        .then(res => {
            changeDropDownValues('city', res);
        });
}

function onPickUpCitySelect(e) {
    let selectedCountry = document.getElementById('country').options[countrySelect.selectedIndex].value;

    fetch("ajax/GetLocations?country=" + selectedCountry + "&city=" + e.value)
        .then(response => response.json())
        .then(res => {
            changeDropDownValues('location', res);
        });
}

function changeDropDownValues(selectName, values) {
    let select = document.getElementById(selectName);
    select.disabled = false;
    for (i = 0; i < select.options.length; i++)
        select.options[i] = null;

    select.options = [];
    values.forEach((e) => {
        select.options[select.options.length] = new Option(e, e);
    });
}