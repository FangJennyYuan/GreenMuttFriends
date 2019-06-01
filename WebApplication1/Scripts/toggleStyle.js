//Select a chart series
$(".overviewcard").click(function () {
    //remove all other selected
    $(".overviewcard").removeClass("active-charts");
    $(this).toggleClass("active-charts");
});