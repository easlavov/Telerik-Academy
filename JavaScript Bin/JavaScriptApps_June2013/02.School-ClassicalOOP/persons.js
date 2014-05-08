/// <reference path="D:\Programming\GitHub\Telerik-Academy\JavaScript Bin\JavaScriptApps_June2013\02.School-ClassicalOOP\_reference.js" />

function Person(fName, lName, age) {
    this.firstName = fName;
    this.lastName = lName;
    this.age = age;
}

Person.prototype = {
    _introduce: function () {
        return 'Name: ' + this.firstName + ' ' + this.lastName + ', ' + 'Age: ' + this.age;
    }
};

function Student(fName, lName, age, grade) {
    Person.call(this, fName, lName, age);
    this.grade = grade;
}

Student.prototype = new Person();
Student.prototype.constructor = Student;
Student.prototype.introduce = function () {
    return this._introduce() + ', grade: ' + this.grade;
};

function Teacher(fName, lName, age, speciality) {
    Person.call(this, fName, lName, age);
    this.speciality = speciality;
}

Teacher.prototype = new Person();
Teacher.prototype.constructor = Teacher;
Teacher.prototype.introduce = function () {
    return this._introduce() + ', speciality: ' + this.speciality;
};