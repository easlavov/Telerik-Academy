var ctx = document.getElementById('the-canvas').getContext('2d');

var ballX = ctx.canvas.width / 2;
var ballY = ctx.canvas.height / 2;
var ballRadius = 50;
var currentDirection = 'bottom-right'; 

setInterval(moveBall, 3);

function moveBall() {
    ctx.clearRect(ballX - ballRadius, ballY - ballRadius, ballRadius * 2, ballRadius * 2);
    changeCoords();
    ctx.beginPath();
    ctx.arc(ballX, ballY, ballRadius, 0, Math.PI * 180, false);
    ctx.fill();
    ctx.closePath();
}

function changeCoords() {
    if (currentDirection === 'bottom-right') {
        ballX++;
        ballY++;
        if (ballOnEdge()) {
            currentDirection = 'top-right';
        }

        return;
    }

    if (currentDirection === 'top-right') {
        ballX++;
        ballY--;
        if (ballOnEdge()) {
            currentDirection = 'top-left';
        }

        return;
    }

    if (currentDirection === 'top-left') {
        ballX--;
        ballY--;
        if (ballOnEdge()) {
            currentDirection = 'bottom-left';
        }

        return;
    }

    if (currentDirection === 'bottom-left') {
        ballX--;
        ballY++;
        if (ballOnEdge()) {
            currentDirection = 'bottom-right';
        }

        return;
    }
}

function ballOnEdge() {
    var onLeftEdge = (ballX - ballRadius) <= 0;
    var onTopEdge = (ballY - ballRadius) <= 0;
    var onRightEdge = (ballX + ballRadius) >= ctx.canvas.width;
    var onBottomEdge = (ballY + ballRadius) >= ctx.canvas.height;

    if (onLeftEdge || onTopEdge || onRightEdge || onBottomEdge) {
        return true;
    } else {
        return false;
    }
}