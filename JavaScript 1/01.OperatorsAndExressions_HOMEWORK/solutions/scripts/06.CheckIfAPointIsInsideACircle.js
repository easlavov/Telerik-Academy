var write = jsConsole.writeLine;
var circleX = 0;
var circleY = 0;
var circleRadius = 5;

// Returns if a point is inside a circle
function isInsideCircle(circleX, circleY, radius, pointX, pointY) {
    var insideCircle =
        ((pointX - circleX) * (pointX - circleX) + (pointY - circleY) * (pointY - circleY)) <
        (radius * radius);

    return insideCircle;
}

write('Task: Write an expression that checks if given print (x,  y) is within a circle K(O, 5).');
write('Look in scripts/06.CheckIfAPointIsInsideACircle.js for the code.');
write(' ');
write('Testing function.');

write('The circle coords are (0,0) and its radius is 5.');
write('Point 1 coords: 2.5, 1.3. Is it inside the circle? ' +
    isInsideCircle(circleX, circleY, circleRadius, 2.5, 1.3));
write('Point 2 coords: 4, -2. Is it inside the circle? ' +
    isInsideCircle(circleX, circleY, circleRadius, 4, -2));
write('Point 2 coords: 5, 0. Is it inside the circle? ' +
    isInsideCircle(circleX, circleY, circleRadius, 5, 0));

write(' ');
write('Test complete.');