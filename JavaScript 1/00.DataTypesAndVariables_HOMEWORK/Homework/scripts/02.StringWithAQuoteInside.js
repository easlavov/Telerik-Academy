function printExample(literal, variable) {
    var output = literal + ": " + variable;
    jsConsole.writeLine(output);
    jsConsole.writeLine('');
}

// Print message
jsConsole.writeLine('Task: Create a string variable with quoted text in it.');
jsConsole.writeLine('Look in scripts/02.StringWithAQuoteInside.js for the code.')
jsConsole.writeLine(' ')

// Initializing variables
var quoteInsideStringTypeOne = '"Telerik" is a Bulgarian software development company';
var quoteInsideStringTypeTwo = "'Telerik' is a Bulgarian software development company";

// Printing the two variables
printExample('A string literal with single quotes literal', quoteInsideStringTypeOne);
printExample('A string literal with double quotes literal', quoteInsideStringTypeTwo);