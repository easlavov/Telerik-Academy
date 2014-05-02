var write = jsConsole.writeLine;

// Sorts an array using selection sort algorithm
function selectionSort(array) {
    var pivot,
        current,
        smallest,
        smallestIndex;

    for (pivot = 0; pivot < array.length; pivot++) {
        // find smallest number right of pivot
        smallest = array[pivot];
        smallestIndex = pivot;
        for (current = pivot; current < array.length; current++) {
            if (array[current] <= smallest) {
                smallest = array[current];
                smallestIndex = current;
            }
        }

        array.splice(smallestIndex, 1);
        array.splice(pivot, 0, smallest);
    }
}            

write('Task: Write a script to sort an array. Use the "selection sort" algorithm');
write('Look in scripts/05.SelectionSort.js for the code.');
write(' ');
write('Testing function.');

var array = [64, 25, 12, 22, 11];
write('Unsorted array: ' + array);
selectionSort(array);
write('Sorted array: ' + array);

write(' ');
write('Test complete.');