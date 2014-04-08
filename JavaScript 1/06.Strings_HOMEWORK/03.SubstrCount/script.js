taskName = "3. Find how many times a substring is contained in a given text ";

function countSubstr(str, sub) {
    var text = str.toLowerCase();
    sub = sub.toLowerCase();
    var counter = 0;
    var index = text.indexOf(sub,  0);
    while (index > -1) {
        counter++;
        index = text.indexOf(sub,  index + 1);
    }
    return counter;
}

// Test scripts
function Main(bufferElement) {

    var input = ReadLine(
        'Enter new text or use default: ',
        "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.");
    var sub = ReadLine('Enter string to look for or use default: ', 'in');

    SetSolveButton(function () {

        var toCheck = input.value;
        var toLook = sub.value;
        WriteLine('The substring appears ' + countSubstr(toCheck, toLook) + ' times');



    });
}