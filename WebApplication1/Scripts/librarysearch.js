
/*Search Library table by Input Bar*/
function searchLibraryTable() {
    var input, value;
    input = document.getElementById("library-search");
    value = input.value;
    searchLibraryTablebyValue(value);
}

/*Search Library table for a Value*/
function searchLibraryTablebyValue(value) {
    $("#library_table tr").each(function (index) {
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

