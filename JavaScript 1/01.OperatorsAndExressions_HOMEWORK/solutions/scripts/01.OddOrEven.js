function printOddEven(integer) {
    if (integer % 2 === 0) {
        jsConsole.writeLine("The integer is even.");
    } else {
        jsConsole.writeLine("The integer is odd.");
    }
}

jsConsole.writeLine("Testing the script with two integers.");
jsConsole.writeLine("The first integer is 134: ");
printOddEven(134);
jsConsole.writeLine("The second integer is 13: ");
printOddEven(13);

jsConsole.writeLine("");
jsConsole.writeLine("Test complete");