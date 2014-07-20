(function () {
    /* Task 1:
     Write a method that from a given array of students
     finds all students whose first name is before its last
     name alphabetically. Print the students in
     descending order by full name. Use Underscore.js
     */

    console.log('Task 1');
    console.log('All students whose first name is before its last name alphabetically.' +
        ' Print the students in descending order by full name.');
    _.chain(studentsArray)
        .filter(isFirstNameBeforeLast)
        .sort(fullName)
        .reverse()
        .forEach(print);

    function isFirstNameBeforeLast(student) {
        return student.firstName < student.lastName;
    }

    function fullName(student) {
        return student.firstName + ' ' + student.lastName;
    }

    function print(item) {
        console.log(item);
    }

    /* Task 2:
     Write function that finds the first name and last
     name of all students with age between 18 and 24.
     Use Underscore.js
     */
    console.log('Task 2');
    console.log('The first name and last name of all students with age between 18 and 24');
    _.chain(studentsArray)
        .filter(isBetween18and24)
        .each(printFirstLastName);

    function isBetween18and24(student) {
        return student.age >= 18 && student.age <= 24;
    }

    function printFirstLastName(student) {
        console.log(fullName(student));
    }

    /* Task 3:
     Write a function that by a given array of students
     finds the student with highest marks
     */
    console.log('Task 3');
    console.log('The student with the highest marks');
    var bestStudent = _.chain(studentsArray)
        .sortBy(studentMark)
        .last().value();

    console.log(bestStudent);

    function studentMark(student) {
        return student.mark;
    }

    /* Task 4:
     Write a function that by a given array of animals,
     groups them by species and sorts them by number of
     legs
     */
    console.log('Task 4');
    console.log('Animals grouped by species and sorted by number of legs');
    _.chain(animalsArray)
        .sortBy(legs)
        .groupBy('species')
        .each(print);

    function legs(animal) {
        return animal.legs;
    }

    /* Task 5:
     By a given array of animals, find the total number of legs
     */
    console.log('Task 5');
    console.log('Total number of legs:');
    var totalLegs = _.chain(animalsArray)
        .map(function (animal) {
            return parseInt(animal.legs);
        })
        .reduce(function (memo, num) {
            return memo + num;
        })
        .value();

    console.log(totalLegs);

    /* Task 6:
     By a given collection of books, find the most popular
     author (the author with the highest number of
     books)
     */
    console.log('Task 6');
    console.log('Most popular author:');
})();





























