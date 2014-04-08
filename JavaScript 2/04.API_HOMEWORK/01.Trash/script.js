(function dragNDrop(){		
	var totalJunk = 20;
	var body = document.body;
	var wrapper = document.getElementById('game-wrapper');
	var highScoresContainer = document.getElementById('highscores');
	updateHighScoresList();
	// generate and place bin
	var bin = document.createElement('img');
	bin.id = 'bin';
	bin.style.position = 'absolute';
	bin.style.left = '100px';
	bin.style.top = '100px';
	bin.src = 'bin_closed.png';	
	wrapper.appendChild(bin);
	
	// generate and place junk
	for (var i = 1; i <= totalJunk; i++) {
		var junk = document.createElement('img');
		junk.className = 'junk';
		junk.style.position = 'absolute';
		junk.style.top = getRandomInt(20, 500) + 'px';
		junk.style.left = getRandomInt(0, 900) + 'px';
		junk.draggable = true;
		junk.src = 'junk.png';
		junk.id = 'junk' + i;

		wrapper.appendChild(junk);
	}

	// variables for junk movement
	var junkX;
	var junkY;
	var draggedJunk;
	
	// scoring variables
	var hasGameStarted = false;
	var seconds = 0;
	var timer;
	
	function handleDragStart (ev) {
		if (!hasGameStarted) {
			startGame();
		}
		ev.dataTransfer.setData('dragged-id', ev.target.id);
		draggedJunk = ev.target;
		junkX = ev.offsetX === undefined ? ev.layerX : ev.offsetX;
		junkY = ev.offsetY === undefined ? ev.layerY : ev.offsetY;
	}

	function handleDrop (ev) {
		ev.preventDefault();
		if (ev.dataTransfer.getData('dragged-id') != 'bin') {
			if (ev.target.id === 'bin') {
				var junkId = ev.dataTransfer.getData('dragged-id');
				var junkToRemove = document.getElementById(junkId);				
				wrapper.removeChild(junkToRemove);
				bin.src = 'bin_closed.png';
				
				totalJunk--;
				if (totalJunk === 0) {
					endGame();
				}
				return;
			}
			draggedJunk.style.left = ev.pageX - junkX + 'px';
			draggedJunk.style.top = ev.pageY - junkY + 'px';
		}		
	}

	function handleDragOver (ev) {
		ev.preventDefault();
		if (ev.target.id === 'bin' && ev.dataTransfer.getData('dragged-id') != 'bin') {
			bin.src = 'bin_opened.png';
		}
		else {
			bin.src = 'bin_closed.png';
		}
	}

	function getRandomInt(min, max) {
		return Math.floor(Math.random() * (max - min + 1) + min);
	}
	
	function startGame() {
		hasGameStarted = true;
		timer = setInterval(tick, 1000);
	}
	
	function tick() {
		seconds++;
	}
	
	function endGame() {
		clearInterval(timer);
		var prompt;
		while (!prompt) {
			prompt = window.prompt("Please enter your name",'Name');
		}
		if (prompt.length > 10) {
			prompt = prompt.substring(0, 10);
		}
		localStorage.setItem(prompt, seconds);
		updateHighScoresList();
	}
	
	function Score (name, score) {
		this.name = name;
		this.score = score;
	}

	function compareScores(a,b) {
		a = parseInt(a.score);
		b = parseInt(b.score);
	    if (a < b) { return -1 }
	     
	    if (a > b) { return 1 }
	    
	    return 0;
	}


	function updateHighScoresList() {
		var highScoresArr = [];
		for(var sc in localStorage) {
			if (localStorage.hasOwnProperty(sc)) {
				var playerName = sc;
				var playerScore = localStorage.getItem(sc);
				highScoresArr.push(new Score(playerName, playerScore));
			}
		}		
		highScoresArr.sort(compareScores);

		var docFrag = document.createDocumentFragment();
		var maxIt = highScoresArr.length;
		if (maxIt > 5) {maxIt = 5};
		for (var i = 0; i < maxIt; i++) {
			var newDiv = document.createElement('div');
			var text = highScoresArr[i].name + ' ' + highScoresArr[i].score;
			newDiv.innerHTML = text;
			docFrag.appendChild(newDiv);
		}

		while(highScoresContainer.firstChild){
		    highScoresContainer.removeChild(highScoresContainer.firstChild);
		}
		
		highScoresContainer.appendChild(docFrag);
	}

	function clearStorage () {
		var wantClear = window.confirm('Do you want to clear the local storage?');
		if (wantClear) {localStorage.clear()};
		updateHighScoresList();
	}
	
	// set event listeners and handlers
	body.addEventListener('dragstart', handleDragStart, false);
	body.addEventListener('drop', handleDrop, false);
	body.addEventListener('dragover', handleDragOver, false);
	var clStBut = document.getElementById('clear-storage-button');
	clStBut.addEventListener('click', clearStorage, false);
})();