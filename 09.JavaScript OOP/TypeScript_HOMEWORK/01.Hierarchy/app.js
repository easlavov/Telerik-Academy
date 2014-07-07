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

        Student.prototype.getDegreeInDiscipline = function (discipline) {
            var degree;
            for (var i = 0; i < this.degrees.length; i++) {
                if (this.degrees[i].discipline === discipline) {
                    degree = this.degrees[i].degree;
                    break;
                }
            }

            return degree;
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
            return this;
        };

        Class.prototype.setTeacher = function (teacher) {
            this.teacher = teacher;
        };

        Class.prototype.getLowestGradeInClassInDiscipline = function (discipline) {
            var lowestGrade;
            this.students.forEach(function (student) {
                var degree = student.getDegreeInDiscipline(discipline);
                if (!lowestGrade) {
                    lowestGrade = degree;
                } else if (degree < lowestGrade) {
                    lowestGrade = degree;
                }
            });

            return lowestGrade;
        };
        return Class;
    })();
    School.Class = Class;
})(School || (School = {}));

var RandomGenerator;
(function (RandomGenerator) {
    function getRandomInt(min, max) {
        return Math.floor(Math.random() * (max - min + 1) + min);
    }
    RandomGenerator.getRandomInt = getRandomInt;
})(RandomGenerator || (RandomGenerator = {}));

var teacherKolev = new Persons.Teacher("Kolev", 45, "Medicine");
var testClass = new School.Class();
testClass.setTeacher(teacherKolev);
testClass.addStudent(new Persons.Student("Ivancho", 15, 8)).addStudent(new Persons.Student("Ivancho", 15, 8)).addStudent(new Persons.Student("Pesho", 15, 8)).addStudent(new Persons.Student("Ginka", 15, 8)).addStudent(new Persons.Student("Stanka", 15, 8)).addStudent(new Persons.Student("Draganka", 15, 8)).addStudent(new Persons.Student("Nikodim", 15, 8)).addStudent(new Persons.Student("Karpat", 15, 8));

testClass.students.forEach(function (student) {
    var degree = RandomGenerator.getRandomInt(1, 75);
    student.addDegree("Medicine", degree);
});

var lowestDegreeInMedicine = testClass.getLowestGradeInClassInDiscipline("Medicine");
console.log("The lowest degree in Medicine in the class is " + lowestDegreeInMedicine);
//# sourceMappingURL=app.js.map
