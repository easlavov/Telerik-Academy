var write = jsConsole.writeLine;

function print1toNNotDivBy3and7(number) {
    for (var i = 1; i <= number; i++) {
        if (!(i % 21 === 0)) {
            jsConsole.write(i + ' ');
        }
    }
}

write('Task: Write a script that prints all the numbers from 1 to N, that are not divisible by 3 and 7 at the same time');
write('Look in scripts/02.PrintNumsFrom1toNNotDivBy3and7.js for the code.');
write(' ');
write('Testing function.');

write('Testing with 100');
print1toNNotDivBy3and7(100);

write(' ');
write('Test complete.');