/// <reference path="_references.js" />

Array.prototype.remove = function (item) {
    for (var i = 0; i < length; i++) {
        if (this[i] === item) {
            this.splice(i, 1);
            return;
        }
    }

    throw 'Element not found';
};

var School = {
    init: function (name, town) {
        this.name = name;
        this.town = town;
        this._classes = [];
    },
    addClass: function (schoolClass) {
        this._classes.push(schoolClass);
    },
    removeClass: function (schoolClass) {
        this._classes.remove(schoolClass);
    },
};

var Class = {
    init: function (name, capacity, formTeacher) {
        this.name = name;
        this.capacity = capacity;
        this.formTeacher = formTeacher;
        this._students = [];
    },
    addStudent: function (student) {
        if (this._students.length < this.capacity) {
            this._students.push(student);
        }
    },
    removeStudent: function (student) {
        this._students.remove(student);
    },
};