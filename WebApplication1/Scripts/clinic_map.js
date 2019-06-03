﻿var projection = d3.geoEqualEarth(),
    path = d3.geoPath(projection);


var myClinics = [
    { "name": "Ijora Clinic", "latitude": 6.477803, "longitude": 3.349594, color: "#5FBD73", "first_photo": "1/23/2019", "staff": 19, "photos_in_year": 97 },
    { "name": "Mashegu Clinic", "latitude": 7.493688, "longitude": 4.552210, color: "#71BDD3", "first_photo": "1/20/2019", "staff": 15, "photos_in_year": 158 },
    { "name": "Rawayau Clinic", "latitude": 6.528841, "longitude": 5.392641, color: "#1C2C8C", "first_photo": "1/10/2019", "staff": 6, "photos_in_year": 54 },
    { "name": "Katsina Clinic", "latitude": 7.941969, "longitude": 3.577003, color: "#6A5599", "first_photo": "1/2/2019", "staff": 11, "photos_in_year": 59 }];

var clinicMap = new d3plus.Geomap()
    .data(myClinics)
    .select("#mapdiv")
    .groupBy("name")
    .label(function (d) {
        return d.name;
    })
    .point(function (d) {
        return [d.longitude, d.latitude];
    })
    .shapeConfig({
        fill: function (d) { return d.color; },
    })

    .pointSize(function (d) {
        return d.photos_in_year + d.staff;
    })

    .projectionPadding("200px")

    .tooltipConfig({
        body: function (d) {
            var stats = "<ul>"
            stats += "<li>First photo taken: " + d.first_photo + "</li>"
            stats += "<li>Number of trained staff: " + d.staff + "</li>"
            stats += "<li>Photos this year: " + d.photos_in_year + "</li>"
            stats += "</ul>"
            return stats;
        },
        title: function (d) {
            return d.name;
        }
    })

    .render();