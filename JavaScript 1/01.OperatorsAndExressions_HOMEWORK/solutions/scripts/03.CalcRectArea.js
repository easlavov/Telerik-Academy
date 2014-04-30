var write = jsConsole.writeLine;

// Returns the area of a rectangle
function rectArea(width, length) {
    return width * length;
}

// Print message
write('Task: Write an expression that calculates rectangle’s area by given width and height.');
write('Look in scripts/03.CalcRectArea.js for the code.');
write(' ');
write('Testing function.');

write('The area of a rectangle with sides 3 and 5 is: ' + rectArea(3, 5) + ' square units.');
write('The area of a rectangle with sides 7 and 5.8 is: ' + rectArea(7, 5.8) + ' square units.');
write('The area of a rectangle with sides 314.65 and 7.15 is: ' + rectArea(314.65, 7.15) + ' square units.');
write('');

write('Test complete.');