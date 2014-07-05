define(['handlebars'], function () {
    var ComboBox;
    ComboBox = (function () {
        function ComboBox(items) {
            this._items = items;
        }

        ComboBox.prototype.render = function (template) {
            var compiledTemplate,
                items,
                finalHtml;

            compiledTemplate = Handlebars.compile(template);
            items = this._items;
            finalHtml = compiledTemplate({items: items});
            return finalHtml;
        };

        return ComboBox;
    }());

    function getComboBox(items) {
        var newComboBox = new ComboBox(items);
        return newComboBox;
    }

    return {
        ComboBox: getComboBox
    }
});