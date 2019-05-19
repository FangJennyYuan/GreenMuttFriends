﻿/** Get Weeks Date */
function getWeeksDate() {
    var start = moment().subtract(6, 'days');
    var end = moment();
    $('#date_input').data('daterangepicker').setStartDate(start);
    $('#date_input').data('daterangepicker').setEndDate(end);
    updateGraphTitlesWithDate(start, end);
}

/** Get Current Months Date */
function getMonthsDate() {
    var start = moment().startOf('month');
    var end = moment();
    $('#date_input').data('daterangepicker').setStartDate(start);
    $('#date_input').data('daterangepicker').setEndDate(end);
    updateGraphTitlesWithDate(start, end);
}

/** Get Years Date */
function getYearsDate() {
    var start = moment().startOf('year');
    var end = moment();
    $('#date_input').data('daterangepicker').setStartDate(start);
    $('#date_input').data('daterangepicker').setEndDate(end);
    updateGraphTitlesWithDate(start, end);
}
/** Update Photos Taken Title and Avg Photos Axis */
function updateGraphTitlesWithDate(start, end) {
    var startS = "from " + start.format('LL');
    var endS = " to " + end.format('LL');
    $(".date").text(startS + endS);
}


$(function () {
    $('input[name="daterange"]').daterangepicker({
        opens: 'left',
        startDate: moment().subtract(6, 'days'),
        endDate: moment()
    }, function (start, end, label) {
        updateGraphTitlesWithDate(start, end);
        //console.log("A new date selection was made: " + start.format('YYYY-MM-DD') + ' to ' + end.format('YYYY-MM-DD'));
    });
});