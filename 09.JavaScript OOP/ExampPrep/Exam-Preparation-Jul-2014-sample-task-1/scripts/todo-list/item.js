define(function () {
    'use strict';
    var Item;
    Item = (function () {
        function Item(content) {
            if (typeof content !== 'string' &&
                typeof content !== 'String') {
                throw new Error('Invalid argument. Content should be a string.');
            }

            this._content = content;
        }

        Item.prototype.getData = function () {
            var content = this._content;
            return {
                content: content
            }
        };

        return Item;
    })();

    return Item;
});