var write = jsConsole.writeLine;

function countDivs(page) {
    return page.getElementsByTagName("div").length;
}

write('Task: Write a function to count the number of divs on the web page');
write('Look in scripts/04.CountDivs.js for the code.');
write('Testing function. Additional divs have been created in the HTML file for testing purpose');
write(' ');

write("The total divs on the page are " + countDivs(this.document));

write(' ');
write('Test complete.');