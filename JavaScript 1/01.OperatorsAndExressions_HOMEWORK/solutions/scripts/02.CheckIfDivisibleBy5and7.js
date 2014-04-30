var write = jsConsole.writeLine;

function printIfDivBy5and7(number) {
    if (number % 35 === 0) {
        write("The integer is divisible by 5 and 7.");
    } else {
        write("The integer is not divisible by 5 and 7.");
    }
}

// Print message
write('Task: Write a boolean expression that checks for given integer if it can be divided (without remainder) by 7 and 5 in the same time.');
write('Look in scripts/02.CheckIfDivisibleBy5and7.js for the code.');
write(' ');

write('Testing function with the number 7:');
printIfDivBy5and7(7);
write('Testing function with the number 64:');
printIfDivBy5and7(64);
write('Testing function with the number 35:');
printIfDivBy5and7(35);
write('Testing function with the number -70:');
printIfDivBy5and7(-70);

write(' ');
write('Test complete');