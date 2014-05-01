taskName = "1. Reverse string";

function reverseString(str) {
    var rev = new String();
    for (var i = str.length - 1; i >= 0; i--) {
        rev += str[i];
    }
    return rev;
}

// Test scripts
function Main(bufferElement) {
    
    var input = ReadLine('Enter string to reverse: ', 'sample');

    SetSolveButton(function () {
        
        var toRev = input.value;
        WriteLine('The reversed string is: ' + reverseString(toRev));
        
    });
}