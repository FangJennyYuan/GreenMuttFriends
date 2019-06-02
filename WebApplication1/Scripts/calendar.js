/** Get Weeks Date */
function getWeeksDate() {
    var start = moment().subtract(6, 'days');
    var end = moment();
    $('#date-input').data('daterangepicker').setStartDate(start);
    $('#date-input').data('daterangepicker').setEndDate(end);
    updateGraphTitlesWithDate(start, end);
}

/** Get Current Months Date */
function getMonthsDate() {
    var start = moment().startOf('month');
    var end = moment();
    $('#date-input').data('daterangepicker').setStartDate(start);
    $('#date-input').data('daterangepicker').setEndDate(end);
    updateGraphTitlesWithDate(start, end);
}

/** Get Years Date */
function getYearsDate() {
    var start = moment("4/1/2019");
    var end = moment();
    $('#date-input').data('daterangepicker').setStartDate(start);
    $('#date-input').data('daterangepicker').setEndDate(end);
    updateGraphTitlesWithDate(start, end);
}

/** Get Current Clinic Selection */
function getClinicSelection() {
    var clinic = "";
    $(".clinic-photos option:selected").each(function () {
        clinic = $(this).text() + " ";
    });
    return clinic;
}

/** Check if Clinic is Selected*/
function isInClinic(columnValue) {

    var selected = getClinicSelection();
    var selectedClinic = $.trim(selected);
    var clinic = $.trim(columnValue);

    if (clinic == selectedClinic || selectedClinic == "All Clinics") {
        return true;
    }
    else {
        return false;
    }
}

/** Update Photos Taken Title and Avg Photos Axis */
function updateGraphTitlesWithDate(start, end) {
    var startS = "from " + start.format('LL');
    var endS = " to " + end.format('LL');
    $(".date").text(startS + endS);
}

/** Add Start and End attributes to be Recognized by Other Filters */
function addDateAttributes(start, end) {
    $(".filtered-by-date").attr("datestart", start.format("M/D/YYYY"));
    $(".filtered-by-date").attr("dateend", end.format("M/D/YYYY"));
}

/** Update Result Title with Correct Date Range Selected*/
function updateResultTitleWithDate(start, end, resultCount) {
    //Update title with date
    var startS = "from " + start.format('LL');
    var endS = " to " + end.format('LL');
    $(".filtered-by-date").text(startS + endS);

    //Update title with result count
    $(".count-photos").text(resultCount);

    addDateAttributes(start, end);
}

/**Update Range on Calendar for Performance and Impact*/
$(function () {
    $('input[name="daterange"]').daterangepicker({
        opens: 'left',
        startDate: moment().subtract(6, 'days'),
        endDate: moment()
    }, function (start, end, label) {
        updateGraphTitlesWithDate(start, end);
        });
    updateGraphTitlesWithDate(moment().subtract(6, 'days'), moment());
});

/**Update Date Range on Library Calendar*/
$(function () {
    $('input[name="daterange-library"]').daterangepicker({
        opens: 'left',
        startDate: moment().startOf('month'),
        endDate: moment()
    }, function (start, end, label) {
        var resultCount = searchLibraryTablebyDateRange(start, end);
        updateResultTitleWithDate(start, end, resultCount);
        filterLibraryGalleryByDate(start, end);

        });
    var resultCount = searchLibraryTablebyDateRange(moment().startOf('month'), moment());
    updateResultTitleWithDate(moment().startOf('month'), moment(), resultCount);
    filterLibraryGalleryByDate(moment().startOf('month'), moment());
});

/**Search Library table for a Date Range*/
function searchLibraryTablebyDateRange(start, end) {
    var resultCount = 0;

    $("#library-table tr").each(function (index) {
        if (index !== 0) {

            $row = $(this);
            var idDate = $row.find("#date-time-col").text();
            var dateSearch = new Date(idDate);
            var idClinic = $row.find("#clinic-col").text();

            if (dateSearch >= start && dateSearch <= end) {
                if (isInClinic(idClinic)) {
                    $row.show();
                    resultCount++;
                }
                else {
                    $row.hide();
                }
            }
            else {
                $row.hide();
            }
        }
    });
    return resultCount;
}

/*Filter Library Gallery results based on date*/
function filterLibraryGalleryByDate(start, end) {
    //Check each gallery div
    $("#view-gal #item-gal").each(function () {
        $myItem = $(this);

        //Get dates
        var idDate = $myItem.find("#date-time-gal").text().trim();
        var dateSearch = moment(idDate, "M/D/YYYY");

        //Check if both clinic and date match
        if (dateSearch >= start && dateSearch <= end) {
            $myItem.show();
        }
        else {
            $myItem.hide();
        }
    });
};




/* Apply button style to dates*/
function applyButtonStyleDates(elem) {
    $(".calendar-filter").removeClass("active-date-range");
    parent = $(elem).parent();
    parent.toggleClass("active-date-range");
}