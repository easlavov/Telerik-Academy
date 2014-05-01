taskName = "5. Replace whitespaces. ";

function replaceWhitespaces(text) {
    var res = text.replace(/ /g, '&nbsp');
    return res;
}

// Test scripts
function Main(bufferElement) {

    var input = ReadLine(
        'Enter new text or use default: ',
        "We are living in a yellow submarine. We don't have anything else.");

    SetSolveButton(function () {

        var toEdit = input.value;
        WriteLine('The text had its whitespaces replaced:');
        WriteLine(replaceWhitespaces(toEdit));

    });
}