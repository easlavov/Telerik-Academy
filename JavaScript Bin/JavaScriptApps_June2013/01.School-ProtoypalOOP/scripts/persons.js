/// <reference path="_references.js" />

(function myfunction() {
    if (!Object.create) {
        Object.create = function (obj) {
            function F() { }
            F.prototype = obj;
            return new F();
        };
    }
})();

Object.prototype.extend = function (properties) {
    function F() { }
    F.prototype = Object.create(this);
    for (var prop in properties) {
        F.prototype[prop] = properties[prop];
    }
    //F.prototype._super = this;
    return new F();
};

var Person = {
    init: function (fName, lName, age) {
        this.firstName = fName;
        this.lastName = lName;
        this.age = age;
    },
    _introduce: function () {
        return 'Name: ' + this.firstName + ' ' + this.lastName + ', ' + 'Age: ' + this.age;
    },
};

var Student = {
    init: function (fName, lName, age, grade) {
        //this._super.init(fName, lName, age);
        Person.init.call(this, fName, lName, age);
        this.grade = grade;
    },
    introduce: function () {
        return this._introduce() + ', Grade: ' + this.grade;
    },
};

Student = Person.extend(Student);

var Teacher = Person.extend({
    init: function (fName, lName, age, speciality) {
        Person.init.call(this, fName, lName, age);
        this.speciality = speciality;
    },
    introduce: function () {
        return this._introduce() + ', Speciality: ' + this.speciality;
    },
});