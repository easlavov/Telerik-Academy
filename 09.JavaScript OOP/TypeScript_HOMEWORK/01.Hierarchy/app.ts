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
        }

        setTeacher(teacher: Persons.Teacher) {
            this.teacher = teacher;
        }

        getLowestGradeInClassInDiscipline(discipline: string) {
            var lowestGrade = 0;
            this.students.forEach(function (student) {

            });
        }

    }
}

var testPerson = new Persons.Person('Emo', 25);
debugger;
console.log(testPerson.greet());