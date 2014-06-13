/// <reference path="_references.js" />

$('<button>').text('Test').on('click', testFunctionality).appendTo('body');

function insertBefore(sibling, insertedElement) {
    $(sibling).prepend($(insertedElement));
}

function insertAfter(sibling, insertedElement) {
    $(sibling).append($(insertedElement));
}

function testFunctionality() {
    var $mainDiv = $('<div>').text('First DIV').prependTo('body');

    var $newElement = $('<div>').text('Inserted with insertBefore().');
    insertBefore($mainDiv, $newElement);

    $newElement = $('<div>').text('Inserted with insertAfter().');
    insertAfter($mainDiv, $newElement);
}