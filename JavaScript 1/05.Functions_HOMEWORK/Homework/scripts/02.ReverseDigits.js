var write = jsConsole.writeLine;

function reverseDigits(number) {
    var negative = false;
    if (number < 0) {
        negative = true;
        number = Math.abs(number);
    }
    var numAsString = number.toString();

    var reversed = '';
    for (var i = numAsString.length - 1; i >= 0; i--) {
        reversed += numAsString[i];
    }

    if (negative) {
        reversed = '-' + reversed;
    }

    return reversed;
}

write('Task: Write a function that reverses the digits of given decimal number.');
write('Look in scripts/02.ReverseDigits.js for the code.');
write(' ');
write('Testing function.');

var number = 12345;
write('The test number is ' + number);
write('The reversed number is ' + reverseDigits(number));
write('');

var number2 = -12345;
write('The test number is ' + number2);
write('The reversed number is ' + reverseDigits(number2));

write(' ');
write('Test complete.');