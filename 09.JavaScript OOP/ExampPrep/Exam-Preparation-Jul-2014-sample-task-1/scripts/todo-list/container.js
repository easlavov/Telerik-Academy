define(['todo-list/section'], function (Section) {
    'use strict';
    var Container;
    Container = (function () {
        function Container() {
            this._sections = [];
        }

        Container.prototype.add = function (section) {
            if (section instanceof Section) {
                this._sections.push(section);
            } else {
                throw new Error('Invalid argument. Section should be of type Section.')
            }
        };

        Container.prototype.getData = function () {
            var sections = [];
            this._sections.forEach(function (section) {
                sections.push(section.getData());
            });

            return sections;
        };

        return Container;
    }());

    return Container;
});