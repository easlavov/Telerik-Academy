var movingDivs = (function () {
    var DEFAULT_CONTAINER = document.body;
    var DEFAULT_DIV_WIDTH = 100;
    var DEFAULT_DIV_HEIGHT = 100;
    var DEFAULT_DIV_BORDER_WIDTH = 1;
    var DEFAULT_DIV_BORDER_STYLE = 'solid';
    var DEFAULT_DIV_INNER_TEXT = 'text';
    var container = DEFAULT_CONTAINER;
    var divTemplate = getDefaultDivTemplate();
    var circularMovingElements = [];
    var rectangularMovingElements = [];

    function getDefaultDivTemplate() {
        var template = document.createElement('div');
        template.style.width = DEFAULT_DIV_WIDTH;
        template.style.height = DEFAULT_DIV_HEIGHT;
        template.style.borderWidth = DEFAULT_DIV_BORDER_WIDTH + 'px';
        template.style.borderStyle = DEFAULT_DIV_BORDER_STYLE;
        template.innerText = DEFAULT_DIV_INNER_TEXT;
        template.style.position = 'absolute';
        return template;
    }

    function setContainer(selector) {
        container = document.querySelector(selector);
    }

    function add(movement) {
        var newDiv = divTemplate.cloneNode(true);
        randomizeDiv(newDiv);
        switch (movement) {
            case 'rect' :
                newDiv.dataset.path = 0;
                rectangularMovingElements.push(newDiv); break;
            case 'ellipse' :
                newDiv.dataset.angle = 0;
                circularMovingElements.push(newDiv); break;
        }

        container.appendChild(newDiv);
    }

    function randomizeDiv(div) {
        div.style.borderColor = getRandomColor();
        div.style.backgroundColor = getRandomColor();
        div.style.color = getRandomColor();
    }

    function getRandomColor() {
        var red = getRandomInt(0,255);
        var green = getRandomInt(0,255);
        var blue = getRandomInt(0,255);

        return 'rgb(' + red + ',' + green + ',' + blue + ')';

        function getRandomInt(min, max) {
            return Math.floor(Math.random() * (max - min + 1) + min);
        }
    }

    function moveDivs() {
        for (var i = 0; i < circularMovingElements.length; i++) {
            moveCircularly(circularMovingElements[i]);
        }

        for (var i = 0; i < rectangularMovingElements.length; i++) {
            moveRectangularly(circularMovingElements[i]);
        }

        function moveCircularly(div) {

        }

        function moveRectangularly(div) {

        }
    }

    function startMovement() {
        setInterval(moveDivs, 150);
    }

    return {
        setContainer : setContainer,
        add : add,
        startMovement : startMovement
    }
})();