//Save library filter input to session storage, then reload saved filters when navigating back to page
$(document).ready(function () {
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
        $('#date-input').data('daterangepicker').setStartDate(sessionStorage.dateStart);
        $('#date-input').data('daterangepicker').setEndDate(sessionStorage.dateEnd);
        needToFilter = true;
    }
    // Trigger page filters if updates have been made
    if (needToFilter) {
        filterLibraryTable();
        filterLibraryGallery();
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
        sessionStorage.dateStart = $(".filtered-by-date").attr("datestart");
        sessionStorage.dateEnd = $(".filtered-by-date").attr("dateend");
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
