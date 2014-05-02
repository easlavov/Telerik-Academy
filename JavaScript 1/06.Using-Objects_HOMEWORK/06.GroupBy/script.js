taskName = "6. Group by";

function personBuilder(fName, lName, age) {
    return {
        firstName: fName,
        lastName: lName,
        age: age,
        toString: function () {
            return this.firstName + ' ' + this.lastName + ', ' + this.age;
        }
    }
}

function groupBy(array, key) {
    var result = {};
    var currentKeyValue;
    var pers;

    if (key == 'age') {        
        for (pers in array) {
            currentKeyValue = array[pers].age;
            add(currentKeyValue);
        }
    } else if (key == 'firstName') {
        for (pers in array) {
            currentKeyValue = array[pers].firstName;
            add(currentKeyValue);
        }
    } else if (key == 'lastName') {
        for (pers in array) {
            currentKeyValue = array[pers].lastName;
            add(currentKeyValue);
        }
    }

    function add(keyValue) {
        if (result.hasOwnProperty(keyValue)) {
            result[keyValue].push(array[pers]);
        } else {
            result[keyValue] = new Array();
            result[keyValue].push(array[pers]);
        }
    }

    return result;
}

function Main(bufferElement) {
    WriteLine('An array of 5 persons has been hard coded.');
    var persons = new Array(5);
    persons[0] = personBuilder('Toni', 'Petrov', 45);
    persons[1] = personBuilder('Ivan', 'Geshov', 45);
    persons[2] = personBuilder('Toni', 'Tonev', 35);
    persons[3] = personBuilder('Stefan', 'Petrov', 60);
    persons[4] = personBuilder('Monika', 'Mihneva', 60);
    
    WriteLine('The array contains the following persons:');
    for (var pers in persons) {
        WriteLine(persons[pers]);
    }

    WriteLine("Press Solve to group by age, first name and last name.");

    SetSolveButton(function () {
        var grouped = groupBy(persons, 'age');
        WriteLine('Grouped by age')
        printRes(grouped);
        WriteLine('****************');

        grouped = groupBy(persons, 'firstName');
        WriteLine('Grouped by first name');
        printRes(grouped);
        WriteLine('****************');

        grouped = groupBy(persons, 'lastName');
        WriteLine('Grouped by last name');
        printRes(grouped);
        WriteLine('****************');
    });

    function printRes(grouped) {
        for (var res in grouped) {
            WriteLine('Key value: ' + res);
            for (var i in grouped[res]) {
                WriteLine('----' + grouped[res][i]);
            }
        }
    }
}