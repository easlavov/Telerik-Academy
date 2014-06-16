$.fn.tabs = function () {
    var $tabsContainer = $(this);
    $tabsContainer.addClass('tabs-container');
    $tabsContainer.find('.tab-item-content').hide();

    $tabsContainer.find('.tab-item-content').first().show();
    $tabsContainer.find('.tab-item').first().addClass('current');

    $('.tab-item').on('click', '.tab-item-title', function () {
        var $selected = $(this);
        $tabsContainer.find('.tab-item').removeClass('current');
        $tabsContainer.find('.tab-item-content').hide();
        $selected.parent().addClass('current');
        $selected.next().show();
    });
};