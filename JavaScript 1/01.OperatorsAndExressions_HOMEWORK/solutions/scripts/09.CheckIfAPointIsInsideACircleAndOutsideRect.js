var write = jsConsole.writeLine;

function Circle(x, y, radius) {
    return {
        x: x,
        y: y,
        radius: radius,
    };
}

function Rectangle(x, y, width, height) {
    return {
        x: x,
        y: y,
        width: width,
        height: height,
    };
}

function isInsideCircle(circle, pointX, pointY) {
    var res = ((pointX - circle.x) * (pointX - circle.x) + (pointY - circle.y) * (pointY - circle.y)) <
        (circle.radius * circle.radius);

    return res;
}

function isOutsideRect(rectangle, pointX, pointY) {
    var res = ((pointX < rectangle.x) || (pointX > rectangle.x + rectangle.width)) ||
    ((pointY > rectangle.y) || (pointY < rectangle.y - rectangle.height));
    
    return res;
}

function isInsideCircleOutsideRect(circle, rectangle, pointX, pointY) {
    var res = isInsideCircle(circle, pointX, pointY) &&
        isOutsideRect(rectangle, pointX, pointY);

    return res;
}

// Circle coords
var circleX = 1;
var circleY = 1;
var circleRadius = 3;
var circle = new Circle(circleX, circleY, circleRadius);
// Rect coords
var rectX = -1;
var rectY = 1;
var rectWidth = 6;
var rectHeight = 2;
var rectangle = new Rectangle(rectX, rectY, rectWidth, rectHeight);


write("Task: Write an expression that checks for given point (x, y) if it is within the circle K( (1,1), 3)" +
    " and out of the rectangle R(top=1, left=-1, width=6, height=2).");
write('Look in scripts/09.CheckIfAPointIsInsideACircleAndOutsideRect.html for the code.');
write(' ');
write('Testing function.');

write('Circle: (1,1), radius 3.');
write('Rectangle: (-1, 1), width 6, height 2.');

write('Point (2,2) is inside the circle and outside the rectangle: ' +
    isInsideCircleOutsideRect(circle, rectangle, 2, 2));
write('Point (3,-0.5) is inside the circle and outside the rectangle: ' +
    isInsideCircleOutsideRect(circle, rectangle, 3, -0.5));

write(' ');
write('Test complete.');