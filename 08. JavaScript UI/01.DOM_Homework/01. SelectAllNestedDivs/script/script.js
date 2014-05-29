/* Write a script that selects all the div nodes that are
 directly inside other div elements
 - Create a function using querySelectorAll()
 - Create a function using getElementsByTagName() */

// Divs that are directly inside other divs have been manually given
// class "directly-inside-div" for testing purposes.
var realDirectlyNestedDivsCount = document.getElementsByClassName('directly-inside-div').length;
var welcomeMessage = 'The real count of directly nested divs in this html document is ' +
                realDirectlyNestedDivsCount;
console.log(welcomeMessage);

// Query solution
var directlyNestedDivsCountQuery = getDirectlyNestedDivsByQuery();
var queryMessage = 'The count of directly nested divs in this html document ' +
                   'extracted by using query selector is ' +
                   directlyNestedDivsCountQuery;
console.log(queryMessage);

// Tag name solution
var directlyNestedDivsCountTagName = getDirectlyNestedDivsByTagName();
var tagNameMessage = 'The count of directly nested divs in this html document ' +
                     'extracted by using tag name is ' +
                     directlyNestedDivsCountTagName;
console.log(tagNameMessage);