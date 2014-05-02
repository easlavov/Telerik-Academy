var write = jsConsole.writeLine;

var currentChar,
currentStreak = 1,
longestStreak = 0,
lastCharIndex;

// Returns most frequent number in an array
function getMostFrequent(array) {
    var currentChar,
        currentStreak = 1,
        longestStreak = 0,
        lastCharIndex;

    // sorting array
    array.sort(orderBy);

    // using algorithm from task 03
    currentChar = array[0]
    for (var i = 1; i < array.length; i++) {
        if (array[i] === currentChar) {
            currentStreak++;
            if (currentStreak > longestStreak) {
                longestStreak = currentStreak;
                lastCharIndex = i;
            }
        } else {
            currentStreak = 1;
            currentChar = array[i];
        }
    }

    if (longestStreak > 1) {
        return array[lastCharIndex];

    } else {
        return null;
        
    }
}

function orderBy(a, b) {
    return (a === b) ? 0 : (a > b) ? 1 : -1
}

write('Write a program that finds the most frequent number in an array.');
write('Look in scripts/06.FindMostFrequentNumber.js for the code.');
write(' ');
write('Testing function.');


var array = [4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3];
write('Test array is: ' + array);
var number = getMostFrequent(array);
if (number !== null) {
    write('Most frequent number is ' + number);
} else {
    write('There is no number appearing more frequently than others!')
}

write(' ');
write('Test complete.');