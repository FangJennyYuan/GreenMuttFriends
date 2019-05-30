
/**
 * Draws the valid and invalid photos graph for
 * the data within the range
 * @param {any} data from the User Model
 * @param {any} viz the id of the div container
 * @param {any} start the starting day in the data range
 * @param {any} end the ending day in the data range
 */
function drawPhotosValidandInvalidGraph(data, viz, start, end) {
    //Cast strings to dates
    data.forEach(function (arrayItem) {
        var d = moment(arrayItem.date, "MM/DD/YYYY").format('L');
        arrayItem.date = d;
    });

    //Calculate totals
    totals = calulateTotalsbyDate(data);
    

    //Create color attributes for chart
    var attributes = [
        { "clinic": "Ijora Clinic", "hex": "#5FBD73", "image": "/Content/img/IjoraI.png" },
        { "clinic": "Katsina Clinic", "hex": "#6A5599", "image": "/Content/img/KatsinaI.png" },
        { "clinic": "Mashegu Clinic", "hex": "#71BDD3", "image": "/Content/img/MasheguI.png" },
        { "clinic": "Rawayau Clinic", "hex": "#1C2C8C", "image": "/Content/img/RawayauI.png" }
    ]

    var vizInstall = d3plus.viz()
        .container(viz)
        .data({
            "value": totals,
            "stroke": { "width": 3 }
        })
        .type("bar")
        .id("date")         // key for which our data is unique on
        //.text("date")       // key to use for display tex
        .x({
            "value": "date",
            "grid": { "color": "#ffffff" }
        })
        .y({
            "value": "validphotos"
        })
        .color(function (d) {
            return d.count > 0 ? "#5FBD73" : "#1C2C8C";
        })
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
                if (text === "invalidphotos") {
                    return "Total Photo Retakes";
                } else if (text === "validphotos") {
                    return "Total Valid Photos";
                } else {
                    return d3plus.string.title(text, params);
                }
            }
        })
        .tooltip([ "validphotos", "invalidphotos"])
        .time({
            "value": "date",
            "format": d3.time.format("%x")
        })
        .ui([
            {
                "method": "y",
                "value": ["validphotos", "invalidphotos"]
            }
        ])
        .ui({
            "position": "top",
            "align": "left",
            "font": {
                "size": 19
            }
        })
        .height(400)
        .draw()
}

//Calculate totals from current data
function calulateTotalsbyDate(data) {
    var totals = [];
    i = 1;
    //Calculate total for time selected
    data.forEach(function (arrayItem) {

        //If it exists add to total
        containsDateV = containsDate(arrayItem, totals);
        if (containsDateV != -1) {
            totals[containsDateV].validphotos += arrayItem.validphotos;
            totals[containsDateV].invalidphotos += arrayItem.invalidphotos;
            totals[containsDateV].count++;
        } else {
            totals.push({
                id: i,
                date: arrayItem.date,
                validphotos: arrayItem.validphotos,
                invalidphotos: arrayItem.invalidphotos,
                count: 1
            });
        }
    });
    return totals;
}


//Check if date is in data set
function containsDate(obj, list) {
    var i;
    for (i = 0; i < list.length; i++) {
        if (list[i].date === obj.date) {
            return i;
        }
    }
    return -1;
}
