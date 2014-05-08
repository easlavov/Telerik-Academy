/// <reference path="_references.js" />

var pers1 = Object.create(Person);
pers1.init('Alex', 'Petrov', 22);

var stud1 = Object.create(Student);
stud1.init('Kiro', 'Kirev', 14, 7);

var stud2 = Object.create(Student);
stud2.init('Mario', 'Peshev', 22, 2);

console.log(stud1.introduce());
console.log(stud2.introduce());
console.log(pers1.introduce());
var l;