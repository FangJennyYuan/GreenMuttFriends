
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

/*Search library table for a Clinic*/
function searchLibraryTablebyClinic(value) {
    var resultCount = 0;
    $("#library-table tr").each(function (index) {
        if (index !== 0) {
            $row = $(this);
            var id = $row.find("#clinic-col").text();
            var clinic = $.trim(id);
            var searchValue = $.trim(value);
            if (clinic == searchValue) {
                $row.show();
                resultCount++;
            }
            else {
                $row.hide();
            }
        }
    });
    return resultCount;
 };
