var circleX = 0;
var circleY = 0;
var circleRadius = 5;
var pointX = 2.5;
var pointY = 1.3;

var isInsideCircle = (pointX - circleX) * (pointX - circleX)
    + (pointY - circleY) * (pointY - circleY) < circleRadius * circleRadius;

if (isInsideCircle) {
    jsConsole.writeLine("The point is inside the circle.")
}
else {
    jsConsole.writeLine("The point is not inside the circle.")
}