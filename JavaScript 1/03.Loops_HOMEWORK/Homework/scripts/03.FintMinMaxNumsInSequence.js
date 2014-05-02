var write = jsConsole.writeLine;

function printMaxMin(sequence) {
    var max = sequence[0];
    var min = max;

    for (var i = 0; i < sequence.length; i++) {
        if (sequence[i] < min) {
            min = sequence[i];
        }

        if (sequence[i] > max) {
            max = sequence[i];
        }
    }

    write('The min is ' + min + ', the max is ' + max);
}

write('Task: Write a script that finds the max and min number from a sequence of numbers');
write('Look in scripts/03.FintMinMaxNumsInSequence.js for the code.');
write(' ');
write('Testing function.');

var sequence = [65, -12, 33, 45.5, 8000.123, -200, 550, 0, 6];
write('Test sequence is 65, -12, 33, 45.5, 8000.123, -200, 550, 0, 6');
printMaxMin(sequence);