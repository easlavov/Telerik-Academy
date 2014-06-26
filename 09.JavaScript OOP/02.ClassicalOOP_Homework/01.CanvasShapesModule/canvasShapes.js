var specialConsole = (function(){
    var console;
    var spanTemplate = document.createElement('span');

    function createConsoleIn(parentSelector){
        var parent = document.querySelector(parentSelector);
        var div = document.createElement('div');
        div.style.width = '1000px';
        div.style.height = '600px';
        div.style.fontFamily = 'consolas';
        div.style.fontSize = '14px';
        div.style.color = 'white';
        div.style.backgroundColor = 'black';
        div.style.overflowY = 'scroll';  // overflow-y: scroll
        div.style.wordWrap = 'break-word';

        console = div;

        parent.appendChild(console);
    }

    function getPlaceholders(args){
        var pHarr = new Array();
        for (var i = 1; i < args.length; i++) {
            pHarr.push(args[i]);
        }

        return pHarr;
    }

    function formatString(str, args){
        var current;
        for (var i = 0, placeholder = 0; i < args.length; i++, placeholder++) {
            current = '\{' + placeholder + '\}';
            str = str.replace(current, args[i].toString(), 'g');
        }

        return str;
    }

    function writeLine(str) {
        var line = spanTemplate.cloneNode(true);
        if (arguments.length > 1){
            var argsArray = getPlaceholders(arguments);
            str = formatString(str, argsArray);
        }

        line.textContent = str.toString();
        console.appendChild(line);
        console.appendChild(document.createElement('br'));
    }

    return {
        createConsoleIn : createConsoleIn,
        writeLine : writeLine,
        writeError: writeLine,
        writeWarning : writeLine
    }
})();