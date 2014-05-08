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

function Class(name, formTeacher, capacity) {
    var students = [];
    this.name = name;
    this.formTeacher = formTeacher;
    this.capacity = capacity;

    this.getStudents = function () {
        return students;
    }
}

Class.prototype = {
    addStudent: function (student) {
        if (student instanceof Student) {
            var studs = this.getStudents();
            if (studs.length < this.capacity) {
                studs.push(student);
            } else {
                throw 'The class has reached its maximum capacity';
            }
        } else {
            throw 'Invalid argument';
        }
    },
    removeStudent: function (student) {
        this.getStudents().remove(student);
    }
}


function School(name, town) {
    var classes = [];
    this.name = name;
    this.town = town;

    this.getClasses = function () {
        return classes;
    }
}

School.prototype = {
    addClass : function (schoolClass) {
        if (schoolClass instanceof Class) {
            this.getClasses().push(schoolClass);
        } else {
            throw 'Invalid argument';
        }
    },
    removeClass : function (schoolClass) {
        this.getClasses().remove(schoolClass);
    }
}