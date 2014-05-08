/// <reference path="_references.js" />

(function myfunction() {
    if (!Object.create) {
        Object.create = function (obj) {
            function F() { };
            F.prototype = obj;
            return new F();
        }
    }
})();

Object.prototype.extend = function (properties) {
    function F() { };
    F.prototype = Object.create(this);
    for (var prop in properties) {
        F.prototype[prop] = properties[prop];
    }
    F.prototype._super = Object.create(this);
    return new F();
}

var Person = {
    init: function (fName, lName, age) {
        this.firstName = fName;
        this.lastName = lName;
        this.age = age;
    },
    introduce: function () {
        return 'Name: ' + this.firstName + ' ' + this.lastName + ', ' + 'Age: ' + this.age;
    },
    persF: function myfunction() {

    }
};

var Student = {
    init: function (fName, lName, age, grade) {
        this._super.init(fName, lName, age);
        this.grade = grade;
    },
    introduce: function () {
        return 'Name: ' + this.firstName + ' ' + this.lastName + ', ' + 'Age: ' + this.age + ', Grade: ' + this.grade;
    },
    studF: function myfunction() {

    }
}

Student = Person.extend(Student);

var kfsadmnl;