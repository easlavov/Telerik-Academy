var write = jsConsole.writeLine;

// Retursn the greatest of the passed parameters
function greatestNum() {
    var greatest = arguments[0];
    for (var i = 1; i < arguments.length; i++) {
        if (arguments[i] > greatest) {
            greatest = arguments[i];
        }
    }

    return greatest;
}

write('Task: Write a script that finds the greatest of given 5 variables.');
write('Look in scripts/07.FindGreatest.js for the code.');
write(' ');
write('Testing function.');

write('The numbers are: 5, 3, 2, 1, 4, 2, 414, 4, 1, 42, 4');
write('The greatest is: ' + greatestNum(5, 3, 2, 1, 4, 2, 414, 4, 1, 42, 4));
write('The numbers are: -5.2, 432, -111, 1, 4, 2, 414, 4.56, -1324, 42, 4.1');
write('The greatest is: ' + greatestNum(-5.2, 432, -111, 1, 4, 2, 414, 4.56, -1324, 42, 4.1));

write('');
write('Test complete.');