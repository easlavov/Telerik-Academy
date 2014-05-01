var write = jsConsole.writeLine;

write('Task: Write an if statement that examines two integer variables and' +
    'exchanges their values if the first one is greater than the second one.');
write('Look in scripts/01.ConditionalValueExchange.js for the code.');
write(' ');
write('Testing statement.');

write('Test integers 3 and 5.');
var testNum1 = 3, testNum2 = 5;
if (testNum1 > testNum2) {
    var temp = testNum1;
    testNum1 = testNum2;
    testNum2 = temp;
}
write('Test integers after call: ' + testNum1 + ' and ' + testNum2);
write(' ');

write('Test integers 15 and -8.');
var testNum3 = 15, testNum4 = -8;
if (testNum3 > testNum4) {
    var temp = testNum3;
    testNum3 = testNum4;
    testNum4 = temp;
}
write('Test integers after call: ' + testNum3 + ' and ' + testNum4);
write(' ');

write('Test complete.');