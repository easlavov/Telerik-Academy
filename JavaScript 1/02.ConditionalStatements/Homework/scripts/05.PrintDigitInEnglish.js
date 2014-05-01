var write = jsConsole.writeLine;

// Returns the English name of a digit
function digitInEnglish(digit) {
    switch (digit) {
        case 0: return "Zero";
        case 1: return "One";
        case 2: return "Two";
        case 3: return "Three";
        case 4: return "Four";
        case 5: return "Five";
        case 6: return "Six";
        case 7: return "Seven";
        case 8: return "Eight";
        case 9: return "Nine";
        default: return "Not a digit!";
    }
}

write('Task: Write script that asks for a digit and depending on the input' +
    ' shows the name of that digit (in English) using a switch statement.');
write('Look in scripts/05.PrintDigitInEnglish.js for the code.');
write(' ');
write('Testing function.');

write('Passing the number 4: ' + digitInEnglish(4));
write('Passing the number 3: ' + digitInEnglish(3));
write('Passing the number 9: ' + digitInEnglish(9));
write('Passing the number 0: ' + digitInEnglish(0));
write('Passing the number 44: ' + digitInEnglish(44));

write('');
write('Test complete.');