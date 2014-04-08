var wrapper = document.getElementById('wrapper');
var maxLeft = wrapper.clientWidth;
var maxTop = wrapper.clientHeight;
var ball = document.getElementById('ball');
	ball.style.left = '100px';
	ball.style.top = '50px';
var startButton = document.getElementById('start-button');
var ballWidth = ball.clientWidth;
var ballHeight = ball.clientHeight;

// set custom attributes to the ball that help track and change movement direction
ball.horizontal = 'right';
ball.vertical = 'down';
var step = 2;

function moveBall() {
	setInterval(function() {
		var left = parseInt(ball.style.left);
		var top = parseInt(ball.style.top);
		
		// handle horizontal change
		if (ball.horizontal === 'right') {
			if (left + ballWidth < maxLeft) {
				ball.style.left = left + step + 'px';
			}
			else {
				ball.style.left = left - step + 'px';
				ball.horizontal = 'left';
			}
		}
		else {
			if (left > 0) {
				ball.style.left = left - step + 'px';
			}
			else {
				ball.style.left = left + step + 'px';
				ball.horizontal = 'right';
			}
		}
		
		// handle vertical change
		if (ball.vertical === 'down') {
			if (top + ballHeight < maxTop) {
				ball.style.top = top + step + 'px';
			}
			else {
				ball.style.top = top - step + 'px';
				ball.vertical = 'up';
			}
		}
		else {
			if (top > 0) {
				ball.style.top = top - step + 'px';
			}
			else {
				ball.style.top = top + step + 'px';
				ball.vertical = 'down';
			}
		}
	}, 5);
}

startButton.addEventListener('click', moveBall, false);
