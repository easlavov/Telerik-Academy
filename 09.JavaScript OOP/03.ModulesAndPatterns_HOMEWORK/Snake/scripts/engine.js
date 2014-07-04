var engine = (function() {
    var snakeHeadColor = 'darkred';
    var snakeBodyColor = 'green';
    var currentDirection = 'right';
    var apple;
    var fieldWidth = canvasDrawer.getFieldWidth();
    var fieldHeight = canvasDrawer.getFieldHeight();
    var currentScore = 0;
    var gameInProgress;

    var speed = 125;

    function generateApple(size) {
        var appleX = getRandomInt(0, fieldWidth);
        var appleY = getRandomInt(0, fieldHeight);
        if (appleX >= fieldWidth) {
            appleX = fieldWidth - size;
        }

        if (appleY >= fieldHeight) {
            appleY = fieldHeight - size;
        }

        if (apple === undefined) {
            apple = new gameObjects.Food(appleX, appleY, size);
        } else {
            apple.x = appleX;
            apple.y = appleY;
        }
    }

    function getRandomInt(min, max) {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }

    function isHeadOnApple(snake, apple) {
        var inHorizontalRange = Math.abs(snake.head.x - apple.x) < apple.size;
        var inVerticalRange = Math.abs(snake.head.y - apple.y) < apple.size;

        if (inHorizontalRange && inVerticalRange) {
            return true;
        } else {
            return false;
        }
    }

    function isHeadOnBody(snake) {
        for (var i = 0; i < snake.body.length; i++) {
            var bodyPart = snake.body[i];
            if (snake.head.x === bodyPart.x &&
                snake.head.y === bodyPart.y) {
                return true;
            }
        }

        return false;
    }

    function isHeadOutsideField(snake) {
        var overTop = snake.head.y < 0;
        var overRight = snake.head.x > fieldWidth;
        var overBottom = snake.head.y > fieldHeight;
        var overLeft = snake.head.x < 0;

        if (overTop || overRight || overBottom || overLeft) {
            return true;
        }
    }

    function move(snake, shouldGrow) {
        snake.move(currentDirection, shouldGrow);
    }

    function drawSnake(snake) {
        canvasDrawer.drawObject(snake.head, snakeHeadColor);
        for (var i = 0; i < snake.body.length; i++) {
            canvasDrawer.drawObject(snake.body[i], snakeBodyColor);
        }
    }

    function getApple() {
        return apple;
    }

    function startGame(argument) {
        gameInProgress = setInterval(function() {
            canvasDrawer.clearContext();
            engine.drawSnake(theSnake);
            canvasDrawer.drawObject(apple, 'red');

            if (isHeadOnBody(theSnake) || isHeadOutsideField(theSnake)) {
                alert('GameOver');
                stopGame();
                highScores.addScore(currentScore);
                currentScore = 0;
            }

            if (isHeadOnApple(theSnake, engine.getApple())) {
                move(theSnake, true);
                engine.generateApple(objectsSize);
                currentScore++;
            } else {
                move(theSnake);
            }
        }, speed);
    }

    function stopGame() {
        clearInterval(gameInProgress);
    }

    document.addEventListener('keydown', function(event) {
        var key = event.keyCode;
        if (key === 37 && currentDirection !== 'right') {
            currentDirection = 'left';
        } else if (key === 38 && currentDirection !== 'down') {
            currentDirection = 'up';
        } else if (key === 39 && currentDirection !== 'left') {
            currentDirection = 'right';
        } else if (key === 40 && currentDirection !== 'up') {
            currentDirection = 'down';
        }
    });

    return {
        generateApple: generateApple,
        drawSnake: drawSnake,
        getApple: getApple,
        startGame: startGame
    }
}());