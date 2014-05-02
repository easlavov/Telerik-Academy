var write = jsConsole.writeLine;

// Returns an array of integers in which each element has value 5 times its index
function initArray(count) {
    var array = [count];

    for (var i = 0; i < count; i++) {
        array[i] = i * 5;
    }

    return array;
}

write('Task: Write a script that allocates array of 20 integers and initializes each element' +
    ' by its index multiplied by 5. Print the obtained array on the console.');
write('Look in scripts/01.AllocateArray.js for the code.');
write(' ');
write('Testing function.');

var arr = initArray(20);
write(arr);

write(' ');
write('Test complete.');