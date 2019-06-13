// Draws a map of the clinic locations
$(document).ready(function () {
    if (document.getElementById('mapdiv')) {
        var myClinics = [
            { "name": "Ijora Clinic", "latitude": 6.477803, "longitude": 3.349594, color: "#5FBD73", "first_photo": "1/23/2019", "staff": 25, "photos_in_year": 355 },
            { "name": "Mashegu Clinic", "latitude": 7.493688, "longitude": 4.552210, color: "#71BDD3", "first_photo": "1/20/2019", "staff": 9, "photos_in_year": 130 },
            { "name": "Rawayau Clinic", "latitude": 6.528841, "longitude": 5.392641, color: "#1C2C8C", "first_photo": "1/10/2019", "staff": 13, "photos_in_year": 360 },
            { "name": "Katsina Clinic", "latitude": 7.941969, "longitude": 3.577003, color: "#6A5599", "first_photo": "1/2/2019", "staff": 17, "photos_in_year": 280 },
            { "name": "Rawayau Clinic", "latitude": 6.628841, "longitude": 5.392641, color: "#1C2C8C", "first_photo": "1/10/2019", "staff": 1, "photos_in_year": 44 },
            { "name": "Katsina Clinic", "latitude": 7.641969, "longitude": 3.577003, color: "#6A5599", "first_photo": "1/2/2019", "staff": 2, "photos_in_year": 23 },
            { "name": "Mashegu Clinic", "latitude": 7.463688, "longitude": 4.652210, color: "#71BDD3", "first_photo": "1/20/2019", "staff": 9, "photos_in_year":98 },
            { "name": "Rawayau Clinic", "latitude": 6.538841, "longitude": 5.492641, color: "#1C2C8C", "first_photo": "2/18/2019", "staff": 4, "photos_in_year": 33 },
            { "name": "Katsina Clinic", "latitude": 7.961969, "longitude": 3.497003, color: "#6A5599", "first_photo": "4/20/2019", "staff": 3, "photos_in_year": 40 },
            { "name": "Rawayau Clinic", "latitude": 6.678841, "longitude": 5.342641, color: "#1C2C8C", "first_photo": "4/10/2019", "staff": 1, "photos_in_year": 20 },
            { "name": "Katsina Clinic", "latitude": 7.621969, "longitude": 3.587003, color: "#6A5599", "first_photo": "3/12/2019", "staff": 2, "photos_in_year": 4 },
            { "name": "Rawayau Clinic", "latitude": 6.743542, "longitude": 4.874153, color: "#1C2C8C", "first_photo": "4/3/2019", "staff": 1, "photos_in_year": 20 },
            { "name": "Ijora Clinic", "latitude": 6.622188, "longitude": 3.307636, color: "#5FBD73", "first_photo": "4/22/2019", "staff": 4, "photos_in_year": 77 },
            { "name": "Ijora Clinic", "latitude": 6.607500, "longitude": 3.486396, color: "#5FBD73", "first_photo": "4/22/2019", "staff": 1, "photos_in_year": 9 },
            { "name": "Ijora Clinic", "latitude": 6.458948, "longitude": 3.389726, color: "#5FBD73", "first_photo": "4/22/2019", "staff": 2, "photos_in_year": 16 },
            { "name": "Ijora Clinic", "latitude": 6.647360, "longitude": 3.410388, color: "#5FBD73", "first_photo": "4/22/2019", "staff": 2, "photos_in_year": 10 },
            { "name": "Rawayau Clinic", "latitude": 6.648841, "longitude": 5.292641, color: "#1C2C8C", "first_photo": "5/10/2019", "staff": 1, "photos_in_year": 5 },
            { "name": "Ijora Clinic", "latitude": 6.557803, "longitude": 3.309594, color: "#5FBD73", "first_photo": "1/23/2019", "staff": 1, "photos_in_year": 12 },
            { "name": "Mashegu Clinic", "latitude": 7.423688, "longitude": 4.652210, color: "#71BDD3", "first_photo": "1/20/2019", "staff": 1, "photos_in_year": 14 },
            { "name": "Rawayau Clinic", "latitude": 6.520811, "longitude": 5.492641, color: "#1C2C8C", "first_photo": "1/10/2019", "staff": 2, "photos_in_year": 10 },
            { "name": "Katsina Clinic", "latitude": 7.945969, "longitude": 3.597003, color: "#6A5599", "first_photo": "1/2/2019", "staff": 1, "photos_in_year": 8 },
            { "name": "Rawayau Clinic", "latitude": 6.531683, "longitude": 4.802453, color: "#1C2C8C", "first_photo": "5/15/2019", "staff": 1, "photos_in_year": 7 },
            {"name": "Rawayau Clinic", "latitude": 6.327945, "longitude": 4.851141, color: "#1C2C8C", "first_photo": "4/17/2019", "staff": 1, "photos_in_year": 9 },
        
        ]; 


        new d3plus.Geomap()
            .data(myClinics)
            .select("#mapdiv")
            .groupBy(["name", "latitude", "longitude"])
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
                    fontSize: 18
                }
            })
            .pointSize(function (d) {
                return d.photos_in_year;
            })
            .pointSizeMin(3)
            .pointSizeMax(15)
            // Zooms out graph so more of area around points is visible
            .projectionPadding("70px")

            // Add clinic stats to map points
            .tooltipConfig({
                body: function (d) {
                    var stats = "<h5 class='mt-3'>Photos Taken in 2019:  <span class='ml-2'>" + d.photos_in_year + "</span></h5>"
                    stats += "<h5>Number of Trained Staff:  <span class='ml-2'>" + d.staff + "</span></h5>"
                    stats += "<h5>First Photo Taken:  <span class='ml-2'>" + d.first_photo + "</span></h5>"
                    return stats;
                },
                title: function (d) {
                    var title = "<h2 style='color: " + d.color + "'>" + d.name + "</h2>";
                    return title;
                }
            })

            .render();
    }
});