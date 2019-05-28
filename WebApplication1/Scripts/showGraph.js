function showGraph() {
    var checkBox = document.getElementById("id-of-input1");
    // Get the output text
    var graph = document.getElementById("image");

    // If the checkbox is checked, display the output text
    if (checkBox.checked == true) {
        graph.style.display = "block";
    } else {
        graph.style.display = "none";
    }
}