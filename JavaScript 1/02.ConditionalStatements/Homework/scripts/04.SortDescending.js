var write = jsConsole.writeLine;

function printDescending(numberA, numberB, numberC) {
    if (numberA >= numberB) {
        if (numberA >= numberC) {
            if (numberB >= numberC) {
                write(numberA);
                write(numberB);
                write(numberC);
            } else {
                write(numberA);
                write(numberC);
                write(numberB);
            }
        } else {
            write(numberC);
            write(numberA);
            write(numberB);
        }
    } else if (numberB >= numberA) {
        if (numberB >= numberC) {
            if (numberA > numberC) {
                write(numberB);
                write(numberA);
                write(numberC);
            } else {
                write(numberB);
                write(numberC);
                write(numberA);
            }
        } else {
            write(numberC);
            write(numberB);
            write(numberA);
        }
    }
}

write('Task: Sort 3 real values in descending order using nested if statements.');
write('Look in scripts/04.SortDescending.js for the code.');
write(' ');
write('Testing function.');

write('The numbers are 3, 1, 2:');
printDescending(3, 1, 2);
write(' ');
write('The numbers are 0.5, 1.2, -2.546:');
printDescending(0.5, 1.2, -2.546);
write(' ');
write('The numbers are -21412.43, -1.2421142, -332.546:');
printDescending(-21412.43, -1.2421142, -332.546);