/* Write a script that selects all the div nodes that are
 directly inside other div elements
 - Create a function using querySelectorAll()
 - Create a function using getElementsByTagName() */

// Divs that are directly inside other divs have been manually given
// class "directly-inside-div" for testing purposes.
var directlyNestedDivsCount = document.getElementsByClassName('directly-inside-div').length;
var welcomeMessage = 'The real count of directly nested divs in this html document is ' +
                directlyNestedDivsCount;
console.log(welcomeMessage);

// Query solution
var directlyNestedDivsQuery = getDirectlyNestedDivsByQuery();
var queryMessage = 'The directly nested divs in this html document ' +
                   'extracted by using query selector are :';
console.dir(directlyNestedDivsQuery);

// Tag name solution
var directlyNestedDivsTagName = getDirectlyNestedDivsByTagName();
var tagNameMessage = 'The directly nested divs in this html document ' +
                   'extracted by using tag name are :';
console.dir(directlyNestedDivsTagName);