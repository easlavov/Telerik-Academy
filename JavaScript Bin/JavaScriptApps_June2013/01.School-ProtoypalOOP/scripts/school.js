/// <reference path="_references.js" />

Array.prototype.remove = function (item) {
    for (var i = 0; i < length; i++) {
        if (this[i] === item) {
            this.splice(i, 1);
            return;
        }
    }

    throw 'Element not found';
}
