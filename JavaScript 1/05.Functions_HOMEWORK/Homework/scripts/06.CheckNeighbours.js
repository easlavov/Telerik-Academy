var write = jsConsole.writeLine;

function compareNeighbours(index, arr) {
    if (index <= 0 || index >= arr.length - 1) {
        return 'No neighbours or Index out of range';
    }

    if (arr[index] > arr[index - 1] && arr[index] > arr[index + 1]) {
        return true;
    } else {
        return false;
    }
}

function checkIndex(array, index) {
    if (compareNeighbours(index, array)) {
        jsConsole.writeLine(array[index] + ' is bigger than ' + array[index - 1] + ' and ' + array[index + 1]);
    } else {
        jsConsole.writeLine(array[index] + ' is not bigger than ' + array[index - 1] + ' and ' + array[index + 1]);
    }
}

write('Task: Write a function that checks if the element at given position in given array of integers is bigger than its two neighbors (when such exist).');
write('Look in scripts/06.CheckNeighbours.js for the code.');
write(' ');
write('Testing function.');

var array = [4, 1, 4, 2, 3, 4, 1, 2, 6, 5, 3, 2, 7, 5, 1, 4, 2, 3, 2, 1, 3, 5, 2, 35, 6];
write('The array is ' + array);
write('Checking number at index 15:');
checkIndex(array, 15);
write(' ');

write('Checking number at index 7:');
checkIndex(array, 7);

write(' ');
write('Test complete.');