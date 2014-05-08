/// <reference path="D:\Programming\GitHub\Telerik-Academy\JavaScript Bin\JavaScriptApps_June2013\02.School-ClassicalOOP\_reference.js" />

var student1 = new Student('Pesho', 'Peshev', 14, 7);
console.log(student1 instanceof Student);
console.log(student1 instanceof Person);
console.log(student1.introduce());

var teacher1 = new Teacher('Atanas', 'Atanasov', 33, 'economics');
console.log(teacher1 instanceof Person);
console.log(teacher1 instanceof Teacher);
console.log(teacher1.introduce());
