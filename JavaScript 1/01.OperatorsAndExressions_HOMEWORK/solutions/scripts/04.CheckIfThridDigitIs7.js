//var firstNumber = 1234;
var secondNumber = 2756;

// Logical OR with operand 0 is applied to the result of the division
// to ensure an integer.
var thirdDigit = ((secondNumber / 100) | 0) % 10;
jsConsole.writeLine("The third digit is " + thirdDigit);