taskName = "12. Create UL using template. ";

function generateList(people, template) {
   
}

// Test scripts
function Main(bufferElement) {

    var input = ReadLine(
        'Enter new format or use default: ',
        "");
    var tmpl = document.getElementById("list-item").innerHtml;
    SetSolveButton(function () {

        var format = input.value;
        WriteLine('The new string is:')
        WriteLine(stringFormat(format, "Petar", "Ivan", 5, "Mara", -14));

    });
}