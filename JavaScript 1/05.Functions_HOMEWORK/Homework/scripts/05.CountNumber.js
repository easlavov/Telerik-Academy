var write = jsConsole.writeLine;

function countNumber(num, arr) {
    var counter = 0;
    for (var p in arr) {
        if (arr[p] === num) {
            counter++;
        }
    }
    return counter;
}

function test(array) {
    write('The array is ' + array);
    write("The number 3 appears " + countNumber(3, array) + ' times in the arrary');
    write("The number 8 appears " + countNumber(8, array) + ' times in the arrary');
    write("The number 15 appears " + countNumber(15, array) + ' times in the arrary');
}

write('Task: Write a function that counts how many times given number appears in given array.' +
    ' Write a test function to check if the function is working correctly.');
write('Look in scripts/05.CountNumber.js for the code.');
write(' ');
write('Testing function.');

var array = [6, 5, 3, 6, 8, 9, 0, 3, 8, 1, 3, 6, 7, 9, 0];
var array2 = [3, 6, 8, 9, 0, 15, 8, 1, 3, 6, 7, 9, 0, 8, 8];
test(array);
test(array2);

write(' ');
write('Test complete.');