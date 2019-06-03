
/**
 * Get Total Photo Count with combined valid and 
 * invalid photos for all data within the range
 * and return the total as well as the percent change
 * @param {any} data from the user model
 * @param {any} start the starting day in the data range
 * @param {any} end the ending day in the data range
 */
function calculateTotalPhotoCount(data, start, end) {

    var totalPhotos = 0;
    var percentChange = 0;
    var s = moment(start, "MM/DD/YYYY").format('L');
    var e = moment(end, "MM/DD/YYYY").format('L');
    var startVal = 0;
    var endVal = 0;

    //Add all invalid and valid photos together
    data.forEach(function (arrayItem) {
        todaysPhotos = arrayItem.validphotos + arrayItem.invalidphotos;
        totalPhotos += todaysPhotos;
        console.log(arrayItem.date  + " " +arrayItem.clinic + " " + arrayItem.validphotos + " " + arrayItem.invalidphotos);

        var d = moment(arrayItem.date, "MM/DD/YYYY").format('L');
        if (d == s) {
            startVal += todaysPhotos;
        }
        else if (d == e) {
            endVal += todaysPhotos;
        }
    });

    //Percent change in total photos
    percentChange = endVal - startVal / endVal;
    return [totalPhotos, percentChange.toFixed(1)];
}


/**
 * Get Total Photo Count with combined valid and 
 * invalid photos for all data within the range
 * and return the total as well as the percent change
 * @param {any} data from the user model
 * @param {any} start the starting day in the data range
 * @param {any} end the ending day in the data range
 */
function calculateTotalValidPhotoCount(data, start, end) {

    var totalValidPhotos = 0;
    var percentChange = 0;
    var s = moment(start, "MM/DD/YYYY").format('L');
    var e = moment(end, "MM/DD/YYYY").format('L');
    var startVal = 0;
    var endVal = 0;

    //Add valid photos together
    data.forEach(function (arrayItem) {
        todaysPhotos = arrayItem.validphotos;
        totalValidPhotos += todaysPhotos;

        var d = moment(arrayItem.date, "MM/DD/YYYY").format('L');
        if (d == s) {
            startVal += todaysPhotos;
        }
        else if (d == e) {
            endVal += todaysPhotos;
        }
    });

    //Percent change in total photos
    percentChange = endVal - startVal / endVal;
    return [totalValidPhotos, percentChange.toFixed(1)];
}

/**
 * 
 * Get avg number of users for data in range
 * and return the total as well as the percent change
 * @param {any} data from the user model
 * @param {any} start the starting day in the data range
 * @param {any} end the ending day in the data range
 */
function calculateAvgActiveUsers(data, start, end) {

    var totalUsers = 0;
    var percentChange = 0;
    var s = moment(start, "MM/DD/YYYY").format('L');
    var e = moment(end, "MM/DD/YYYY").format('L');
    var startVal = 0;
    var endVal = 0;

    //Add all users together and get first and last
    data.forEach(function (arrayItem) {
        todaysUsers = arrayItem.value;
        totalUsers += todaysUsers;
        //first and last 
        var d = moment(arrayItem.date, "MM/DD/YYYY").format('L');
        if (d == s) {
            startVal += todaysUsers;
        }
        else if (d == e) {
            endVal += todaysUsers;
        }
    });

    //Calculate avg
    days = getDateRange(start, end);
    avgUsers = totalUsers / days;
    endValAvg = endVal / days;
    startValAvg = startVal / days;

    //Percent change in total photos
    percentChange = endValAvg - startValAvg / endValAvg;
    return [avgUsers.toFixed(0), percentChange.toFixed(1)];
}

/**
 * 
 * Get avg number of installs for data in range
 * and return the total as well as the percent change
 * @param {any} data from the user model
 * @param {any} start the starting day in the data range
 * @param {any} end the ending day in the data range
 */
function calculateAvgInstalls(data, start, end) {

    var totalInstalls = 0;
    var percentChange = 0;
    var s = moment(start, "MM/DD/YYYY").format('L');
    var e = moment(end, "MM/DD/YYYY").format('L');
    var startVal = 0;
    var endVal = 0;

    //Add all users together and get first and last
    data.forEach(function (arrayItem) {
        todaysInstalls = arrayItem.installs;
        totalInstalls += todaysInstalls;
        //first and last 
        var d = moment(arrayItem.date, "MM/DD/YYYY").format('L');
        if (d == s) {
            startVal += todaysInstalls;
        }
        else if (d == e) {
            endVal += todaysInstalls;
        }
    });

    //Calculate avg
    days = getDateRange(start, end);
    avgInstalls = totalInstalls / days;
    endValAvg = endVal / days;
    startValAvg = startVal / days;

    //Percent change in total photos
    percentChange = endValAvg - startValAvg / endValAvg;
    return [avgInstalls.toFixed(0), percentChange.toFixed(1)];
}

