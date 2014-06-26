var movingDivs = (function () {
    var DEFAULT_CONTAINER = document.body;
    var DEFAULT_DIV_WIDTH = 100;
    var DEFAULT_DIV_HEIGHT = 100;
    var DEFAULT_DIV_BORDER_WIDTH = 5;
    var DEFAULT_DIV_BORDER_STYLE = 'solid';
    var DEFAULT_DIV_INNER_TEXT = 'text';
    var MIN_LEFT_OFFSET = 100;
    var MAX_LEFT_OFFSET = 800;
    var MIN_TOP_OFFSET = 100;
    var MAX_TOP_OFFSET = 400;

    var CIRCULAR_MOTION_RADIUS = 50;
    var STARTING_ANGLE = 130;
    var ANGLE_CHANGE_STEP = 0.1;

    var RECT_MOTION_PATH_LENGTH = 600;
    var RECT_MOTION_CORNER_VALUES = getCornerValues(RECT_MOTION_PATH_LENGTH);
    var RECT_MOTION_STEP = 10;

    var ANIMATION_INTERVAL = 100;

    var container = DEFAULT_CONTAINER;
    var divTemplate = getDefaultDivTemplate();
    var circularlyMovingElements = [];
    var rectangularlyMovingElements = [];

    function getCornerValues(pathLength) {
        var corners = [];
        var step = (pathLength / 4) | 0;
        corners.push(step);
        corners.push(step * 2);
        corners.push(step * 3);
        corners.push(step * 4);
        return corners;
    }

    function getDefaultDivTemplate() {
        var template = document.createElement('div');
        template.style.width = DEFAULT_DIV_WIDTH + 'px';
        template.style.height = DEFAULT_DIV_HEIGHT + 'px';
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
                prepForRectMovement(newDiv); break;
            case 'ellipse' :
                prepForCircularMovement(newDiv); break;
        }

        container.appendChild(newDiv);

        function randomizeDiv(div) {
            div.style.borderColor = getRandomColor();
            div.style.backgroundColor = getRandomColor();
            div.style.color = getRandomColor();
            div.style.left = getRandomInt(MIN_LEFT_OFFSET, MAX_LEFT_OFFSET) + 'px';
            div.style.top = getRandomInt(MIN_TOP_OFFSET, MAX_TOP_OFFSET) + 'px';

            function getRandomColor() {
                var red = getRandomInt(0,255);
                var green = getRandomInt(0,255);
                var blue = getRandomInt(0,255);

                return 'rgb(' + red + ',' + green + ',' + blue + ')';
            }
        }

        function prepForCircularMovement(div) {
            // div must have a point to circle around
            div.dataset.angle = STARTING_ANGLE;
            div.dataset.orbitCenterX = parseInt(div.style.left) + CIRCULAR_MOTION_RADIUS;
            div.dataset.orbitCenterY = parseInt(div.style.top) + CIRCULAR_MOTION_RADIUS;
            circularlyMovingElements.push(div);
        }

        function prepForRectMovement(div) {
            div.dataset.path = 0;
            rectangularlyMovingElements.push(div);
        }

        function getRandomInt(min, max) {
            return Math.floor(Math.random() * (max - min + 1) + min);
        }
    }

    function moveDivs() {
        for (var i = 0; i < circularlyMovingElements.length; i++) {
            moveCircularly(circularlyMovingElements[i]);
        }

        for (var i = 0; i < rectangularlyMovingElements.length; i++) {
            moveRectangularly(rectangularlyMovingElements[i]);
        }

        function moveCircularly(div) {
            var angle = parseFloat(div.dataset.angle);
            var centerY = parseFloat(div.dataset.orbitCenterY);
            var centerX = parseFloat(div.dataset.orbitCenterX);
            angle += ANGLE_CHANGE_STEP;
            div.dataset.angle = angle;
            div.style.top = (centerY + Math.sin(angle) * CIRCULAR_MOTION_RADIUS) + 'px';
            div.style.left = (centerX + Math.cos(angle) * CIRCULAR_MOTION_RADIUS) + 'px';
        }

        function moveRectangularly(div) {
            var currentTop = parseInt(div.style.top);
            var currentLeft = parseInt(div.style.left);
            var currentPath = parseInt(div.dataset.path);
            if (currentPath < RECT_MOTION_CORNER_VALUES[0]) {
                div.style.top = currentTop + RECT_MOTION_STEP + 'px';
            } else if (currentPath < RECT_MOTION_CORNER_VALUES[1]) {
                div.style.left = currentLeft + RECT_MOTION_STEP + 'px';
            } else if (currentPath < RECT_MOTION_CORNER_VALUES[2]) {
                div.style.top = currentTop - RECT_MOTION_STEP + 'px';
            } else if (currentPath <= RECT_MOTION_CORNER_VALUES[3]) {
                div.style.left = currentLeft - RECT_MOTION_STEP + 'px';
            }

            currentPath = (currentPath + RECT_MOTION_STEP) % RECT_MOTION_PATH_LENGTH;
            div.dataset.path = currentPath;
        }
    }

    function startMovement() {
        setInterval(moveDivs, ANIMATION_INTERVAL);
    }

    return {
        setContainer : setContainer,
        add : add,
        startMovement : startMovement
    }
})();