
function drawAvgPhotosTakenGraph(currentPhotoData, start, end) {
    //Calculate totals
    totals = calulateTotals(currentPhotoData);

    //Calulate averages
    days = getDateRange(start, end);
    average = calculateAverages(totals, days);

    //Create color attributes for chart
    var attributes = [
        { "clinic": "Ijora Clinic", "hex": "#5FBD73", "image": "/Content/img/IjoraI.png" },
        { "clinic": "Katsina Clinic", "hex": "#6A5599", "image": "/Content/img/KatsinaI.png" },
        { "clinic": "Mashegu Clinic", "hex": "#71BDD3", "image": "/Content/img/MasheguI.png"  },
        { "clinic": "Rawayau Clinic", "hex": "#1C2C8C", "image": "/Content/img/RawayauI.png" },
        { "device": "Samsung", "hex": "#4C975C", "image": "/Content/img/SamsungI.png" },
        { "device": "Tecno Mobile", "hex": "#ADDDB7", "image": "/Content/img/TecnoI.png" }
    ]
    
    var vizAvgPhotos = d3plus.viz()
        .container("#avg_photos_taken_chart")
        .data(average)
        .type("bar")
        .id(["device", "clinic"])
        .x({
            "stacked": false,
            "value": "value"
        })
        .y({
            "scale": "discrete",
            "value": "clinic"
        })
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
            "value": ["device", "clinic"]
        }])
        .legend({
            "size": 30,
            "filters": true,
            "labels": true
        })
        .icon({
            "style": "knockout",
            "value": "image"
        })
        .height(480)
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
function calculateAverages( totals , days ) {
    var average = [];

    totals.forEach(function (arrayItem) {
        //TODO: Remove in Production
        //Just added some randomization to make graph look good for now
        rand = Math.random() * (+3 - +1) + +1; 
        avg = (arrayItem.value / days);
        avgLow = ((avg - rand < 0) ? 1 : avg - rand);


        average.push({
            clinic: arrayItem.clinic,
            value: avgLow,
            device: "Samsung"
        });
        average.push({
            clinic: arrayItem.clinic,
            value: rand,
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


//Get range in days 
function getDateRange(start, end) {
    var date1 = moment(start, "MM/DD/YYYY");
    var date2 = moment(end, "MM/DD/YYYY");
    var diff = date2.diff(date1, 'days');
    return diff;
}