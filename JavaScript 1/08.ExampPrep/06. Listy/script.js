function Solve(params) {
    var functions = {};



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

//function Solve(params) {
//    var n = parseInt(params[0]);
//    var i, j;
//    var maxSum = parseInt(params[1]);
//    var currentSum = maxSum;
//    for (i = 1; i < n; i += 1) {
//        if (parseInt(params[i]) > maxSum) {
//            maxSum = parseInt(params[i]);
//        }

//        currentSum = parseInt(params[i]);

//        for (j = i + 1; j < n; j += 1) {
//            currentSum += parseInt(params[j]);
//            if (currentSum > maxSum) {
//                maxSum = currentSum;
//            }
//        }
//    }

//    return maxSum;
//}

//function Solve(params) {
//    var N = parseInt(params[0]);
//    var numbers = [];
//    for (var i = 1; i <= N; i++) {
//        numbers[i] = parseInt(params[i]);
//    }

//    var maxSum = -2000000000;
//    for (var i = 1; i <= N; i++) {
//        for (var j = i; j <= N; j++) {
//            var localSum = 0;
//            for (var k = i; k <= j; k++) {
//                localSum += numbers[k];
//            }
//            if (localSum > maxSum) {
//                maxSum = localSum;
//            }
//        }
//    }

//    // There is a smarter solution using prefix sums
//    // Prefix sums will remove the need of the most inner loop
//    // More information on prefix sums: http://en.wikipedia.org/wiki/Prefix_sum

//    return maxSum;
//}

var testArr = [];
testArr[0] = '8';
testArr[1] = '1';
testArr[2] = '6';
testArr[3] = '-9';
testArr[4] = '4';
testArr[5] = '4';
testArr[6] = '-2';
testArr[7] = '10';
testArr[8] = '-1';

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

Solve(testArr2);