//Adds data to the total photo card
function setTotalPhotoCardsData(dataInDateRange, start, end) {
    photos = calculateTotalPhotoCount(dataInDateRange, start, end);
    totalPhotos = photos[0];
    percentChange = photos[1];
    $("#total-photos").text(totalPhotos);
    $("#total-photos-perc").html(percentChange + "% ");
}

//Adds data to the total valid photo card
function setTotalValidPhotoCardsData(dataInDateRange, start, end) {
    photos = calculateTotalValidPhotoCount(dataInDateRange, start, end);
    totalValidPhotos = photos[0];
    percentChange = photos[1];
    $("#valid-photos").text(totalValidPhotos);
    $("#valid-photos-perc").html(percentChange + "% ");
}

//Adds data to the avg user card
function setActiveUserCardsData(dataInDateRange, start, end) {
    users = calculateAvgActiveUsers(dataInDateRange, start, end);
    totalUsers = users[0];
    percentChange = users[1];
    $("#active-users").text(totalUsers);
    $("#active-users-perc").html(percentChange + "% ");
}

//Adds data to the avg new installs card
function setNewInstallsCardsData(dataInDateRange, start, end) {
    users = calculateAvgInstalls(dataInDateRange, start, end);
    totalUsers = users[0];
    percentChange = users[1];
    $("#new-installs").text(totalUsers);
    $("#new-installs-perc").html(percentChange + "% ");
}

//Get range in days 
function getDateRange(start, end) {
    var date1 = moment(start, "MM/DD/YYYY");
    var date2 = moment(end, "MM/DD/YYYY");
    var diff = date2.diff(date1, 'days');
    return diff;
}

//Check if all date ranges have val if not fill it
function zeroFillbyDate(totals, start, end) {

    //Iterate through date range and fill if zero
    for (var d = moment(start, "MM/DD/YYYY"); d <= end; d.add(1, 'days')) {
        //console.log(d.format('L'));

        //If it exists add to total
        containsDateV = containsDateInData(d, totals);
        if (containsDateV != -1) {
            //console.log(d);
        } else {
            //TODO: Remove in production, just for demo
            randInv = Math.floor(Math.random() * Math.floor(2));
            randValid = Math.floor(Math.random() * (3 - 1 + 1)) + 1;
            randInstall = Math.floor(Math.random() * (1 - 0 + 1)) + 0;
            randVal = ((randValid - randInstall < 0) ? 1 : randValid - randInstall);
            //console.log("Kat: " + randInv + " " + randValid);
            totals.push({
                clinic: "Katsina Clinic",
                date: d.format('L'),
                value: randVal,
                installs: randInstall,
                validphotos: randValid,
                invalidphotos: randInv
            });

            randInv = Math.floor(Math.random() * (1 - 0 + 1)) + 0;
            randValid = Math.floor(Math.random() * (3 - 1 + 1)) + 1;
            randInstall = Math.floor(Math.random() * (2 - 0 + 1)) + 0;
            randVal = ((randValid - randInstall < 0) ? 1 : randValid - randInstall);

            totals.push({
                clinic: "Ijora Clinic",
                date: d.format('L'),
                value: randVal,
                installs: randInstall,
                validphotos: randValid,
                invalidphotos: randInv
            });

            randInv = Math.floor(Math.random() * (1 - 0 + 1)) + 0;
            randValid = Math.floor(Math.random() * (2 - 1 + 1)) + 1;
            randInstall = Math.floor(Math.random() * (2 - 0 + 1)) + 0;
            randVal = ((randValid - randInstall < 0) ? 1 : randValid - randInstall);

            totals.push({
                clinic: "Mashegu Clinic",
                date: d.format('L'),
                value: randVal,
                installs: randInstall,
                validphotos: randValid,
                invalidphotos: randInv
            });

            randInv = Math.floor(Math.random() * (1 - 0 + 1)) + 0;
            randValid = Math.floor(Math.random() * (3 - 1 + 1)) + 1;
            randInstall = Math.floor(Math.random() * (2 - 0 + 1)) + 0;
            randVal = ((randValid - randInstall < 0) ? 1 : randValid - randInstall);

            totals.push({
                clinic: "Rawayau Clinic",
                date: d.format('L'),
                value: randVal,
                installs: randInstall,
                validphotos: randValid,
                invalidphotos: randInv
            });
        }
    }
    return totals;
}


//Check if date is in data set
function containsDateInData(obj, list) {
    var i;
    objDate = moment(obj, "MM/DD/YYYY").format('L');

    for (i = 0; i < list.length; i++) {
        listDate = moment(list[i].date, "MM/DD/YYYY").format('L');
        if (listDate === objDate) {
            return i;
        }
    }
    return -1;
}