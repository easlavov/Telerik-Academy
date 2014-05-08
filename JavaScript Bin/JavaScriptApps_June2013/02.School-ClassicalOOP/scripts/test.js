/// <reference path="_references.js" />

var student1 = new Student('Pesho', 'Peshev', 14, 7);
console.log(student1 instanceof Student);
console.log(student1 instanceof Person);
console.log(student1.introduce());

var teacher1 = new Teacher('Atanas', 'Atanasov', 33, 'economics');
console.log(teacher1 instanceof Person);
console.log(teacher1 instanceof Teacher);
console.log(teacher1.introduce());

var class1 = new Class('Class A', teacher1, 20);
class1.addStudent(student1);
class1.formTeacher = teacher1;
var allStuds = class1.getStudents();
console.log(allStuds);