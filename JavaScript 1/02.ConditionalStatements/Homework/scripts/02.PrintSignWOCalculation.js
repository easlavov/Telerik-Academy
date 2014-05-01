var write = jsConsole.writeLine;

// Can't pass numbers by ref in a simple way ;( !@#$ javascript!

// Returns the sign of the product of three numbers without calculating it
function multiplicationSign(num1, num2, num3) {
    var neg = 0;
    if (num1 < 0) {
        neg++;
    }

    if (num2 < 0) {
        neg++;
    }

    if (num3 < 0) {
        neg++;
    }

    if (neg === 1 || neg === 3) {
        return 'negative';
    } else {
        return 'positive';
    }
}

write('Task: Write a script that shows the sign (+ or -) of the product of three real numbers' +
    ' without calculating it. Use a sequence of if statements.');
write('Look in scripts/02.PrintSignWOCalculation.js for the code.');
write(' ');
write('Testing function.');

write('The sign of product of the numbers -3, 5 and -6 is ' + multiplicationSign(-3, 5, -6));
write('The sign of product of the numbers 3, 5 and -6 is ' + multiplicationSign(3, 5, -6));
write('The sign of product of the numbers 3, 5 and 6 is ' + multiplicationSign(-3, 5, -6));
write('The sign of product of the numbers -3, -5 and -6 is ' + multiplicationSign(-3, -5, -6));

write('Test complete.');