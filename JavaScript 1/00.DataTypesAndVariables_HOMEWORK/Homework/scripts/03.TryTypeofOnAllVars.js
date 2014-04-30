function printExample(literal, variable) {
    var output = literal + ": " + variable;
    jsConsole.writeLine(output);
    jsConsole.writeLine('');
}

// Print message
jsConsole.writeLine('Task: Try typeof on all variables you created.')
jsConsole.writeLine('Look in scripts/03.TryTypeofOnAllVars for the code.')
jsConsole.writeLine(' ')

// Assigning int literal
var int = -5;

// Assigning float literal
var float = 3.14;

// Assigning string literal
var string = 'This is a string';

// Assigning boolean literal
var boolTrue = true;
var boolFalse = false;

// Assigning null
var nullVar = null;

// Assigning undefined
var undef = undefined;

printExample('Typeof integer variable', typeof int);
printExample('Typeof float variable', typeof float);
printExample('Typeof string variable', typeof string);
printExample('Typeof true boolean variable', typeof boolTrue);
printExample('Typeof false boolean variable', typeof boolFalse);
printExample('Typeof null variable', typeof nullVar);
printExample('Typeof undefined variable', typeof undef);