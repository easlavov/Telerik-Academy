var write = jsConsole.writeLine;

// Returns if a number is prime or not
function isPrime(integer) {
    var ceiling = Math.floor(Math.sqrt(integer));
    for (var i = 2; i <= ceiling; i++) {
        if (integer % i === 0) {
            return false;
        }
    }

    return true;
}

write('Task: Write an expression that checks if given positive integer number n (n ≤ 100) is prime.');
write('Look in scripts/07.CheckIfPositiveIntegerIsPrime.js for the code.');
write(' ');
write('Testing function.');

write('The number 57 is prime: ' + isPrime(57));
write('The number 67 is prime: ' + isPrime(67));
write('The number 1 is prime: ' + isPrime(1));
write('The number 100 is prime: ' + isPrime(100));

write(' ');
write('Test complete.');