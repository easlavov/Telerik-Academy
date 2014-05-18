function Solve(params) {
    var parsedArray = params.map(Number);
    var n = parsedArray[0];
    var maxSum = parsedArray[1];
    var currentSum;
    var i, j;
    for (i = 1; i <= n; i += 1) {
        currentSum = 0;
        for (j = i; j <= n; j += 1) {
            currentSum += parsedArray[j];
            if (currentSum > maxSum) {
                maxSum = currentSum;
            }
        }
    }

    return maxSum;
}

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

var res = Solve(testArr2);