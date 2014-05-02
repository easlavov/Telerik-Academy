var write = jsConsole.writeLine;

// Prints longest sequence of increasing elements
function printMaxSeqIncrElem(array) {
    var currentStreak = 1,
        longestStreak = 0,
        lastCharIndex;

    for (var i = 1; i < array.length; i++) {
        if (array[i] > array[i - 1]) {
            currentStreak++;
            if (currentStreak > longestStreak) {
                longestStreak = currentStreak;
                lastCharIndex = i;
            }
        } else {
            currentStreak = 1;
        }
    }

    if (longestStreak > 1) {
        jsConsole.write('The longest sequence of increasing elements is: ');
        for (i = 0; i < longestStreak; i++) {
            jsConsole.write(array[lastCharIndex - longestStreak + 1 + i] + ' ');
        }

        write(' ');
    } else {
        jsConsole.writeLine('There is no sequence of equal elements!');
    }
}

write('Task: Write a script that finds the maximal increasing sequence in an array.');
write('Look in scripts/04.MaxSeqOfIncreasingElements.js for the code.');
write(' ');
write('Testing function.');

var array = [3, 2, 3, 4, 2, 2, 4, 5, 6, 9, 10, 2, 1, 3, 2, 3, 4, 5, 1, 3, 4, 8];
write('The sequence is ' + array);
printMaxSeqIncrElem(array);

write(' ');
write('Test complete.');