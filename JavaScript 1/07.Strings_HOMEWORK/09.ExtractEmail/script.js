taskName = "9. Extract email. ";

function extractPalindromes(text) {
    var emailRegex = /([a-zA-Z0-9._-]+@[a-zA-Z0-9._-]+\.[a-zA-Z0-9._-]+)/gi;
    var result = text.match(emailRegex);
    return result;
}

// Test scripts
function Main(bufferElement) {

    var input = ReadLine(
        'Enter new text or use default: ',
        "kuma.lisa@yahoo.com went to visit her friend kumcho_valcho@gmail.com. Later came zayo@abv.bg");

    SetSolveButton(function () {

        var toExtract = input.value;
        WriteLine('The extracted emails are the following:')
        WriteLine(extractPalindromes(toExtract));

    });
}