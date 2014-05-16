function Solve(params) {
    var functions = {};
    var inputLine;
    var output;
    
    for (inputLine = 0; inputLine < params.length; inputLine += 1) {
        if (inputLine === params.length - 1) {
            output = readLine(params[inputLine]);
            return output;
        } else {
            readLine(params[inputLine]);
        }
    }

    function readLine(line) {
        var commandParams = removeEmptyEntries(line.split(' '), '');
        var primaryCommand = commandParams[0];
        switch (primaryCommand) {
            case 'def': define(commandParams);
            case 'sum':
            case 'average':
            case 'min':
            case 'max': return nonDefine(primaryCommand, commandParams);
        }
    }

    function define(defParameters) {
        var funcId = defParameters[1];
        var funcValue = getFuncValue(defParameters.slice(2));

        functions[funcId] = funcValue;
    }

    function nonDefine(command, params) {
        var value = getFuncValueOperationsOnly(params);
        switch (command) {
            case 'sum': return getSum(preparedValues);
            case 'average': return getAverage(preparedValues);
            case 'min': return getMin(preparedValues);
            case 'max': return getMax(preparedValues);
        }
    }

    function getFuncValue(array) {
        var operation = array[0];
        var valuesOnlyArray = getValuesOnly(array.slice(1));
        var preparedValues = convertToNumArray(valuesOnlyArray);
        switch (operation) {
            case 'sum': return getSum(preparedValues);
            case 'average': return getAverage(preparedValues);
            case 'min': return getMin(preparedValues);
            case 'max': return getMax(preparedValues);
        }
    }

    function getFuncValueOperationsOnly(array) {
        var valuesOnlyArray = getValuesOnly(array.slice(1));
        var preparedValues = convertToNumArray(valuesOnlyArray);

        return preparedValues;
    }

    function getValuesOnly(array) {
        // much quality!!!! :
        var valArray = [];
        var valWithoutRedundChars1 = removeEmptyEntries(array, '[');
        var valWithoutRedundChars2 = removeEmptyEntries(valWithoutRedundChars1, ']');
        var valWithoutRedundChars3 = removeEmptyEntries(valWithoutRedundChars2, ',');

        for (var i = 0; i < valWithoutRedundChars3.length; i++) {
            var splittedEntry = valWithoutRedundChars3[i].split(',');
            for (var j = 0; j < splittedEntry.length; j++) {
                valArray.push(splittedEntry[j]);
            }
        }
        var valArray2 = removeEmptyEntries(valArray, '');

        return valArray2;
    }

    function removeEmptyEntries(array, char) {
        var newArr = [];
        for (var i = 0; i < array.length; i++) {
            if (array[i] !== char) {
                newArr.push(array[i]);
            }
        }

        return newArr;
    }

    function removeChar(str, char) {
        var newString = '';
        for (var i = 0; i < str.length; i++) {
            if (str[i] !== char) {
                newString += str[i];
            }
        }

        return newString;
    }

    // Returns a new array
    function convertToNumArray(strArray) {
        var numArr = [];
        var i;
        for (i = 0; i < strArray.length; i += 1) {
            // first checking if the element is a function
            if (functions[strArray[i]] !== undefined) {
                // function value should always be a number
                var funcValue = functions[strArray[i]];
                numArr.push(funcValue);
                continue;
            } else {
                var strAsNum = parseInt(strArray[i]);
                numArr.push(strAsNum);
            }
        }

        return numArr;
    }

    function getMin(array) {
        // accepts only a valid numbers array!
        var minimal = array[0];
        var i;
        for (i = 1; i < array.length; i++) {
            if (array[i] < minimal) {
                minimal = array[i];
            }
        }

        return minimal;
    }

    function getMax(array) {
        // accepts only a valid numbers array!
        var maximal = array[0];
        var i;
        for (i = 1; i < array.length; i++) {
            if (array[i] > maximal) {
                maximal = array[i];
            }
        }

        return maximal;
    }

    function getAverage(array) {
        // accepts only a valid numbers array!
        var sum = array[0];
        var average;
        var i;
        for (i = 1; i < array.length; i++) {
            sum += array[i];
        }

        average = (sum / array.length) | 0;
        return average;
    }

    function getSum(array) {
        // accepts only a valid numbers array!
        var sum = array[0];
        var i;
        for (i = 1; i < array.length; i++) {
            sum += array[i];
        }

        return sum;
    }
}

//def var1[1, 2, 3 ,4]
//def var2 sum[var1, 20, 70] //var2=100
//def var3 min[var1] // var3=1
//avg[var2, var3] //the result is 50

var testArr = [];
testArr[0] = 'def var1[1, 2, 3 ,4]';
testArr[1] = 'def var2 sum[var1, 20, 70]';
testArr[2] = 'def var3 min[var1]';
testArr[3] = 'avg[var2, var3]';

var testArr2 = [];
testArr2[0] = '10';
testArr2[1] = '1255569';
testArr2[2] = '-851435';
testArr2[3] = '1457629';
testArr2[4] = '858237';
testArr2[5] = '221970';
testArr2[6] = '-652780';
testArr2[7] = '1379095';
testArr2[8] = '-732864';
testArr2[9] = '-606100';
testArr2[10] = '1566514';

Solve(testArr);