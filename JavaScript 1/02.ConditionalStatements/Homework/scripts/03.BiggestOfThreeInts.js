var write = jsConsole.writeLine;

// Returns the biggest of three numbers
function biggest(num1, num2, num3) {
    var biggestNum = num1;

    if (num2 > biggestNum) {
        biggestNum = num2;
    }

    if (num3 > biggestNum) {
        biggestNum = num3;
    }

    return biggestNum;
}

write('Task: Write a script that finds the biggest of three integers using nested if statements.');
write('Look in scripts/03.BiggestOfThreeInts.js for the code.');
write(' ');
write('Testing function.');

write('The thre numbers are 5, -2, 3.13. The biggest is ' + biggest(5, -2, 3.13));
write('The thre numbers are -5, -2, 3.13. The biggest is ' + biggest(-5, -2, 3.13));
write('The thre numbers are 5, -2, -3.13. The biggest is ' + biggest(-5, -2, -3.13));

write('Test complete.');