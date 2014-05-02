var write = jsConsole.writeLine;

// Returns the last digit of given integer as an English word
function returnLastDigit(num) {
    var lastDigit = num % 10;

    switch (lastDigit) {
        case 0: return "zero";
        case 1: return "one";
        case 2: return "two";
        case 3: return "three";
        case 4: return "four";
        case 5: return "five";
        case 6: return "six";
        case 7: return "seven";
        case 8: return "eight";
        case 9: return "nine";
        default: return "NaN";
    }
}

write('Task: Write a function that returns the last digit of given integer as an English word.');
write('Look in scripts/01.RetLastDigitAsWord.js for the code.');
write(' ');
write('Testing function.');

var number1 = 123532;
write('The number is ' + number1);
write('The last digit is ' + returnLastDigit(number1));

var number2 = -140;
write('The number is ' + number2);
write('The last digit is ' + returnLastDigit(number2));

write(' ');
write('Test complete.');