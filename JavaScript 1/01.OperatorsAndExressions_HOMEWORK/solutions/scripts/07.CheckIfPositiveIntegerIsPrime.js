var integer = 91;

var ceiling = Math.floor(Math.sqrt(integer));
var prime = true;
for (var i = 2; i < ceiling; i++) {
    if (integer % i === 0) {
        prime = false;
        break;
    }
};
if (prime) {
    jsConsole.writeLine("The number is prime.");
}
else {
    jsConsole.writeLine("The number is not prime.");
}