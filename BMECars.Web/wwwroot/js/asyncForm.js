function onPickUpCountrySelect(e) {
    //alert(e.value);
    fetch("/ajax/GetCities?country=" + e.value)
        .then(response => response.json())
        .then(res => {
            
            let citySelect = document.getElementById('city');
            citySelect.options = [];
            res.forEach((e) => {
                citySelect.options[citySelect.options.length] = new Option(e, e);
            });
        });
}

function onPickUpCitySelect(e) {
    let countrySelect = document.getElementById('country');
    let selectedCountry = countrySelect.options[countrySelect.selectedIndex].value;


    fetch("ajax/GetLocations?country=" + selectedCountry + "&city=" + e.value)
        .then(response => response.json())
        .then(res => {
            let locationSelect = document.getElementById('location');
            locationSelect.options = [];
            res.forEach((e) => {
                locationSelect.options[locationSelect.options.length] = new Option(e, e);
            });
        });
}