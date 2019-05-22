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
    var start = moment().startOf('year');
    var end = moment();
    $('#date-input').data('daterangepicker').setStartDate(start);
    $('#date-input').data('daterangepicker').setEndDate(end);
    updateGraphTitlesWithDate(start, end);
}

/** Get current clinic selection */
function getClinicSelection() {
    var clinic = "";
    $(".clinic-photos option:selected").each(function () {
        clinic = $(this).text() + " ";
    });
    return clinic;
}

/** Check if clinic is selected*/
function isInClinic( columnValue ) {
    var selected = getClinicSelection();
    var clinic = $.trim(columnValue);

    if (clinic == $.trim(selected)) {
        console.log(clinic);
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


/* Update result title with correct date range selected*/
function updateResultTitleWithDate(start, end) {
    var startS = "from " + start.format('LL');
    var endS = " to " + end.format('LL');
    $(".filtered-by-date").text(startS + endS);
    $(".filtered-by-date").attr("datestart", start.format("M/D/YYYY"));
    $(".filtered-by-date").attr("dateend", end.format("M/D/YYYY"));
}

/*Update range on calendar for performance and impact*/
$(function () {
    $('input[name="daterange"]').daterangepicker({
        opens: 'left',
        startDate: moment().subtract(6, 'days'),
        endDate: moment()
    }, function (start, end, label) {
        updateGraphTitlesWithDate(start, end);
    });
});

/*Update range on library calendar*/
$(function () {
    $('input[name="daterange-library"]').daterangepicker({
        opens: 'left',
        startDate: moment().startOf('month'),
        endDate: moment()
    }, function (start, end, label) {
        updateResultTitleWithDate(start, end);
        searchLibraryTablebyDateRange(start, end);
        });
    updateResultTitleWithDate(moment().startOf('month'), moment());
});

/*Search Library table for a Date Range*/
function searchLibraryTablebyDateRange(start, end) {
    $("#library-table tr").each(function (index) {
        if (index !== 0) {
            $row = $(this);
            var id = $row.find("#date-time-col").text();
            var dateSearch = new Date(id);

            var idClinic = $row.find("#clinic-col").text();

            if (dateSearch >= start && dateSearch <= end) {
                if (isInClinic(idClinic)) {
                    $row.show();
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
}