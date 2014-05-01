taskName = "6. Extract text. ";

function extractText(text) {
    var tags = /(<([^>]+)>)/ig;
    var result = text.replace(tags, '');
    return result;
}

// Test scripts
function Main(bufferElement) {

    var input = ReadLine(
        'Enter new text or use default: ',
        "<html><head><title>Sample site</title></head><body><div>text<div>more text</div>and more...</div>in body</body></html>");

    SetSolveButton(function () {

        var toExtract = input.value;
        WriteLine(extractText(toExtract));

    });
}