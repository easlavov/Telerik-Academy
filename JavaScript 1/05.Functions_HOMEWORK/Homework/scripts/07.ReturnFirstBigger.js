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

function firstBiggerThanNeighbours(arr) {
    for (var i = 0; i < arr.length; i++) {
        if (compareNeighbours(i, arr) === true) {
            return i;
        }
    }

    return -1;
}

write('Task: Write a function that returns the index of the first element in array that is bigger than its neighbors,' +
    ' or -1, if there’s no such element. Use the function from the previous exercise.');
write('Look in scripts/07.ReturnFirstBigger.js for the code.');
write(' ');
write('Testing function.');

var array = [4, 1, 4, 2, 3, 4, 1, 2, 6, 5, 3, 2, 7, 5, 1, 4, 2, 3, 2, 1, 3, 5, 2, 35, 6];
var array2 = [1, 1, 1, 1, 1, 1];

write('The array is ' + array);
write('The index of the first element, bigger than its two neighbours, is ' +
    firstBiggerThanNeighbours(array));

write('The next array is ' + array2);
write('The index of the first element, bigger than its two neighbours, is ' +
    firstBiggerThanNeighbours(array2));

write(' ');
write('Test complete.');