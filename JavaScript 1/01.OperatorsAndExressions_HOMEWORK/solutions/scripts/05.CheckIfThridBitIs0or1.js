var number = 11;

var mask = 1;
mask <<= 3;
mask &= number;
mask >>= 3;
if (mask === 1) {
    jsConsole.writeLine("The 3rd bit is 1.")
}
else {
    jsConsole.writeLine("The 3rd bit is 0.")
}