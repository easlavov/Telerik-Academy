var paper = Raphael('spiral', 800, 800);

drawSpiral(250, 250, 0, 5, 475, false, paper);

function drawSpiral(centerX, centerY, a, b, size, clockwise, context) {
    var centralPoint = "M" + centerX + ' ' + centerY;
    var spiralPoints = [centralPoint];
    var i, angle, x, y;

    for (i = 0; i < size; i++) {
        angle = 0.1 * i;
        //using the Archimedian spiral equation r = a + b * angle;
        // a sets the offset from the central point
        // b - the distance between turnings
        if (clockwise) {
            x = centerX + (a + b * angle) * Math.cos(angle),
            y = centerY + (a + b * angle) * Math.sin(angle);
        } else {
            x = centerX + (a + b * angle) * Math.sin(angle),
            y = centerY + (a + b * angle) * Math.cos(angle);
        }

        spiralPoints.push('L ' + x + ' ' + y);

    }

    var spiralPointsStr = spiralPoints.join(' ');
    context.path(spiralPointsStr);
}