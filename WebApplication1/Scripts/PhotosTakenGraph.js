
function drawPhotosTakenGraph( currentPhotoData ) {

    //Sort Data by Clinic
    currentPhotoData.sort((a, b) => (a.clinic > b.clinic ) ? 1 : ((b.clinic > a.clinic) ? -1 : 0));

    //Cast strings to dates
    currentPhotoData.forEach(function (arrayItem) {
        var d = moment(arrayItem.date, "MM/DD/YYYY").format('L');
        arrayItem.date = d;
    });

    //Create color attributes for chart
    var attributes = [
        { "clinic": "Ijora Clinic", "hex": "#5FBD73", "image": "/Content/img/IjoraI.png" },
        { "clinic": "Katsina Clinic", "hex": "#6A5599", "image": "/Content/img/KatsinaI.png" },
        { "clinic": "Mashegu Clinic", "hex": "#71BDD3", "image": "/Content/img/MasheguI.png" },
        { "clinic": "Rawayau Clinic", "hex": "#1C2C8C", "image": "/Content/img/RawayauI.png" }
    ]

    //Draw Photos Taken Chart
    var visualization = d3plus.viz()
        .container("#photos_taken_chart")
        .data({
            "value": currentPhotoData,
            "stroke": { "width": 3 }
        })
        .type("line")
        .id("clinic")         // key for which our data is unique on
        .text("clinic")       // key to use for display text
        .x({
            "value": "date",
            "grid": { "color": "#ffffff" },
            "zerofill": true
        })
        .y("value")
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
                    return "Total Photos Taken";
                } else if (text === "userCount") {
                    return "Active Users";
                } else {
                    return d3plus.string.title(text, params);
                }
            }
        })
        .tooltip(["date", "value", "userCount"])
        .ui([{
            "method": "y",
            "value": ["value", "userCount"]
        }])
        .ui({
            "position": "top",
            "align": "left",
            "font": {
                "size": 19
            }
        })
        .height(495)
        .time({
            "value": "date",
            "format": d3.time.format("%x")
        })
        .legend({
            "size": 30,
            "filters": true,
            "labels": true
        })
        .icon({
            "style": "knockout",
            "value": "image"
        })
        .draw()
}
