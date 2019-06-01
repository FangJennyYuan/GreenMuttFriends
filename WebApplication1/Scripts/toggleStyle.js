//Select a chart series
$(function () {
    $(".overviewcard").click(function () {
        //remove all other selected
        $(".overviewcard").removeClass("active-charts");
        $(this).toggleClass("active-charts");
    });
});
