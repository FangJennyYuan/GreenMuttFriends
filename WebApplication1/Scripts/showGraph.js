function updateStatus(checkBoxId) {
    var checkBox = document.getElementById("id-of-input" + checkBoxId);
    // Get the output text
    var graph = document.getElementById("image");

    // If the checkbox is checked, display the output text
    if (checkBox.checked == true) {
        //window.localStorage.setItem('checked', true);
        localStorage.checked = true;
        //setStatus(checkBoxId);
        //graph.style.display = "block";
    } else {
        //window.localStorage.setItem('checked', false);
        localStorage.checked = false;
        //setStatus(checkBoxId);
        //graph.style.display = "none";
    }
}

window.ready = function setStatus(checkBoxId) {
    document.querySelector("id-of-input" + checkBoxId).checked = window.localStorage.getItem('checked');
}

/*
function checkCookie(checkBoxId) {
    var id = getCookie("id-of-input" + checkBoxId);
    if (id != "id-of-input" + checkBoxId) {
        showGraph(checkBoxId);
    } else {
        var checkBox = document.getElementById("id-of-input"+checkBoxId);
        if (checkBox != null) {
            setCookie("checkBox", checkBox, 5);
        }
    }
}
*/