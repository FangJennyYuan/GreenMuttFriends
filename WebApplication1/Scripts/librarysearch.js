
/*Search Library table by Input Bar*/
function searchLibraryTable() {
    var input, value;
    input = document.getElementById("library-search");
    value = input.value;
    searchLibraryTablebyValue(value);
}


/*Search Library table for a Value*/
function searchLibraryTablebyValue(value) {
    $("#library-table tr").each(function (index) {
        if (index !== 0) {
            $row = $(this);
            var id = $row.text();
            if (id.indexOf(value) !== -1) {
                $row.show();
            }
            else {
                $row.hide();
            }
        }
    });
}

/** Update Result Title with Count of Results */
function updateResultTitle(count, clinic) {
    $(".count-photos").text(count);
    $(".filtered-by-clinic").text(clinic);
}

/*Search library table by Drop Down of Clinic*/
$(function () {
    $(".clinic-photos").change(function () {
        var clinic = "";
        $(".clinic-photos option:selected").each(function () {
            clinic = $(this).text() + " ";
        });
        var resultCount = searchLibraryTablebyClinic(clinic);
        updateResultTitle(resultCount, clinic);
    });

});

/*Check Date Range Selected*/
function inDateRange(date) {

    //Date range selected
    var dateStart = $(".filtered-by-date").attr("datestart");
    var start = moment(dateStart, "M/D/YYYY");
    var dateEnd = $(".filtered-by-date").attr("dateend");
    var end = moment(dateEnd, "M/D/YYYY");

    //Convert to search string to date
    var dateSearch = moment(date, "M/D/YYYY");

    if (dateSearch >= start && dateSearch <= end) {
        return true;
    }
    else {
        return false;
    }
}

/*Search library table for a Clinic, Apply Date Range Filter As Well*/
function searchLibraryTablebyClinic(value) {
    var resultCount = 0;

    //Confirm whether valid/invalid checkboxes are checked
    var showValid = document.getElementById('valid-checkbox').checked;
    var showInvalid = document.getElementById('invalid-checkbox').checked;

    $("#library-table tr").each(function (index) {
        if (index !== 0) {
            $row = $(this);

            //Get clinic from row
            var idClinic = $row.find("#clinic-col").text();
            var clinic = $.trim(idClinic);
            var selectedClinic = $.trim(value);

            //Get date from row
            var idDate = $row.find("#date-time-col").text();

            //Get bilirubin result from row
            var result = $row.find("#result-col").text();
            
            //Check if both clinic and date match
            if (clinic == selectedClinic || selectedClinic == "All Clinics") {
                if (inDateRange(idDate)) {

                    //Filter hits based on valid/invalid checkboxes
                    //Show all results
                    if (showInvalid && showValid) {
                        $row.show();
                        resultCount++;
                    }
                    //Show valid results only
                    else if (!showInvalid && showValid) {
                        if (result.includes("Invalid")) {
                            $row.hide();
                        }
                        else {
                            $row.show();
                            resultCount++;
                        }
                    }
                    //Show invalid results only
                    else if (showInvalid && !showValid) {
                        if (result.includes("Invalid")) {
                            $row.show();
                            resultCount++;
                        }
                        else {
                            $row.hide();
                        }
                    }
                    //Hide all results
                    else if (!showInvalid && !showValid) {
                        $row.hide();
                    }

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
 };


//Filter results when invalid checkbox is clicked
$(function () {
    $("#invalid-checkbox").click(function () {
        filterLibraryTable();
    });

});

//Filter results when valid checkbox is clicked
$(function () {
    $("#valid-checkbox").click(function () {
        filterLibraryTable();
    });

});


/*Filter table results based on values of clinic, date, and valid/invalid inputs*/
function filterLibraryTable() {
    var resultCount = 0;

    //Confirm whether valid/invalid checkboxes are checked
    var showValid = document.getElementById('valid-checkbox').checked;
    var showInvalid = document.getElementById('invalid-checkbox').checked;

    //Get value of clinic from filter
    var clinic = $(".clinic-photos :selected").text();

    $("#library-table tr").each(function (index) {
        if (index !== 0) {
            $row = $(this);

            //Get clinic from row
            var rowClinic = $row.find("#clinic-col").text();

            //Get date from row
            var idDate = $row.find("#date-time-col").text();

            //Get bilirubin result from row
            var result = $row.find("#result-col").text();

            //Check if both clinic and date match
            if (clinic == rowClinic || clinic == "All Clinics") {
                if (inDateRange(idDate)) {

                    //Filter hits based on valid/invalid checkboxes
                    //Show all results
                    if (showInvalid && showValid) {
                        $row.show();
                        resultCount++;
                    }
                    //Show valid results only
                    else if (!showInvalid && showValid) {
                        if (result.includes("Invalid")) {
                            $row.hide();
                        }
                        else {
                            $row.show();
                            resultCount++;
                        }
                    }
                    //Show invalid results only
                    else if (showInvalid && !showValid) {
                        if (result.includes("Invalid")) {
                            $row.show();
                            resultCount++;
                        }
                        else {
                            $row.hide();
                        }
                    }
                    //Hide all results
                    else if (!showInvalid && !showValid) {
                        $row.hide();
                    }

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
    //Update result label with count and clinic selected
    updateResultTitle(resultCount, clinic);
};