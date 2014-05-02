var write = jsConsole.writeLine;

function countWord(input, word, isCaseSensitive) {
    switch (isCaseSensitive) {
        case true: return countCaseSensitive(input, word);
        default: return countCaseInsensitive(input, word);
    }

    function countCaseInsensitive(input, word) {
        var matches = input.match(/\b\w*\b/g);
        var counter = 0;
        word = word.toLowerCase();
        for (var i = 0; i < matches.length; i++) {
            if (matches[i].toLowerCase() === word) {
                counter++;
            }
        }

        return counter;
    }

    function countCaseSensitive(input, word) {
        var matches = input.match(/\b\w*\b/g);
        var counter = 0;
        for (var i = 0; i < matches.length; i++) {
            if (matches[i] === word) {
                counter++;
            }
        }

        return counter;
    }
}

write('Task: Write a function that finds all the occurrences of word in a text.' +
    ' The search can case sensitive or case insensitive. Use function overloading.');
write('Look in scripts/03.FindIdenticalWords.js for the code.');
write(' ');
write('Testing function.');

var input = '"This is just some text, with even more TEXT and text."';
write('This is the test text: ' + input);

write('Looking for the word "text".');
write('Case insensitive search returns ' + countWord(input, 'text'));
write('Case sensitive search returns ' + countWord(input, 'text', true));

write(' ');
write('Test complete.');