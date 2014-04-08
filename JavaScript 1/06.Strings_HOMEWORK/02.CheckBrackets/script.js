taskName = "2. Check if in a given expression the brackets are put correctly";

function checkBrackets(expr) {
    // Part 1: put all brackets in an array
    var brackets = new Array();
    for (var i = 0; i < expr.length; i++) {
        if (expr[i] === '(') {
            brackets.push('(')
        }
        else if (expr[i] === ')') {
            brackets.push(')')
        }
    }

    // Part 2: go through the brackets array and remove corresponding brackets
    var startIndex = 0;
    while (startIndex < brackets.length) {
        if (brackets[startIndex] === '(') {
            var closingIndex = startIndex + 1;
            while (closingIndex < brackets.length) {
                if (brackets[closingIndex] === ')') {
                    brackets.splice(closingIndex, 1);
                    brackets.splice(startIndex, 1);
                    startIndex = -1;
                    break;
                }
                closingIndex++;
            }
        }
        startIndex++;
    }
    // If brackets remain, then they've been placed incorrectly
    if (brackets.length > 0) {
        return false;
    }
    return true;
}

// Test scripts
function Main(bufferElement) {
    
    var input = ReadLine('Enter new expression or use default: ', '((a + b /) 5 - d*x-z(d))');

    SetSolveButton(function () {
        
        var toCheck = input.value;
        var areCorrect = checkBrackets(toCheck);
        if (areCorrect) {
            WriteLine('The brackets are correct.');
        }
        else {
            WriteLine('The brackets are not correct.');
        }
        
        
    });
}