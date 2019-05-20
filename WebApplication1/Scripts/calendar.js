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

/** Update Photos Taken Title and Avg Photos Axis */
function updateGraphTitlesWithDate(start, end) {
    var startS = "from " + start.format('LL');
    var endS = " to " + end.format('LL');
    $(".date").text(startS + endS);
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
        startDate: moment().startOf('year'),
        endDate: moment()
    }, function (start, end, label) {
        updateGraphTitlesWithDate(start, end);
        searchLibraryTablebyDateRange(start, end);
    });
});

/*Search Library table for a Date Range*/
function searchLibraryTablebyDateRange(start, end) {
    $("#library-table tr").each(function (index) {
        if (index !== 0) {
            $row = $(this);
            var id = $row.find("#date-time-col").text();
            console.log("what " + id);
            var dateSearch = new Date(id);
            if (dateSearch >= start && dateSearch <= end) {
                $row.show();
            }
            else {
                $row.hide();
            }
        }
    });
}