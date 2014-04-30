var write = jsConsole.writeLine;

// Returns the third bit (zero based) of a given number
function thirdBit(number) {
    var mask = 1 << 3;
    mask &= number;
    mask >>= 3;
    
    return mask;
}

write('Task: Write a boolean expression for finding if the bit 3 (counting from 0) of a given integer is 1 or 0.');
write('Look in scripts/05.CheckIfThridBitIs0or1.js for the code.');
write(' ');
write('Testing function.');

write('The third bit of the number 1 is ' + thirdBit(1));
write('The third bit of the number 77 is ' + thirdBit(77));
write('The third bit of the number -45777 is ' + thirdBit(-45777));

write(' ');
write('Test complete.');