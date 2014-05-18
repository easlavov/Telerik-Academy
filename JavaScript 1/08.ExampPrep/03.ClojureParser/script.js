function Solve(params) {
    params = params.map(function (str) {
        return str.
            trim().
            slice(1).
            trim().
            replace('def ', '').
            trim();
    });

    // Extract name-value string pairs
    var functions = [];
    for (var param = 0; param < params.length; param++) {
        var command = params[param];
        var firstWhiteSpace = command.indexOf(' ');
        var funcName = command.slice(0, firstWhiteSpace).trim();
        var funcValue = command.slice(firstWhiteSpace).trim();
        var newFunc = {
            name: funcName,
            value: funcValue
        };
        functions.push(newFunc);
    }

    // Calc values
    for (var l = 0; l < functions.length; l++) {
        if (l !== functions.length - 1) {
            var fValue = functions[l].value;
            var calcResult = calculate(fValue);
            if (calcResult === false) {
                var line = l + 1;
                return 'Division by zero! At Line:' + line;
            }
            functions[l].value = calcResult;
        } else {
            var fakeName = functions[functions.length - 1].name + ' ';
            var fakeExpression = fakeName + functions[functions.length - 1].value;
            return calculate(fakeExpression);
        }
    }

    function calculate(expression) {
        expression = removeBrackets(expression);
        var operation = expression[0];
        if (operation === '+' ||
            operation === '-' ||
            operation === '*' ||
            operation === '/') {
            var operands = expression.slice(1).trim().split(' ');
            operands = parseOperands(operands);
            switch (operation) {
                case '+': return add(operands);
                case '-': return subtract(operands);
                case '*': return multiply(operands);
                case '/': return divide(operands);
            }
        } else {
            var newArr = [];
            newArr[0] = expression;
            return parseOperands(newArr)[0];
        }
        
    }

    function removeBrackets(expression) {
        // remove trailing brackets
        while (true) {
            if (expression[expression.length - 1] === ')') {
                expression = expression.slice(0, expression.length - 1).trim();
            } else {
                break;
            }
        }

        // remove leading bracket
        if (expression[0] === '(') {
            expression = expression.slice(1).trim();
        }

        return expression;
    }

    function parseOperands(operands) {
        var numArr = [];
        for (var i = 0; i < operands.length; i++) {
            if (operands[i] !== '') {
                if (isFinite(operands[i])) {
                    numArr.push(parseInt(operands[i]));
                } else {
                    numArr.push(getFuncValue(operands[i]));
                }
            }
        }
        
        return numArr;
    }

    function getFuncValue(functionName) {
        for (var j = 0; j < functions.length; j++) {
            if (functions[j].name === functionName) {
                return functions[j].value;
            }
        }
    }    

    function add(array) {
        var sum = 0;
        for (var func = 0; func < array.length; func += 1) {
            sum += array[func];
        }

        return sum;
    }

    function subtract(array) {
        var minuend = array[0];
        for (var func = 1; func < array.length; func += 1) {
            minuend -= array[func];
        }

        return minuend;
    }

    function multiply(array) {
        var product = 1;
        for (var func = 0; func < array.length; func += 1) {
            product *= array[func];
        }

        return product;
    }

    function divide(array) {
        var dividend = parseInt(array[0]);
        for (var func = 1; func < array.length; func += 1) {
            if (array[func] === 0) {
                return false;
            }
            dividend /= array[func];
        }

        return dividend | 0;
    }
}

var input = [];
input[0] = '(def kir4o 100)';
input[1] = '(def cafeFunc (+ kir4o kir4o 3))';
input[2] = '(def tabFunc (* cafeFunc 7))';
input[3] = '(def tabfunc (- kir4o 5 4 3 2 1))';
input[4] = '(/ tabFunc  tabfunc)';

var input2 = [];

/*(def kir4o 100)
(def cafeFunc (+ kir4o kir4o 3))
(def tabFunc (* cafeFunc 7))
(def tabfunc (- kir4o 5 4 3 2 1))
(/ tabFunc  tabfunc)*/

var res = Solve(input);
console.log(res);
var end;