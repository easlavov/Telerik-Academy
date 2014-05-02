var write = jsConsole.writeLine;

// Prints longest sequence of equal elements
function printMaxSequenceOfEqualElements(array) {
    var currentChar = array[0],
        currentStreak = 1,
        longestStreak = 0,
        lastCharIndex;

    for (var i = 1; i < array.length; i++) {
        if (array[i] === currentChar) {
            currentStreak++;
            if (currentStreak > longestStreak) {
                longestStreak = currentStreak;
                lastCharIndex = array[i];
            }
        } else {
            currentChar = array[i];
            currentStreak = 1;
        }
    }

    if (longestStreak > 1) {
        jsConsole.write('The longest sequence of equal elements is: ');
        for (i = 0; i < longestStreak; i++) {
            jsConsole.write(lastCharIndex + ' ');
        }        

        write(' ');
    } else {
        jsConsole.writeLine('There is no sequence of equal elements!');
    }
}

write('Task: Write a script that finds the maximal sequence of equal elements in an array.');
write('Look in scripts/03.MaxSeqOfEqualElements.js for the code.');
write(' ');
write('Testing function.');

var array = [2, 1, 1, 2, 3, 3, 2, 2, 2, 1];
write('The array is: ' + array);
printMaxSequenceOfEqualElements(array);

write(' ');
write('Test complete.');