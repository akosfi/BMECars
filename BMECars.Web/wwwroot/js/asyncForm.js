function onPickUpCountrySelect(e) {
    //alert(e.value);
    fetch("/ajax/GetCities?country=" + e.value)
        .then(response => response.json())
        .then(res => {
            
            let citySelect = document.getElementById('city');
            document.getElementById('city').disabled = false;
            for (i = 0; i < citySelect.options.length; i++) 
                citySelect.options[i] = null;
            
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
            document.getElementById('location').disabled = false;
            for (i = 0; i < locationSelect.options.length; i++)
                locationSelect.options[i] = null;

            locationSelect.options = [];
            res.forEach((e) => {
                locationSelect.options[locationSelect.options.length] = new Option(e, e);
            });
        });
}