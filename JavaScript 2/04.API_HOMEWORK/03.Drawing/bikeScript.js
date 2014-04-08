(function() {
	var ctx = document.getElementById('bike').getContext('2d');
	var x, y;
	var light = '#90CAD7';
	var dark = '#337D8F';
	
	// draw wheels
	x = 70; y = 100; var wheelRadius = 30;	
	ctx.fillStyle = light;
	ctx.strokeStyle = dark;
	drawCircle(wheelRadius, true);
	x = 205;
	drawCircle(wheelRadius, true);
	
	// draw frame
	ctx.beginPath();
	ctx.moveTo(70, 100); // westmost
	x = 130; y = 98; // pedal center
	ctx.lineTo(x, y);	
	ctx.closePath();
	ctx.stroke();
	
	drawCircle(8, false);
	
	ctx.beginPath();
	ctx.moveTo(x,y);
	x = 198; y = 61; // eastmost
	ctx.lineTo(x, y);
	ctx.closePath();
	ctx.stroke();
	
	ctx.beginPath();
	ctx.moveTo(x,y);
	x = 110;
	ctx.lineTo(x, y);
	ctx.closePath();
	ctx.stroke();
	
	ctx.beginPath();
	ctx.moveTo(x, y);
	x = 70; y = 100;
	ctx.lineTo(x, y);
	ctx.closePath();
	ctx.stroke();
	
	ctx.beginPath();
	x = 130; y = 98;
	ctx.moveTo(x, y);
	ctx.lineTo(100, 46); //
	ctx.moveTo(85, 46);
	ctx.lineTo(120, 46);
	ctx.closePath();
	ctx.stroke();
	
	// draw pedals
	ctx.beginPath();
	x = 130 + 5; y = 98 + 5;
	ctx.moveTo(x, y);
	ctx.lineTo(x + 8, y + 8);
	
	ctx.moveTo(x - 10, y - 10);
	ctx.lineTo(x - 17, y - 17);
	ctx.closePath();
	ctx.stroke();
	
	// draw front
	x = 205; y = 100;
	ctx.beginPath();
	ctx.moveTo(x, y);
	ctx.lineTo(194, 35);
	ctx.moveTo(194, 35);
	ctx.lineTo(219, 11);
	ctx.moveTo(194, 35);
	ctx.lineTo(160, 45);
	ctx.closePath();
	ctx.stroke();
	

	function drawCircle(radius, fill) {
		ctx.beginPath();
		ctx.arc(x, y, radius, 0, Math.PI * 2, false);
		if (fill === true) ctx.fill();
		ctx.stroke();
		ctx.closePath();
	}
}())