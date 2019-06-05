// Draws a map of the clinic locations
$(document).ready(function () {
    if (document.getElementById('mapdiv')) {
        var myClinics = [
            { "name": "Ijora Clinic", "latitude": 6.477803, "longitude": 3.349594, color: "#5FBD73", "first_photo": "1/23/2019", "staff": 19, "photos_in_year": 213 },
            { "name": "Mashegu Clinic", "latitude": 7.493688, "longitude": 4.552210, color: "#71BDD3", "first_photo": "1/20/2019", "staff": 15, "photos_in_year": 80 },
            { "name": "Rawayau Clinic", "latitude": 6.528841, "longitude": 5.392641, color: "#1C2C8C", "first_photo": "1/10/2019", "staff": 6, "photos_in_year": 64 },
            { "name": "Katsina Clinic", "latitude": 7.941969, "longitude": 3.577003, color: "#6A5599", "first_photo": "1/2/2019", "staff": 11, "photos_in_year": 64 }];

        new d3plus.Geomap()
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
                labelConfig: {
                    fontFamily: "'Century Gothic', Helvetica, Arial, sans-serif",
                    fontMax: 100
                }
            })
            .pointSize(function (d) {
                return d.photos_in_year;
            })

            // Zooms out graph so more of area around points is visible
            .projectionPadding("200px")

            // Add clinic stats to map points
            .tooltipConfig({
                body: function (d) {
                    var stats = "<h5 class='mt-3'>Photos Taken in 2019:  <span class='ml-2'>" + d.photos_in_year + "</span></h5>"
                    stats += "<h5>Number of Trained Staff:  <span class='ml-2'>" + d.staff + "</span></h5>"
                    stats += "<h5>First Photo Taken:  <span class='ml-2'>" + d.first_photo + "</span></h5>"
              
                    return stats;
                },
                title: function (d) {
                    return d.name;
                }
            })

            .render();
    }
});