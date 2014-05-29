function getDirectlyNestedDivsByQuery() {
    var divsCount = document.querySelectorAll('div > div').length;
    return divsCount;
}

function getDirectlyNestedDivsByTagName() {
    var divsCount = 0;
    var allDivs = document.getElementsByTagName('div');
    var i;
    for (i = 0; i < allDivs.length; i += 1) {
        var currentDiv = allDivs[i];
        var parent = currentDiv.parentElement;
        if (parent.tagName === 'DIV') {
            divsCount += 1;
        }
    }

    return divsCount;
}