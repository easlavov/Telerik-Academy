taskName = "11. Placeholders. ";

function stringFormat(format) {
    var current;
    for (var i = 1, placeholder = 0; i < arguments.length; i++, placeholder++) {
        current = '\{' + placeholder + '\}';
        format = format.replace(current, arguments[i].toString(), 'g');
    }
    return format;
}

// Test scripts
function Main(bufferElement) {

    var input = ReadLine(
        'Enter new format or use default: ',
        "{0} {4} {0} {1} {2} {0} {1} {3} {2}");
    WriteLine('The hard coded arguments are: "Petar", "Ivan", 5, "Mara", -14');
    WriteLine('Press Solve to use the selected format with the hardcoded arguments')
    SetSolveButton(function () {

        var format = input.value;
        WriteLine('The new string is:')
        WriteLine(stringFormat(format, "Petar", "Ivan", 5, "Mara", -14));

    });
}