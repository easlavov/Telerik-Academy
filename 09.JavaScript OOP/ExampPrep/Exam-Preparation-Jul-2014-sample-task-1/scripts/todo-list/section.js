define(['todo-list/item'],function (Item) {
    'use strict';
    var Section;
    Section = (function () {
        function Section(title) {
            if (typeof title !== 'string' &&
                typeof title !== 'String') {
                throw new Error('Invalid argument. Content should be a string.');
            }

            this._title = title;
            this._items = [];
        }
        
        Section.prototype.add = function (item) {
            if (item instanceof Item) {
                this._items.push(item);
            } else {
                throw new Error('Invalid argument. Item should be of type Item.')
            }
        };

        Section.prototype.getData = function () {
            var title = this._title;
            var items = this._items.map(function (item) {
                return item.getData();
            });

            return {
                title: title,
                items: items
            }
        };

        return Section;
    }());
    return Section;
});