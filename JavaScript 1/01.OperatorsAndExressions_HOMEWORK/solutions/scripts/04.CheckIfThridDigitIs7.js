var write = jsConsole.writeLine;

// Returns if the third digit of a given number is 7
function isThirdDigit7(number) {
    // Logical OR with operand 0 is applied to the result of the division to ensure an integer.
    var thirdDigit = Math.abs(((number / 100) | 0) % 10);
    if (thirdDigit === 7) {
        return true;
    }

    return false;
}

write('Task: Write an expression that checks for given integer if its third digit (right-to-left) is 7.');
write('Look in scripts/04.CheckIfThridDigitIs7.js for the code.');
write(' ');
write('Testing function.');

write('The thrid digit of the number 1 is 7: ' + isThirdDigit7(1));
write('The thrid digit of the number 7 is 7: ' + isThirdDigit7(7));
write('The thrid digit of the number 715 is 7: ' + isThirdDigit7(715));
write('The thrid digit of the number -12715 is 7: ' + isThirdDigit7(-12715));

write(' ');
write('Test complete.');