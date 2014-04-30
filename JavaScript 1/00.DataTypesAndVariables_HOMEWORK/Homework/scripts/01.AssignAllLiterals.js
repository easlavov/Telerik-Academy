function printExample(literal, variable) {
    var output = literal + ": " + variable;
    jsConsole.writeLine(output);
    jsConsole.writeLine('');
}

// Assigning int literal
var int = -5;

// Assigning float literal
var float = 3.14;

// Assigning string literal
var string = 'This is a string'; // single quotes
var stringDoubleQuotes = "This is another string"; // double quotes

// Assigning boolean literal
var boolTrue = true;
var boolFalse = false;

// Assigning null
var nullVar = null;

// Assigning undefined
var undef = undefined;

// Print message
jsConsole.writeLine('Task: Assign all the possible JavaScript literals to different variables.');
jsConsole.writeLine('Look in scripts/01.AssignAllLiterals.js for the code.')
jsConsole.writeLine(' ')

// Printing variables
printExample('Integer literal variable', int);
printExample('Float literal variable', float);
printExample('Single quotes string literal variable', string);
printExample('Double quotes string literal variable', stringDoubleQuotes);
printExample('True boolean literal variable', boolTrue);
printExample('False boolean literal variable', boolFalse);
printExample('null literal variable', nullVar);
printExample('Undefined literal variable', undef);

// Print message
jsConsole.writeLine('This ends the task.')
jsConsole.writeLine(' ')