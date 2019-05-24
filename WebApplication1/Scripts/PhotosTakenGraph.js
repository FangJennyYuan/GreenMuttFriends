
function drawPhotosTakenGraph( currentPhotoData ) {

    //Sort Data by Clinic
    currentPhotoData.sort((a, b) => (a.clinic > b.clinic) ? 1 : ((b.clinic > a.clinic) ? -1 : 0));

    //Create color attributes for chart
    var attributes = [
        { "clinic": "Ijora Clinic", "hex": "#5FBD73" },
        { "clinic": "Katsina Clinic", "hex": "#6A5599" },
        { "clinic": "Mashegu Clinic", "hex": "#71BDD3" },
        { "clinic": "Rawayau Clinic", "hex": "#1C2C8C" }
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
            "value": "Date",
            "grid": { "color": "#ffffff" }
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
        .legend({
            "filters": true,
            "labels": true
        })
        .height(485)
        .draw()
}
