
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


/*Search library table by Drop Down of Clinic*/
$(function () {
    $(".clinic-photos").change(function () {
        var str = "";
        $(".clinic-photos option:selected").each(function () {
            str = $(this).text() + " ";
        });
        searchLibraryTablebyClinic(str);
    });

});

/*Search library table for a Clinic*/
function searchLibraryTablebyClinic(value) {
    $("#library-table tr").each(function (index) {
        if (index !== 0) {
            $row = $(this);
            var id = $row.find("#clinic-col").text();
            var clinic = $.trim(id);
            var searchValue = $.trim(value);
            if (clinic == searchValue) {
                $row.show();
            }
            else {
                $row.hide();
            }
        }
    });
 };
