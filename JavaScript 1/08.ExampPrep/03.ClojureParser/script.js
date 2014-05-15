function Solve(params) {
    var i;
    var ln;
    var functionsArray = [];

    for (ln = 0; ln < params.length; ln += 1) {
        if (ln !== params.length - 1) {
            var isValid = readLine(params[ln]);
            if (!isValid) {
                var lineNum = ln + 1;
                var message = 'Division by zero! At Line:' + lineNum;
                return message;
            }
        } else {
            var result = readLine(params[ln], true);
            return result;
        }
    }

    function readLine(line, isLast) {
        var commands = removeEmpty(line.split('('));

        if (isLast) {
            return execute(commands[0]);
        }

        var outcome = execute(commands[0]);
        if (outcome !== false) {
            return true;
        } else {
            return false;
        }

        function execute(command) {
            command = removeEmpty(command.split(' '));
            var commandParameter = command[0];
            switch (commandParameter) {
                case 'def': return define(); break;
                case '+': return add(command.slice(1));
                case '-': return subtract(command.slice(1));
                case '*': return multiply(command.slice(1));
                case '/': return divide(command.slice(1));
            }

            function define() {
                var newFuncName = command[1];
                var newFuncValue;
                if (commands.length > 1) {
                    //newFuncValue = execute(removeEmpty(commands[1].split(' ')));
                    newFuncValue = execute(commands[1]);
                } else {
                    newFuncValue = removeEmpty(command[2]);
                    if (functionsArray[newFuncValue] !== undefined) {
                        newFuncValue = functionsArray[newFuncValue];
                    } else {
                        newFuncValue = parseInt(newFuncValue);
                    }
                }
                functionsArray[newFuncName] = newFuncValue;

                if (isNaN(newFuncValue) || newFuncValue === false) {
                    return false;
                } else {
                    return true;
                }
            }
        }
    }

    function add(array) {
        normalizeStrings(array);
        var sum = 0;
        for (i = 0; i < array.length; i += 1) {
            if (functionsArray[array[i]] !== undefined) {
                array[i] = functionsArray[array[i]];
            }
            array[i] = parseInt(array[i]);
            sum += array[i];
        }

        return sum;
    }

    function subtract(array) {
        normalizeStrings(array)
        var minuend = array[0];
        for (i = 1; i < array.length; i += 1) {
            if (functionsArray[array[i]] !== undefined) {
                array[i] = functionsArray[array[i]];
            }
            array[i] = parseInt(array[i]);
            minuend -= array[i];
        }

        return minuend;
    }

    function multiply(array) {
        normalizeStrings(array)
        var product = 1;
        for (i = 0; i < array.length; i += 1) {
            if (functionsArray[array[i]] !== undefined) {
                array[i] = functionsArray[array[i]];
            }
            array[i] = parseInt(array[i]);
            product *= array[i];
        }

        return product;
    }

    function divide(array) {
        normalizeStrings(array)
        var dividend = parseInt(array[0]);
        for (i = 1; i < array.length; i += 1) {
            if (functionsArray[array[i]] !== undefined) {
                array[i] = functionsArray[array[i]];
            }
            array[i] = parseInt(array[i]);
            if (array[i] === 0) {
                return false;
            }
            dividend /= array[i];
        }

        return dividend;
    }

    function removeEmpty(oldArray) {
        var newArray = [];
        for (i = 0; i < oldArray.length; i += 1) {
            if (oldArray[i] !== '' && oldArray[i] !== ')') {
                newArray.push(oldArray[i]);
            }
        }

        return newArray;
    }

    function normalizeStrings(array) {
        for (k = 0; k < array.length; k += 1) {
            array[k] = removeClosingBrackets(array[k]);
        }

        function removeClosingBrackets(origString) {
            var newString = '';
            for (var j = 0; j < origString.length; j++) {
                if (origString[j] !== ')') {
                    newString += origString[j];
                }
            }

            return newString;
        }
    }


}

var testArr = [];
testArr[0] = '(def func 10)';
testArr[1] = '(def newFunc (+  func 2))';
testArr[2] = '(def sumFunc (+ func func newFunc 0 0 0))';
testArr[3] = '(* sumFunc 2)';

var testArr2 = [];
testArr2[0] = '(def     go6o    (+ -5 -2) )';
testArr2[1] = '(def pe6o (   /  -15 go6o))';
testArr2[2] = '(def asD (/ 2 0))';
testArr2[3] = '(           +        4          2      func2)';

Solve(testArr2);