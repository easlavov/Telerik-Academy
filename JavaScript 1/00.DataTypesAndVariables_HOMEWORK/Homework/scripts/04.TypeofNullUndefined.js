function printExample(literal, variable) {
    var output = literal + ": " + variable;
    jsConsole.writeLine(output);
    jsConsole.writeLine('');
}

// Print message
jsConsole.writeLine('Task: Create null, undefined variables and try typeof on them.')
jsConsole.writeLine('Look in scripts/04.TypeofNullUndefined for the code.')
jsConsole.writeLine(' ')

// Assigning null
var nullVar = null;

// Assigning undefined
var undef = undefined;

printExample('Typeof null variable', typeof nullVar);
printExample('Typeof undefined variable', typeof undef);