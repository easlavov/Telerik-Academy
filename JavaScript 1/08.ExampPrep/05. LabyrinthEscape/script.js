function Solve(params) {
    var n = parseInt(params[0].split(' ')[0]);
    var m = parseInt(params[0].split(' ')[1]);
    var currentRow = parseInt(params[1].split(' ')[0]);
    var currentCol = parseInt(params[1].split(' ')[1]);
    var field = [];
    var directions = [];
    var visited = [];
    var sum = 0;
    var visitedCells = 0;
    var outcome;
    
    initMatrix(field);
    fillMatrix(field);    

    initMatrix(directions);
    fillDirectionMatrix(directions);

    initMatrix(visited);
    fillBooleanMatrix(visited);

    while (true) {
        sum += field[currentRow][currentCol];
        visited[currentRow][currentCol] = true;
        visitedCells += 1;
        var nextDirection = directions[currentRow][currentCol];
        switch (nextDirection) {
            case 'r': currentCol += 1; break;
            case 'l': currentCol -= 1; break;
            case 'u': currentRow -= 1; break;
            case 'd': currentRow += 1; break;
        }

        if ((currentRow >= n || currentRow < 0) ||
            (currentCol >= m || currentCol < 0)) {
            outcome = 'out ';
            break;
        } else if (visited[currentRow][currentCol] === true) {
            outcome = 'lost ';
            break;
        }
    }

    var result;
    if (outcome === 'out ') {
        result = outcome + sum;
    } else {
        result = outcome + visitedCells;
    }

    return result;

    function initMatrix(matrix) {
        for (var i = 0; i < n; i++) {
            matrix[i] = [];
        }
    }

    function fillDirectionMatrix(matrix) {
        var row;
        var col;
        var line;
        for (row = 0, line = 2; row < n; row += 1, line += 1) {
            var inputRow = params[line];
            for (col = 0; col < m; col += 1) {
                matrix[row][col] = inputRow[col];
            }
        }
    }

    function fillBooleanMatrix(matrix) {
        var row;
        var col;
        for (row = 0; row < n; row += 1) {
            for (col = 0; col < m; col += 1) {
                matrix[row][col] = false;
            }
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

args = [
 "3 4",
 "1 3",
 "lrrd",
 "dlll",
 "rddd"];

args2 = [
 "5 8",
 "0 0",
 "rrrrrrrd",
 "rludulrd",
 "durlddud",
 "urrrldud",
 "ulllllll"];

Solve(args2);