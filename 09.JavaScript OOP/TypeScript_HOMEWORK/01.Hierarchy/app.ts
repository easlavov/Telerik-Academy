module Interfaces {
    export interface IPerson {
        name: string;
        age: number;
        greet();
    }

    export interface IStudent extends IPerson {
        grade: number;
        degrees: Persons.Degree[];
    }

    export interface ITeacher extends IPerson {
        specialty: string;
    }
}

module Persons {
    export class Degree {
        constructor(public discipline: string, public degree: number) {
            if (degree < 0) {
                throw {
                    message: "Degree can't be negative."
                }
            }

            this.discipline = discipline;
            this.degree = degree;
        }
    }

    export class Person implements Interfaces.IPerson {
        constructor(public name: string, public age: number) {
            this.name = name;
            this.age = age;
        }

        greet() {
            var greeting = 'Helo, my name is ' + this.name;
            return greeting;
        }
    }

    export class Student extends Person implements Interfaces.IStudent {
        degrees: Degree[];

        constructor(public name: string, public age: number, public grade: number) {
            super(name, age);
            this.grade = grade;
            this.degrees = [];
        }

        addDegree(discipline: string, degree: number) {
            var newDegree = new Degree(discipline, degree);
            this.degrees.push(newDegree);
        }

        getDegreeInDiscipline(discipline: string) {
            var degree;
            for (var i = 0; i < this.degrees.length; i++) {
                if (this.degrees[i].discipline === discipline) {
                    degree = this.degrees[i].degree;
                    break;
                }
            }

            return degree;
        }
    }

    export class Teacher extends Person implements Interfaces.ITeacher {
        constructor(public name: string, public age: number, public specialty: string) {
            super(name, age);
            this.specialty = specialty;
        }
    }
}

module School {
    export class Class {
        students: Persons.Student[];
        teacher: Persons.Teacher;

        constructor() {
            this.students = [];
        }

        addStudent(student: Persons.Student) {
            this.students.push(student);
            return this;
        }

        setTeacher(teacher: Persons.Teacher) {
            this.teacher = teacher;
        }

        getLowestGradeInClassInDiscipline(discipline: string) {
            var lowestGrade;
            this.students.forEach(function (student) {
                var degree = student.getDegreeInDiscipline(discipline);
                if (!lowestGrade) {
                    lowestGrade = degree;
                } else if (degree < lowestGrade) {
                    lowestGrade = degree
                }                    
            });

            return lowestGrade;
        }

    }
}

module RandomGenerator {
    export function getRandomInt(min: number, max: number) {
        return Math.floor(Math.random() * (max - min + 1) + min);
    }
}

var teacherKolev = new Persons.Teacher("Kolev", 45, "Medicine");
var testClass = new School.Class();
testClass.setTeacher(teacherKolev);
testClass.addStudent(new Persons.Student("Ivancho", 15, 8))
         .addStudent(new Persons.Student("Ivancho", 15, 8))
         .addStudent(new Persons.Student("Pesho", 15, 8))
         .addStudent(new Persons.Student("Ginka", 15, 8))
         .addStudent(new Persons.Student("Stanka", 15, 8))
         .addStudent(new Persons.Student("Draganka", 15, 8))
         .addStudent(new Persons.Student("Nikodim", 15, 8))
    .addStudent(new Persons.Student("Karpat", 15, 8));

testClass.students.forEach(function (student) {
    var degree = RandomGenerator.getRandomInt(1, 75);
    student.addDegree("Medicine", degree);
});

var lowestDegreeInMedicine = testClass.getLowestGradeInClassInDiscipline("Medicine");
console.log("The lowest degree in Medicine in the class is " + lowestDegreeInMedicine);