var write = jsConsole.writeLine;

// Prints whether an integer is odd or even
function printOddEven(integer) {
    if (integer % 2 === 0) {
        write("The integer is even.");
    } else {
        write("The integer is odd.");
    }
}

// Print message
write('Task: Write an expression that checks if given integer is odd or even.');
write('Look in scripts/01.OddOrEven.js for the code.');
write(' ');

write("Testing the script with four integers.");
jsConsole.write("The first integer is 134: ");
printOddEven(134);
jsConsole.write("The second integer is 13: ");
printOddEven(13);
jsConsole.write("The third integer is -123134: ");
printOddEven(-123134);
jsConsole.write("The fourth integer is -101: ");
printOddEven(-101);

write('');
write("Test complete");