taskName = "1. Planar coordinate system";

// Constructor for Point object
function buildPoint(x, y) {
    return {
        x: x,
        y: y,
        toString: function () {
            return 'P(' + this.x + ',' + this.y + ')';
        }
    }
}

// Constructor for Line object
function buildLine(point1, point2) {
    return {
        point1: point1,
        point2: point2,
        toString: function () {
            return 'L(' + this.point1 + ')' + ',' + '' + this.point2 + ')';
        }
    }
}

// Calculates distance between points
function pointDist(point1, point2) {
    var xDiff = (point2.x - point1.x) * (point2.x - point1.x);
    var yDiff = (point2.y - point1.y) * (point2.y - point1.y);
    var diffSum = xDiff + yDiff;
	
    return Math.sqrt(diffSum);
}

// Calculates line length (uses pointDist)
function lineLength(line) {
    return pointDist(line.point1, line.point2);
}

// Returns if 3 lines can form a triangle
function canFormTriangle(line1, line2, line3) {
    var a = lineLength(line1);
    var b = lineLength(line2);
    var c = lineLength(line3);
    if ((a + b > c) && (a + c > b) && (c + b > a)) {
        return true;
    } else {
        return false;
    }
}

// Test scripts
function Main(bufferElement) {
    WriteLine('Enter x and y of all points in the format "x,y" or use the default values then press Solve:')
    var p1Input = ReadLine('Point1: ', '5,3');
    var p2Input = ReadLine('Point2: ', '-2,0');
    var p3Input = ReadLine('Point3: ', '5,6');
    var p4Input = ReadLine('Point4: ', '0,1');
    var p5Input = ReadLine('Point5: ', '2,2');
    var p6Input = ReadLine('Point6: ', '1,6');    

    SetSolveButton(function () {                
        var pointsCoords = [p1Input.value, p2Input.value, p3Input.value, p4Input.value, p5Input.value, p6Input.value];
        performFunctionTests(pointsCoords);        
    });
}

function performFunctionTests(pointsCoords) {
    var pointsArray = convertCoordsToPoints(pointsCoords);
    var a, b, c;
    a = buildLine(pointsArray[0], pointsArray[1]);
    b = buildLine(pointsArray[2], pointsArray[3]);
    c = buildLine(pointsArray[4], pointsArray[5]);

    WriteLine('The distance between Point1 and Point6 is ' + pointDist(pointsArray[0], pointsArray[5]) + ' units');
    WriteLine('The length of a is: ' + lineLength(a) + ' units');
    WriteLine('The length of b is: ' + lineLength(b) + ' units');
    WriteLine('The length of c is: ' + lineLength(c) + ' units');
    if (canFormTriangle(a, b, c) == true) {
        WriteLine('The three lines can form a triangle');
    } else {
        WriteLine('The three lines can not form a triangle');
    }
	
    WriteLine('*********************************')
}

function convertCoordsToPoints(pointsCoords) {
    var pointsArray = new Array(pointsCoords.length);
    for (var i = 0; i < pointsArray.length; i++) {
        var splitPoint = pointsCoords[i].split(',');
        var x = splitPoint[0];
        var y = splitPoint[1];
        pointsArray[i] = buildPoint(x, y);
    }
	
    return pointsArray;
}