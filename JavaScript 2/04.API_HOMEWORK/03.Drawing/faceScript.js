// variables
var canvas, ctx, x, y;

// draw the face
canvas = document.getElementById('face-hat');
ctx = canvas.getContext('2d');

// face colors
var teal = '#90CAD7';
var darkTeal = '#22545F';
var hatBlue = '#396693';

// draw face circle
ctx.save();
ctx.scale(1.1, 1);
x = canvas.width/2 - 15;
y = canvas.height/2 + 35;
ctx.arc(x,y,35,0,Math.PI*2,false);
ctx.restore();
ctx.fillStyle = teal;
ctx.fill();
ctx.lineWidth = 1;
ctx.strokeStyle = darkTeal;
ctx.stroke();

// draw the mouth
ctx.save();
ctx.rotate(0.1);
ctx.scale(2.6, 1);
ctx.beginPath();
ctx.arc(60, 113, 5.8, 0, 2 * Math.PI, false);
ctx.restore();
ctx.stroke();
ctx.closePath();

// draw eyes and pupils
x = 96; y = 100;
function drawEye(x, y, pupilX) {
	ctx.save();
	ctx.beginPath();
	ctx.scale(1.3, 1);
	ctx.arc(x, y, 5.3, 0, 2 * Math.PI, false);
	ctx.restore();
	ctx.stroke();
	ctx.closePath();
	
	y -= 49.7;
	
	ctx.save()
	ctx.beginPath();
	ctx.scale(1, 2);
	ctx.arc(pupilX, y, 2, 0, 2 * Math.PI, false);
	ctx.fillStyle = darkTeal;
	ctx.fill();
	ctx.restore();
	ctx.closePath();
}


drawEye(x,y, 122);
x += 25;
drawEye(x, y, 154.5);

// draw the hat
ctx.fillStyle = hatBlue;
ctx.save();
ctx.beginPath();
ctx.scale(5, 1);
ctx.arc(29.3,78, 8, 0, 2 * Math.PI, false);
ctx.closePath();
ctx.fill();
ctx.stroke();
ctx.restore();

ctx.save();
ctx.beginPath();
ctx.scale(2.5, 1);
ctx.arc(60,70, 10, 0, 2 * Math.PI, false);
ctx.closePath();
ctx.fill();
ctx.stroke();
ctx.restore();

x = 124.5; y = 29; var w = 51.5; var h = 40;
ctx.fillRect(x,y,w,h);
ctx.strokeRect(x,y,w,h);

ctx.save();
ctx.beginPath();
ctx.scale(2.5, 1);
ctx.arc(60,30, 10, 0, 2 * Math.PI, false);
ctx.closePath();
ctx.fill();
ctx.stroke();
ctx.restore();

y = 66; h = 5;
ctx.fillRect(x,y,w,h);

ctx.beginPath();
x = 142; y = 98;
ctx.moveTo(x,y);
x -= 8; y += 17;
ctx.lineTo(x, y);
x += 8;
ctx.lineTo(x,y);
ctx.strokeStyle = darkTeal;
ctx.stroke();