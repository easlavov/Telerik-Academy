/// <reference path="_references.js" />

var ctx = document.getElementById('the-canvas').getContext('2d');
var fieldWidth = ctx.canvas.width;
var fieldHeight = ctx.canvas.height;

var objectsSize = 20;
var snakeHeadX = fieldWidth / 2;
var snakeHeadY = fieldHeight / 2;
var snakeHead = new SnakeHead(snakeHeadX, snakeHeadY, objectsSize);
var snakeLength = 4;
var theSnake = new Snake(snakeHead, snakeLength);
generateApple(objectsSize);
var currentScore = 0;

var currentGame = setInterval(function () {
    ctx.clearRect(0, 0, fieldWidth, fieldHeight);
    drawSnake(theSnake);
    drawObject(apple, 'red');

    if (isHeadOnBody(theSnake) || isHeadOutsideField(theSnake)) {
        alert('GameOver');
        clearInterval(currentGame);
        addScore();
        currentScore = 0;
    }
    
    if (isHeadOnApple(theSnake, apple)) {
        move(theSnake, true);
        generateApple(objectsSize);
        currentScore++;
    } else {
        move(theSnake);
    }
}, 150);

document.addEventListener('keydown', function (event) {
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

document.addEventListener('keydown', function (event) {
    var key = event.keyCode;
    if (key === 90 ) {
        TESTGROW(theSnake);
    } 
});

var highScoresButton = document.getElementsByTagName('button')[0];
highScoresButton.addEventListener('click', displayHighScores, false);

function addScore() {
    var name = prompt('Enter your name: ');
    localStorage.setItem(name, currentScore);
}

function displayHighScores() {
    var message = '';
    var scores = [];
    for (var sc in localStorage) {
        if (localStorage.hasOwnProperty(sc)) {
            var playerName = sc;
            var playerScore = localStorage.getItem(sc);
            var score = {
                name: playerName,
                score: playerScore
            };
            scores.push(score);
        }
    }

    scores.sort(compareScores);

    for (var i = 0; i < scores.length; i++) {
        var name = scores[i].name;
        var score = scores[i].score;
        message += name + ': ' + score + '\n';
    }

    alert(message);

    function compareScores(a, b) {
        a = parseInt(a.score);
        b = parseInt(b.score);
        if (a < b) {
            return 1;
        }

        if (a > b) {
            return -1;
        }

        return 0;
    }
}