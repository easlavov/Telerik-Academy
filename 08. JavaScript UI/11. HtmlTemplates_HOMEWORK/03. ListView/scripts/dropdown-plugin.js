(function ($) {
    $.fn.dropdown = function () {
        var $this = $(this);
        var old = $this;
        $this.css('display', 'none');
        var $newContainer = $('<div>').addClass('dropdown-list-container').insertAfter($this);
        var $list = $('<ul>').addClass('dropdown-list-options');
        $newContainer.append($list);
        var $options = $this.find('option');
        for (var i = 0; i < $options.length; i++) {
            var $newListItemContent = $options[i].text;
            addListItem($list, $newListItemContent, i);
        }

        $list.on('click', 'li', function () {
            $this = $(this);
            var selectedOptionValue = $this.attr('data-value');
            $options[selectedOptionValue - 1].selected = 'true';
        });

        function addListItem($list, $newListItemCntnt, dataValue) {
            var $listItem = $('<li>').text($newListItemCntnt);
            $listItem.attr('data-value', dataValue + 1);
            $list.append($listItem);
        }

        return $this
    };
}(jQuery))