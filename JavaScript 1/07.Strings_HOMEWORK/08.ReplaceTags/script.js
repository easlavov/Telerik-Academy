taskName = "8. Extract text. ";

function repl(text) {
    var tags = /<a href="/ig;
    var result = text.replace(tags, '[URL=');
    tags = /<\/a>/ig;
    result = result.replace(tags, '[/URL]');
    tags = /">/ig;
    result = result.replace(tags, ']');
    return result;
}

// Test scripts
function Main(bufferElement) {

    var input = ReadLine(
        'Enter new text or use default: ',
        '<p>Please visit <a href="http://academy.telerik. com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>');

    SetSolveButton(function () {

        var toExtract = input.value;
        WriteLine(repl(toExtract));

    });
}