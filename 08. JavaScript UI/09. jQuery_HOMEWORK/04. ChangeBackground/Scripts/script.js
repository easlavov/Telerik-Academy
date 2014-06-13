/// <reference path="_references.js" />
$('#color-picker').on('change', function () {
    var color = $('#color-picker').val();
    $('body').css('background', color);
});