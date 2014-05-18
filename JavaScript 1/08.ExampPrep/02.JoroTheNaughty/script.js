function Solve(params) {
    var vars = params[0].split(' ');
    var arrLength = params.length;
    var n = parseInt(vars[0]);
    var m = parseInt(vars[1]);
    var jumps = parseInt(vars[2]);
    var field = [];
    var startingCoords = params[1].split(' ');
    var currentRow = parseInt(startingCoords[0]);
    var currentCol = parseInt(startingCoords[1]);
    var arrayIndexOfJump = 2;
    var sumOfJumps = 0;

    initMatrix(field);
    fillMatrix(field);

    sumOfJumps = field[currentRow][currentCol];

    while (true) {
        var nextCoords = params[arrayIndexOfJump].split(' ');
        var deltaR = parseInt(nextCoords[0]);
        var deltaC = parseInt(nextCoords[1]);
        currentRow += deltaR;
        currentCol += deltaC;

        if ((currentRow >= n || currentRow < 0) || 
            (currentCol >= m || currentCol < 0)) {
            break;
        }

        sumOfJumps += field[currentRow][currentCol];

        arrayIndexOfJump += 1;
        if (arrayIndexOfJump === arrLength) {
            arrayIndexOfJump = 2;
        }
    }

    var result = 'escaped ' + sumOfJumps;

    return result;

    function initMatrix(matrix) {
        for (var i = 0; i < n; i++) {
            matrix[i] = [];
        }
    }

    function fillMatrix(matrix) {
        var row;
        var col;
        var currentNumber = 1;
        for (row = 0; row < n; row += 1) {
            for (col = 0; col < m; col += 1) {
                matrix[row][col] = currentNumber;
                currentNumber += 1;
            }
        }
    }
}

var testArr = [];
testArr[0] = '6 7 3';
testArr[1] = '0 0';
testArr[2] = '2 2';
testArr[3] = '-2 2';
testArr[4] = '3 -1';

console.log(Solve(testArr));