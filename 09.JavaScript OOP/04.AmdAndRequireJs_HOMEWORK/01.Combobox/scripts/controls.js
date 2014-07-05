define(['handlebars', 'jquery'], function () {
    var ComboBox;
    ComboBox = (function () {
        function ComboBox(items) {
            this._items = items;
        }

        ComboBox.prototype.render = function (template) {
            var compiledTemplate,
                items,
                content,
                comboBoxFinalHtml;

            compiledTemplate = Handlebars.compile(template);
            items = this._items;
            content = compiledTemplate({items: items});
            comboBoxFinalHtml = attachFunctionality(content);
            return comboBoxFinalHtml;
        };

        // Makes the combo box html code act like a combo box
        function attachFunctionality(content) {
            var $comboBoxContainer,
                $selectedItemContainer,
                comboBoxFinalHtml,
                $wrapper;

            $comboBoxContainer = $('<div>').addClass('combo-box');
            $selectedItemContainer = $('<div>').addClass('selected-item');

            $comboBoxContainer.append($selectedItemContainer);
            $comboBoxContainer.append(content);

            $comboBoxContainer.find('.person-item').addClass('hidden');


            $wrapper = $('<div>').append($comboBoxContainer);
            comboBoxFinalHtml = $wrapper.html();
            return comboBoxFinalHtml;
        }

        return ComboBox;
    }());

    function attachEventHandlers(comboBoxContainer) {
        var $comboBoxContainer = $(comboBoxContainer);
        $comboBoxContainer.on('click', '.selected-item', function () {
            var $this = $(this).parent();
            $this.find('.person-item').removeClass('hidden');
        });

        $comboBoxContainer.on('click', '.person-item', function () {
            var $this = $(this);
            var $thisParent = $this.parent();
            $thisParent.find('.selected-item').html($this.html());
            $thisParent.find('.selected').removeClass('selected');
            $this.addClass('.selected');
            $thisParent.find('.person-item').addClass('hidden');
        });
    }

    function getComboBox(items) {
        var newComboBox;
        newComboBox = new ComboBox(items);
        return newComboBox;
    }

    return {
        ComboBox: getComboBox,
        attachEventHandlers: attachEventHandlers
    }
});