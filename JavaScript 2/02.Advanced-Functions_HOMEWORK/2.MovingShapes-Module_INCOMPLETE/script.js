// NOTE: The module contains hard-coded variables for demo purposes and
// is not a final product.
var MovingShapes = (function(){
	
	// constructor
	var MovingShapes = function (container) {
		this.container = container;
		this.width = 100;
		this.height = 50;	
		this.distance = 100;
	};
	
	// constants
	
	
	// methods
	MovingShapes.prototype = {
	
		constructor:MovingShapes,
		
		add:function(type){
			var div = getRandomDiv(type, this);
			// the div is appended to the preset container
			this.container.appendChild(div);
		},
		// TODO:
		beginMovement:function(){
			var self = this;
			setInterval(function(){				
				move.call(self);
			}, 20);
		}
	}
	
	function getRandomDiv(type, that){
		var div = document.createElement('div');
		
		var style = div.style;
		
		// random background, font and border colors as per task		
		style.backgroundColor = getRandomColor();
		style.color = getRandomColor();
		style.borderColor = getRandomColor();
		
		// static dimensions as per task
		style.width = that.width + 'px';
		style.height = that.height + 'px';
		
		// border
		style.borderStyle = 'solid';
		style.borderWidth = '2px'; // thick enough to be visible
		
		// type
		if (type === 'ellipse'){
			div.style.borderRadius = '50px';
		}
		
		// position and movement pattern
		var roll = getRandomInt(0, 100);	
		if (roll < 51){
			div.motion = 'circular';
			div.angle = 0;
			// get center coords
			div.centerX = getRandomInt(100, 800);
			div.centerY = getRandomInt(100, 800);
			style.top = (div.centerY + Math.sin(div.angle) * this.distance) + 'px';
			style.left = (div.centerX + Math.cos(div.angle) * this.distance) + 'px';
		}
		else {
			div.motion = 'rectangular'
			div.path = 0;
			style.top = getRandomInt(100, 800) + 'px';
			style.left = getRandomInt(100, 1000) + 'px';
		}
		
		style.position = 'absolute';
		
		return div;
	}
	
	function getRandomColor() {
		var red = getRandomInt(0,255);
		var green = getRandomInt(0,255);
		var blue = getRandomInt(0,255);
		
		return 'rgb(' + red + ',' + green + ',' + blue + ')';
	}
	
	function getRandomInt(min, max) {
		return Math.floor(Math.random() * (max - min + 1) + min);
	}
	
	function move(){
		var divs = this.container.getElementsByTagName('div');
		for(var i in divs){
			if (divs[i].motion === 'circular'){
				moveCirc.call(this, divs[i]);
			}
			else if (divs[i].motion === 'rectangular'){
				moveRect.call(this, divs[i]);
			}
		}
		
		function moveCirc(divToMove){			
			divToMove.angle += 0.1;
			divToMove.style.top = (divToMove.centerY + Math.sin(divToMove.angle) * this.distance) + 'px';
			divToMove.style.left = (divToMove.centerX + Math.cos(divToMove.angle) * this.distance) + 'px';
		}
		
		function moveRect(divToMove){
			// rect movement is hard coded to make a 100x100x100x100 square move
			divToMove.path += 2;
			if (divToMove.path >= 0 && divToMove.path <= 100){
				var currentLeft = parseInt(divToMove.style.left, 10) + 10; // move right
				divToMove.style.left = currentLeft + 'px';				
			}
			else if (divToMove.path >= 101 && divToMove.path <= 200){
				var currentTop = parseInt(divToMove.style.top, 10) + 10; // move down
				divToMove.style.top = currentTop + 'px';
			}
			else if (divToMove.path >= 201 && divToMove.path <= 300){
				var currentLeft = parseInt(divToMove.style.left, 10) - 10; // move left
				divToMove.style.left = currentLeft + 'px';
			}
			else if (divToMove.path >= 301 && divToMove.path <= 400){
				
				var currentTop = parseInt(divToMove.style.top, 10) - 10; // move up
				divToMove.style.top = currentTop + 'px';
			}
			if (divToMove.path == 400){
				divToMove.path = 0;
			}
		}
	
	}
	
	return MovingShapes;
})();

function testOne(){	
	var movingShapes = new MovingShapes(document.body);
	for (var i = 0; i < 5; i++) {
		movingShapes.add('ellipse')
	}
	for (var i = 0; i < 5; i++) {
		movingShapes.add('rect')
	}
	movingShapes.beginMovement();
	
	// document.getElementById('testOneButton').disabled = true;
	return false;
}

function testTwo(){
	
}