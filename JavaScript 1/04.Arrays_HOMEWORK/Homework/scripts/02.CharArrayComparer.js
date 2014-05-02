var write = jsConsole.writeLine;

// Compares two arrays lexicographically
function arrayComparerLex(arrayOne, arrayTwo) {
    var length = arrayOne.length;
    var sign;

    // Ensure no chars will be compared against nothing
    if (arrayOne.length > arrayTwo.length) {
        length = arrayTwo.length;
    }

    write('Comparison letter by letter:');
    for (var i = 0; i < length; i++) {
        sign = '=';
        if (arrayOne[i] !== arrayTwo[i]) {
            if (arrayOne[i] > arrayTwo[i]) {
                sign = '>';
            } else {
                sign = '<';
            }
        }

        write(arrayOne[i] + ' ' + sign + ' ' + arrayTwo[i]);
    }
}

write('Task: Write a script that compares two char arrays lexicographically (letter by letter).');
write('Look in scripts/02.CharArrayComparer.js for the code.');
write(' ');
write('Testing function.');

// There isn't 'char' data type in JavaScript
var arrayOne = ['g', 'm', 'z', '4', 'g'],
    arrayTwo = ['g', 'p', 'L', 'h'];
write('The first array is:');
write(arrayOne);
write('The second array is:');
write(arrayTwo);

arrayComparerLex(arrayOne, arrayTwo);

write(' ');
write('Test complete.');