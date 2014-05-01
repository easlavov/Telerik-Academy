var write = jsConsole.writeLine;

function numberInEnglish(number) {
    if (number < 100) {
        return twoDigitNumber(number);
    } else {
        var word = "";
        number += "";
        var firstDigit = number[0];
        var secondDigit = number[1];
        var thirdDigit = number[2];
        word += digitInEnglish(parseInt(firstDigit)) + ' hundred';
        var twoDigits = parseInt(secondDigit + thirdDigit);
        if (twoDigits > 0) {
            if (twoDigits < 10) {
                word += ' and ' + digitInEnglish(twoDigits);
            } else {
                word += ' ' + twoDigitNumber(twoDigits);
            }
        }

        return word;
    }
}

function twoDigitNumber(number) {
    if (number < 20) {
        return digitInEnglish(number, true);
    } else {
        var word = "";
        number += "";
        var leadingDigit = parseInt(number[0]);
        var youngerDigit = parseInt(number[1]);
        switch (leadingDigit) {
            case 2: word += 'twenty'; break;
            case 3: word += 'thirty'; break;
            case 4: word += 'fourty'; break;
            case 5: word += 'fifty'; break;
            case 6: word += 'sixty'; break;
            case 7: word += 'seventy'; break;
            case 8: word += 'eighty'; break;
            case 9: word += 'ninety'; break;
        }

        word += ' ' + digitInEnglish(youngerDigit, false);

        return word;
    }
}

function digitInEnglish(digit, isSingle) {
    switch (digit) {
        case 0: if (isSingle) {
            return "zero";
        } else {
            return '';
        }
        case 1: return "one";
        case 2: return "two";
        case 3: return "three";
        case 4: return "four";
        case 5: return "five";
        case 6: return "six";
        case 7: return "seven";
        case 8: return "eight";
        case 9: return "nine";
        case 10: return "ten";
        case 11: return "eleven";
        case 12: return "twelve";
        case 13: return "thirteen";
        case 14: return "fourteen";
        case 15: return "fifteen";
        case 16: return "sixteen";
        case 17: return "seventeen";
        case 18: return "eighteen";
        case 19: return "nineteen";
    }
}

write('Task: Write a script that converts a number in the range [0...999] to a text corresponding to its English pronunciation.');
write('Look in scripts/08.NumberInEnglish.js for the code.');
write(' ');
write('Testing function.');

write('157: ' + numberInEnglish(157));
write('999: ' + numberInEnglish(999));
write('57: ' + numberInEnglish(57));
write('3: ' + numberInEnglish(3));
write('0: ' + numberInEnglish(0));
write('20: ' + numberInEnglish(20));
write('63: ' + numberInEnglish(63));
write('22: ' + numberInEnglish(22));
write('10: ' + numberInEnglish(10));
write('13: ' + numberInEnglish(13));
write('551: ' + numberInEnglish(551));

write('');
write('Test complete.');