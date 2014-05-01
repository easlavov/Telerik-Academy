taskName = "10. Extract palindromes. ";

function extractPalindromes(text) {
    var palindromes = Array();

    // extract all words
    var words = extractWords(text);

    // go through all words and check if they're palindromes
    for (var i = 0; i < words.length; i++) {
        // skip words with less than 3 letters
        if (words[i].length < 3) {
            continue;
        }

        // check if palindrome
        if (isPalindrome(words[i])) {
            palindromes.push(words[i]);
        }
    }

    return palindromes;
}

function extractWords(text) {
    return text.match(/\b\w*\b/g);
}

function isPalindrome(word) {
    word = word.toLowerCase();
    var reversedWord = word.split('').reverse().join('');
    if (reversedWord == word) {
        return true;
    }
    return false;
}

// Test scripts
function Main(bufferElement) {

    var input = ReadLine(
        'Enter new text or use default: ',
        "Yesterday I listened to ABBA. Lamal is a fictional animal. The exe file is corrupted.");

    SetSolveButton(function () {

        var toExtract = input.value;
        WriteLine('The extracted palindromes are the following:')
        WriteLine(extractPalindromes(toExtract));

    });
}