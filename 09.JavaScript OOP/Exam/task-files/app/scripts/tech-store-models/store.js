define(['tech-store-models/item'], function (Item) {
    'use strict';
    var Store;
    String.prototype.contains = function (str) {
        if (this.indexOf(str) >= 0) {
            return true;
        } else {
            return false;
        }
    };

    Store = (function () {
        var NAME_MIN_LENGTH = 6;
        var NAME_MAX_LENGTH = 40; // As Ivaylo said
        function Store(name) {
            if (!validateName(name)) {
                throw {
                    message: 'Invalid argument.'
                }
            }

            this.name = name;
            this._items = [];
        }

        Store.prototype.addItem = function (item) {
            if (!item instanceof Item) {
                throw {
                    message: 'Invalid Argument. "Item" should be of type Item.'
                }
            }

            this._items.push(item);
            return this;
        };

        Store.prototype.getAll = function () {
            var copiedArray = this._items.slice();
            sortAlphabetically(copiedArray);
            return copiedArray;
        };

        Store.prototype.getSmartPhones = function () {
            var filteredArray = getItemsByType(this._items, ['smart-phone']);
            sortAlphabetically(filteredArray);
            return filteredArray;
        };

        Store.prototype.getMobiles = function () {
            var filteredArray = getItemsByType(this._items, ['smart-phone', 'tablet']);
            sortAlphabetically(filteredArray);
            return filteredArray;
        };

        Store.prototype.getComputers = function () {
            var filteredArray = getItemsByType(this._items, ['pc', 'notebook']);
            sortAlphabetically(filteredArray);
            return filteredArray;
        };

        Store.prototype.filterItemsByType = function (type) {
            var filteredArray = getItemsByType(this._items, [type]);
            sortAlphabetically(filteredArray);
            return filteredArray;
        };

        Store.prototype.filterItemsByPrice = function (opts) {
            var options = opts || {};
            var min = options.min || 0;
            var max = options.max || Infinity;
            var filteredArray = [];
            this._items.forEach(function (item) {
                var itemPrice = item.getPrice();
                if (min < itemPrice &&
                    itemPrice < max) {
                    filteredArray.push(item);
                }
            });
            sortByPrice(filteredArray);
            return filteredArray;
        };

        Store.prototype.countItemsByType = function () {
            var itemsByType = {}; // was [] originally
            this._items.forEach(function (item) {
                var currentItemType = item.getType();
                if (itemsByType[currentItemType]) {
                    itemsByType[currentItemType] += 1;
                } else {
                    itemsByType[currentItemType] = 1;
                }
            });

            return itemsByType;
        };

        Store.prototype.filterItemsByName = function (partOfName) {
            var filteredArray = getItemsByContainingInName(this._items, partOfName);
            sortAlphabetically(filteredArray);
            return filteredArray;
        };

        function getItemsByType(originalArray, type) {
            var filteredArray = [];
            originalArray.forEach(function (item) {
                var currentItemType = item.getType();
                if (type.contains(currentItemType)) {
                    filteredArray.push(item);
                }
            });

            sortAlphabetically(filteredArray);
            return filteredArray;
        }

        function getItemsByContainingInName(items, partOfName) {
            var filteredArray = [];
            items.forEach(function (item) {
                var itemName = item.getName();
                if (itemName.toLowerCase().contains(partOfName)) {
                    filteredArray.push(item);
                }
            });

            return filteredArray;
        }

        function sortAlphabetically(array) {
            array.sort(function (itemOne, itemTwo) {
                if (itemOne.getName().toLowerCase() < itemTwo.getName().toLowerCase()) return -1;
                if (itemOne.getName().toLowerCase() > itemTwo.getName().toLowerCase()) return 1;
                return 0;
            });
        }

        function sortByPrice(array) {
            array.sort(function (itemOne, itemTwo) {
                if (itemOne.getPrice() < itemTwo.getPrice()) return -1;
                if (itemOne.getPrice() > itemTwo.getPrice()) return 1;
                return 0;
            });
        }

        function validateName(name) {
            if (typeof name === 'string' ||
                typeof name === 'String') {
                if (name.length < NAME_MIN_LENGTH ||
                    NAME_MAX_LENGTH < name.length) {
                    return false;
                }
            } else {
                return false;
            }

            return true;
        }

        return Store;
    }());

    return Store;
});