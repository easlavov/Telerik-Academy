var write = jsConsole.writeLine;

// Prints the number from 1 to N
function print1toN(number) {
    for (var i = 1; i <= number; i++) {
        jsConsole.write(i + " ")
    }

    write(' ');
}

write('Task: Write a script that prints all the numbers from 1 to N');
write('Look in scripts/01.PrintNumsFrom1toN.js for the code.');
write(' ');
write('Testing function.');

write('Testing with 10.');
print1toN(10);
write('Testing with 20.');
print1toN(20);

write('Test complete.');