var canvas = document.getElementById('house');
var ctx = canvas.getContext('2d');
var x, y;
var fillColor = '#975B5B';
var centerX = canvas.width / 2;
var centerY = canvas.height / 2;

// draw the roof
var x = centerX;
var y = centerY * 0.1;
ctx.beginPath();
ctx.moveTo(x, y);
ctx.lineTo(x - 50, y + 50); // bottom left point of triangle
ctx.moveTo(x, y);
ctx.lineTo(x + 50, y + 50); // bottom right point of triangle
ctx.lineTo(x - 50, y + 50);
ctx.closePath();
ctx.fillStyle = fillColor;
ctx.fill();
ctx.strokeStyle = 'black';
ctx.stroke();

// draw body
ctx.fillRect(x - 50, y + 50, 100, 80);
ctx.strokeRect(x - 50, y + 50, 100, 80);

// draw chimney
ctx.beginPath();
ctx.moveTo(x + 20, y + 40);
ctx.lineTo(x + 20, y + 10);
ctx.closePath();
ctx.stroke();

ctx.beginPath();
ctx.moveTo(x + 30, y + 40);
ctx.lineTo(x + 30, y + 10);
ctx.closePath();
ctx.stroke();

ctx.fillRect(x + 21, y + 11, 8, 20);

ctx.beginPath();
ctx.save();
ctx.scale(2.5, 1);
ctx.arc(70, 19, 2, 0, 2 * Math.PI, false);
ctx.restore();
ctx.fill();
ctx.stroke();

function drawWindow(startX, startY) {
	ctx.fillStyle = 'black';
	var winWidth = 18;
	var winHeight = 12;
	ctx.fillRect(startX, startY, winWidth, winHeight);
	ctx.fillRect(startX + winWidth + 1, startY, winWidth, winHeight);
	ctx.fillRect(startX, startY + winHeight + 1, winWidth, winHeight);
	ctx.fillRect(startX + winWidth + 1, startY + winHeight + 1, winWidth, winHeight);
}

// windows
drawWindow(108, 70);
drawWindow(155, 70);
drawWindow(155, 103);

// door
ctx.beginPath();
ctx.moveTo(112, 111);
//            (cp1x, cp1y, cp2x, cp2y, x, y)
ctx.bezierCurveTo(110, 100, 143, 100, 142, 111);
ctx.stroke();
ctx.closePath();

ctx.beginPath();
ctx.moveTo(142 - 15.5, 102);
ctx.lineTo(142 - 15.5, 138);
ctx.stroke();
ctx.closePath();

ctx.beginPath();
ctx.moveTo(112, 111);
ctx.lineTo(112, 138);
ctx.stroke();
ctx.closePath();

ctx.beginPath();
ctx.moveTo(142, 111);
ctx.lineTo(142, 138);
ctx.stroke();
ctx.closePath();

ctx.beginPath();
ctx.arc(131, 127, 2, 0, 2 * Math.PI, false);
ctx.stroke();

ctx.beginPath();
ctx.arc(122, 127, 2, 0, 2 * Math.PI, false);
ctx.stroke();









