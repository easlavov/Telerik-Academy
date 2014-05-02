var write = jsConsole.writeLine;

// The function prints the smallest and largest elements in document,
// window and navigator as a whole (not separately).
function printLexSmallAndLargest() {
    var smallest = document.activeElement.toString(),
    largest = '';

    for (var prop in document) {
        if (prop.toString() > largest) {
            largest = prop.toString();
        }

        if (prop.toString() < smallest) {
            smallest = prop.toString();
        }
    }

    for (var prop in window) {
        if (prop.toString() > largest) {
            largest = prop.toString();
        }

        if (prop.toString() < smallest) {
            smallest = prop.toString();
        }
    }

    for (var prop in navigator) {
        if (prop.toString() > largest) {
            largest = prop.toString();
        }

        if (prop.toString() < smallest) {
            smallest = prop.toString();
        }
    }

    write("Smallest property: " + smallest);
    write("Largest property: " + largest);
}



write('Task: Write a script that finds the lexicographically smallest and largest property in document, window and navigator objects');
write('Look in scripts/04.FindLexLargAndSmProp.js for the code.');
write(' ');
write('Testing function.');

printLexSmallAndLargest();

write(' ');
write('Test complete.')