var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var Persons;
(function (Persons) {
    var Degree = (function () {
        function Degree(discipline, degree) {
            this.discipline = discipline;
            this.degree = degree;
            if (degree < 0) {
                throw {
                    message: "Degree can't be negative."
                };
            }

            this.discipline = discipline;
            this.degree = degree;
        }
        return Degree;
    })();
    Persons.Degree = Degree;

    var Person = (function () {
        function Person(name, age) {
            this.name = name;
            this.age = age;
            this.name = name;
            this.age = age;
        }
        Person.prototype.greet = function () {
            var greeting = 'Helo, my name is ' + this.name;
            return greeting;
        };
        return Person;
    })();
    Persons.Person = Person;

    var Student = (function (_super) {
        __extends(Student, _super);
        function Student(name, age, grade) {
            _super.call(this, name, age);
            this.name = name;
            this.age = age;
            this.grade = grade;
            this.grade = grade;
            this.degrees = [];
        }
        Student.prototype.addDegree = function (discipline, degree) {
            var newDegree = new Degree(discipline, degree);
            this.degrees.push(newDegree);
        };
        return Student;
    })(Person);
    Persons.Student = Student;

    var Teacher = (function (_super) {
        __extends(Teacher, _super);
        function Teacher(name, age, specialty) {
            _super.call(this, name, age);
            this.name = name;
            this.age = age;
            this.specialty = specialty;
            this.specialty = specialty;
        }
        return Teacher;
    })(Person);
    Persons.Teacher = Teacher;
})(Persons || (Persons = {}));

var School;
(function (School) {
    var Class = (function () {
        function Class() {
            this.students = [];
        }
        Class.prototype.addStudent = function (student) {
            this.students.push(student);
        };

        Class.prototype.setTeacher = function (teacher) {
            this.teacher = teacher;
        };

        Class.prototype.getLowestGradeInClassInDiscipline = function (discipline) {
            var lowestGrade = 0;
            this.students.forEach(function (student) {
            });
        };
        return Class;
    })();
    School.Class = Class;
})(School || (School = {}));

var testPerson = new Persons.Person('Emo', 25);
debugger;
console.log(testPerson.greet());
//# sourceMappingURL=app.js.map
