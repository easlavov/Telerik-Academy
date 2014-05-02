var write = jsConsole.writeLine;

// Returns the index of an element in an array or -1 if not present
function binarySearch(sortedArray, number) {
    var left = 0,
        right = sortedArray.length - 1,
        middle,
        index;

    while (true) {
        if (right < left) {
            index = -1;
            break;
        }

        middle = Math.floor((right + left) / 2);
        if (number < sortedArray[middle]) {
            right = middle - 1;
            continue;
        } else if (number > sortedArray[middle]) {
            left = middle + 1;
            continue;
        } else if (number === sortedArray[middle]) {
            index = middle;
            break;
        }
    }

    if (index >= 0) {
        return index;
    } else {
        return -1;
    }
}



write('Task: Write a program that finds the index of given element in a sorted array' +
    ' of integers by using the binary search algorithm ');
write('Look in scripts/07.BinarySearch.js for the code.');
write(' ');
write('Testing function.');

var sortedArray = [-20, 0, 15, 16, 18, 315, 1000, 450000, 10000000];
write('The sorted array is: ' + sortedArray);
var index = binarySearch(sortedArray, 15);
write('The index of 15 is ' + index);

write(' ');
write('Test complete.');