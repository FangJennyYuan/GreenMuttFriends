
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
 * 
 * Get total count of users for data in range
 * and return the total as well as the percent change
 * @param {any} data from the user model
 * @param {any} start the starting day in the data range
 * @param {any} end the ending day in the data range
 */
function calculateTotalUserCount(data, start, end) {




}