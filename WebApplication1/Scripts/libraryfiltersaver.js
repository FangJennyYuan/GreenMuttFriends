//Save library filter input to session storage, then reload saved filters when navigating back to page
$(document).ready(function () {
    if (document.getElementById('valid-checkbox')) {
        // If stored filters exist, reload their values onto page
        var needToFilter = false;
        if (sessionStorage.clinic) {
            $(".clinic-photos").val(sessionStorage.clinic);
            needToFilter = true;
        }
        if (sessionStorage.valid) {
            if (sessionStorage.valid == "false") {
                $('#valid-checkbox').prop('checked', false);
                needToFilter = true;
            }
        }
        if (sessionStorage.invalid) {
            if (sessionStorage.invalid == "false") {
                $('#invalid-checkbox').prop('checked', false);
                needToFilter = true;
            }
        }
        if (sessionStorage.dateStart && sessionStorage.dateEnd) {
            var myStart = moment(sessionStorage.dateStart);
            var myEnd = moment(sessionStorage.dateEnd);
            $('#date-input').data('daterangepicker').setStartDate(myStart);
            $('#date-input').data('daterangepicker').setEndDate(myEnd);
            var resultCount = searchLibraryTablebyDateRange(myStart, myEnd);
            updateResultTitleWithDate(myStart, myEnd, resultCount);
            needToFilter = true;
        }
        // Trigger page filters if updates have been made
        if (needToFilter) {
            filterLibraryTable();
            filterLibraryGallery();
        }
    }
});

// Save clinic filter state when change detected
$(function () {
    $(".clinic-photos").change(function () {
        sessionStorage.clinic = $(".clinic-photos").val();
    });
});

// Save date input filter state when change detected
$(function () {
    $("#date-input").change(function () {
        if (document.getElementById('valid-checkbox')) {
            sessionStorage.dateStart = $(".filtered-by-date").attr("datestart");
            sessionStorage.dateEnd = $(".filtered-by-date").attr("dateend");
        }
    });
});

// Save valid checkbox state when change detected
$(function () {
    $("#valid-checkbox").change(function () {
        sessionStorage.valid = $("#valid-checkbox").prop('checked');
    });
});

// Save invalid checkbox state when change detected
$(function () {
    $("#invalid-checkbox").change(function () {
        sessionStorage.invalid = $("#invalid-checkbox").prop('checked');
    });
});

// Resets filters to default when reset button is clicked
$(document).on('click', '#reset-button', function () {
        resetFilters();
});

// Restore filters to default state
function resetFilters() {
    // Reset clinic
    $(".clinic-photos").val("all");

    // Reset date filters
    var myStart = moment(moment().startOf('month'));
    var myEnd = moment();
    $('#date-input').data('daterangepicker').setStartDate(myStart);
    $('#date-input').data('daterangepicker').setEndDate(myEnd);
    var resultCount = searchLibraryTablebyDateRange(myStart, myEnd);
    updateResultTitleWithDate(myStart, myEnd, resultCount);

    // Reset checkboxes
    $('#invalid-checkbox').prop('checked', true);
    $('#valid-checkbox').prop('checked', true);

    // Filter results
    filterLibraryTable();
    filterLibraryGallery();

    // Update saved filters in session storage
    sessionStorage.clinic = $(".clinic-photos").val();
    sessionStorage.dateStart = $(".filtered-by-date").attr("datestart");
    sessionStorage.dateEnd = $(".filtered-by-date").attr("dateend");
    sessionStorage.invalid = $("#invalid-checkbox").prop('checked');
    sessionStorage.valid = $("#valid-checkbox").prop('checked');
}