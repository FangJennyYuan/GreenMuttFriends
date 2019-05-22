
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
    $("#library-table tr").each(function (index) {
        if (index !== 0) {
            $row = $(this);

            //Get clinic from row
            var idClinic = $row.find("#clinic-col").text();
            var clinic = $.trim(idClinic);
            var searchValue = $.trim(value);

            //Get date from row
            var idDate = $row.find("#date-time-col").text();
            
            //Check if both clinic and date match
            if (clinic == searchValue) {
                if (inDateRange(idDate)) {
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
 };
