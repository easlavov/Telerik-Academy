define(function () {
    'use strict';
    var Item;
    Array.prototype.contains = function(obj) {
        var i = this.length;
        while (i--) {
            if (this[i] === obj) {
                return true;
            }
        }
        return false;
    };

    Item = (function () {
        var TYPES = [
            'accessory',
            'smart-phone',
            'notebook',
            'pc',
            'tablet'
        ];
        var NAME_MIN_LENGTH = 6;
        var NAME_MAX_LENGTH = 40; // As Ivaylo said
        function Item(type, name, price) {
            if (!validateArguments(type, name, price)) {
                throw {
                    message: 'Invalid Arguments.'
                }
            }

            this._type = type;
            this._name = name;
            this._price = price;
        }

        Item.prototype.getName = function () {
            var name = this._name;
            return name;
        };

        Item.prototype.getType = function () {
            var type = this._type;
            return type;
        };

        Item.prototype.getPrice = function () {
            var price = this._price;
            return price;
        };

        function validateArguments(type, name, price) {
            if (!TYPES.contains(type)) {
                return false;
            }

            if (typeof name === 'string' ||
                typeof name === 'String') {
                if (name.length < NAME_MIN_LENGTH ||
                    NAME_MAX_LENGTH < name.length) {
                    return false;
                }
            } else {
                return false;
            }

            if (typeof price !== 'number' &&
                typeof price !== 'Number') {
                return false;
            } else if (price < 0) { // Price can't be negative
                return false;
            }

            return true;
        }

        return Item;
    }());

    return Item;
});