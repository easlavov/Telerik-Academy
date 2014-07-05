define(['handlebars', 'jquery'], function () {
    var ComboBox = (function () {
        function ComboBox (items) {
            this._items = items;
        }

        ComboBox.prototype.render = function (template) {
            var template = Handlebars.compile(template);
            var items = this._items;
            var compiledTemplate = template({items:items});
            return compiledTemplate;
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