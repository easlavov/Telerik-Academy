var circleX = 1;
var circleY = 1;
var circleRadius = 3;

var rectX = -1;
var rectY = 1;
var rectWidth = 6;
var rectHeight = 2;

var pointX = 4.5;
var pointY = 0;

var isInsideCircle = (pointX - circleX) * (pointX - circleX)
    + (pointY - circleY) * (pointY - circleY) < circleRadius * circleRadius;

var isOutsideRectangle = ((pointX < rectX) || (pointX > rectX + rectWidth)) ||
    ((pointY > rectY) || (pointY < rectHeight - rectHeight));

if (isInsideCircle && isOutsideRectangle) {
    jsConsole.writeLine("The point is inside the circle and outside the rectangle.")
}
else {
    jsConsole.writeLine("The point is either otside the circle or/and inside the rectangle.")
}