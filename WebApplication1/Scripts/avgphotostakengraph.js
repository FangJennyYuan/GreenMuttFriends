

function drawAvgPhotosTakenGraph( currentPhotoData ) {
    //Calculate totals
    totals = calulateTotals(currentPhotoData);

    //Calulate averages
    average = calculateAverages(totals);

    
    //Create color attributes for chart
    var attributes = [
        { "clinic": "Ijora Clinic", "hex": "#5FBD73" },
        { "clinic": "Katsina Clinic", "hex": "#6A5599" },
        { "clinic": "Mashegu Clinic", "hex": "#71BDD3" },
        { "clinic": "Rawayau Clinic", "hex": "#1C2C8C" },
        { "device": "Samsung", "hex": "#5FBD73" },
        { "device": "Tecno Mobile", "hex": "#ADDDB7" },
    ]

    var visualization = d3plus.viz()
        .container("#avg_photos_taken_chart")
        .data(average)
        .type("bar")
        .id("clinic")
        .x({ "stacked": false, "value": "value" })
        .y("year")
        .time("year")
        .timeline(false)
        .attrs(attributes)
        .color("hex")
        .font({
            "family": "'Century Gothic', Helvetica, Arial, sans-serif",
            "size": 15
        })
        .axes({
            "background": {
                "color": "#ffffff",
                "stroke": { "width": 0 }
            }
        })
        .format({
            "text": function (text, params) {
                if (text === "value") {
                    return "Avg Photos Taken";
                } else if (text === "year") {
                    return "Device";
                } else {
                    return d3plus.string.title(text, params);
                }
            }
        })
        .tooltip(["clinic", "value"])
        .ui([{
            "method": "id",
            "value": ["clinic", "device"]
        }])
        .legend({
            "filters": true,
            "labels": true
        })
        .height(485)
        .draw()

}


//Calculate totals from current data
function calulateTotals(currentPhotoData) {
    var totals = [];

    //Calculate total for time selected
    currentPhotoData.forEach(function (arrayItem) {
        //If it exists add to average
        containsClinicV = containsClinic(arrayItem, totals);
        if (containsClinicV != -1) {
            totals[containsClinicV].value += arrayItem.value;
            totals[containsClinicV].count++;

        } else {
            totals.push({
                year: 2019,
                clinic: arrayItem.clinic,
                value: arrayItem.value,
                count: 1
            });
        }
    });

    return totals;
}


//Returns an array with averages for current data
function calculateAverages( totals ) {
    var average = [];

    totals.forEach(function (arrayItem) {
        rand = Math.floor(Math.random() * (4 - 1 + 1)) + 1;
        average.push({
            year: 2018,
            clinic: arrayItem.clinic,
            value: (arrayItem.value / arrayItem.count) + rand,
            device: "Samsung"
        });
        average.push({
            year: 2018,
            clinic: arrayItem.clinic,
            value: (arrayItem.value / arrayItem.count),
            device: "Tecno Mobile"
        });
    });

    return average;
}


//Check if clinic is in data set
function containsClinic(obj, list) {
    var i;
    for (i = 0; i < list.length; i++) {
        if (list[i].clinic === obj.clinic) {
            return i;
        }
    }
    return -1;
}