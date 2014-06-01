/// <reference path="_references.js" />

var snakeHeadColor = 'darkred';
var snakeBodyColor = 'green';
var currentDirection = 'right';
var apple;

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
        apple = new Food(appleX, appleY, size);
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
    drawObject(snake.head, snakeHeadColor);
    for (var i = 0; i < snake.body.length; i++) {
        drawObject(snake.body[i], snakeBodyColor);
    }
}

function drawObject(obj, color) {
    ctx.beginPath();
    ctx.fillStyle = color;
    ctx.fillRect(obj.x, obj.y, obj.size, obj.size);
    ctx.closePath();
}