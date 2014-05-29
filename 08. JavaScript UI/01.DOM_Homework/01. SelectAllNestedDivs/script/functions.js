function getDirectlyNestedDivsByQuery() {
    var divs = document.querySelectorAll('div > div');
    return divs;
}

function getDirectlyNestedDivsByTagName() {
    var allDivs = document.getElementsByTagName('div');
    var directlyNestedDivs = [];
    var i;
    for (i = 0; i < allDivs.length; i += 1) {
        var currentDiv = allDivs[i];
        var parent = currentDiv.parentElement;
        if (parent.tagName === 'DIV') {
            directlyNestedDivs.push(currentDiv);
        }
    }

    return directlyNestedDivs;
}