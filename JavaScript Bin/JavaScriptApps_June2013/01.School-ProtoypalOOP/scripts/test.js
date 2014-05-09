/// <reference path="_references.js" />

var pers1 = Object.create(Person);
pers1.init('Alex', 'Petrov', 22);

var stud1 = Object.create(Student);
stud1.init('Kiro', 'Kirev', 14, 7);

var stud2 = Object.create(Student);
stud2.init('Mario', 'Peshev', 22, 2);

var teacher = Object.create(Teacher);
teacher.init('Ivan', 'Atanasov', 34, 'ASP.NET');

console.log(stud1.introduce());
console.log(stud2.introduce());
console.log(teacher.introduce());
var l;

var schoolClass = Object.create(Class);
schoolClass.init('Ninjas', 300, teacher);
schoolClass.addStudent(stud1);
schoolClass.addStudent(stud2);

var school = Object.create(School);
school.init('Telerik', 'Sofia');
school.addClass(schoolClass);

var test;