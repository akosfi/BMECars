function setCalendarDates(carId) {

    console.log("asd");

    fetch("/ajax/GetReservationsForCar/?carId=" + carId)
        .then(response => response.json())
        .then(res => {
            
            

            var eventDates = {};
            res.forEach((r) => {
                const startDate = new Date(r["startDate"]);
                const endDate = new Date(r["endDate"]);
                //hónap/nap/év
                for (var d = startDate; d <= endDate; d.setDate(d.getDate() + 1)) {
                    var date = (d.getMonth() + 1) + "/" + d.getDate() + "/" + d.getFullYear()
                    eventDates[new Date(date)] = (new Date(date)).toString();
                }
            });

            $('#calendar').remove();
            const calendar = "<div id='calendar'></div>"
            $("#calendarHolder").append(calendar);


            $('#calendar').datepicker({
                beforeShowDay: function (date) {
                    var highlight = eventDates[date];
                    if (highlight) {
                        return [true, "event", highlight];
                    } else {
                        return [true, '', ''];
                    }
                },
                dayNamesMin: ["V", "H", "K", "SZe", "CS", "P", "SZo"]
            });
        });
}



function setCarDetails(carId) {

}