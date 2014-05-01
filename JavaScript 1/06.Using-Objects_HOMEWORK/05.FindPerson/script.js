taskName = "5. Find person";

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

function printYoungest(array) {
    var minAge = array[0].age;
    var indexOfYoungest = 0;
    for (var i = 1; i < array.length; i++) {
        if (array[i].age < minAge) {
            indexOfYoungest = i;
        }
    }
    WriteLine(array[indexOfYoungest].firstName + ' ' + array[indexOfYoungest].lastName);
}

function Main(bufferElement) {
    WriteLine('An array of 5 persons has been hard coded.');
    var persons = new Array(5);
    persons[0] = personBuilder('Gencho', 'Petrov', 45);
    persons[1] = personBuilder('Ivan', 'Geshov', 50);
    persons[2] = personBuilder('Toni', 'Tonev', 34);
    persons[3] = personBuilder('Stefan', 'Lambov', 60);
    persons[4] = personBuilder('Monika', 'Mihneva', 28);
    
    WriteLine('The array contains the following persons:');
    for (var pers in persons) {
        WriteLine(persons[pers]);
    }

    WriteLine("Press Solve to print the youngest person's first and last names.");

    SetSolveButton(function () {
        printYoungest(persons);
    });
}