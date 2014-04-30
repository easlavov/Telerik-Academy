var write = jsConsole.writeLine;

// Calculates a trapezoid's area
function trapezoidArea(sideA, sideB, height) {
    return ((sideA + sideB) / 2) * height;
}

write("Task: Write an expression that calculates trapezoid's area by given sides a and b and height h.");
write('Look in scripts/08.CalcTrapezoidArea.js for the code.');
write(' ');
write('Testing function.');

write('The are of a trapezoid with sides 5, 3 and height 3 is ' + trapezoidArea(5, 3, 3) + ' square units.');
write('The are of a trapezoid with sides 2.5, 3.8 and height 200 is ' + trapezoidArea(2.5, 3.8, 200) + ' square units.');

write(' ');
write('Test complete.');