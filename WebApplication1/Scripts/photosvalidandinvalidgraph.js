function drawPhotosValidandInvalidGraph(data, viz) {

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
            "value": data,
            "stroke": { "width": 3 }
        })
        .type("bar")
        .id(["clinic", "date"])         // key for which our data is unique on
        .text("clinic")       // key to use for display text
        .x({
            "value": "date",
            "grid": { "color": "#ffffff" }
        })
        .y({ "stacked": true, "value": "validphotos" })
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
                if (text === "invalidphotos") {
                    return "Total Photo Retakes";
                } else if (text === "validphotos") {
                    return "Total Valid Photos";
                } else {
                    return d3plus.string.title(text, params);
                }
            }
        })
        .tooltip(["clinic", "validphotos", "invalidphotos"])
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
        .legend({
            "size": 30,
            "filters": true,
            "labels": true
        })
        .icon({
            "style": "knockout",
            "value": "image"
        })
        .height(550)
        .draw()
}
