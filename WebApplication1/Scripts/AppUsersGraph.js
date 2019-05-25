function drawAppUsersGraph(AppUsersdata) {
    var attributes = [
        { "clinic": "Ijora Clinic", "hex": "#5FBD73" },
        { "clinic": "Katsina Clinic", "hex": "#6A5599" },
        { "clinic": "Mashegu Clinic", "hex": "#71BDD3" },
        { "clinic": "Rawayau Clinic", "hex": "#1C2C8C" }
    ]
    var visualization = d3plus.viz()
        .container("#viz")
        .data({
            "value": AppUsersdata,
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
                    return "Total App Users";
                } else {
                    return d3plus.string.title(text, params);
                }
            }
        })
        .height(600)
        .draw()
}