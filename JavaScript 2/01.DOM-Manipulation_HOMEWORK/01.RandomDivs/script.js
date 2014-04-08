function onCreateDivsButtonClick () {
	var divCount = document.getElementById("input-text").value | 0;
	createDivs(divCount);
	
	return false;
}

function createDivs(count) {
	// clean main div
	var contentDiv = document.getElementById("content");
	while (contentDiv.firstChild) {contentDiv.removeChild(contentDiv.firstChild);}
	
	// create divs
	var docFrag = document.createDocumentFragment();	
	for (var i = 0; i < count; i++) {
		var div = document.createElement("div");
		randomizeDiv(div);
		docFrag.appendChild(div);
	}
	contentDiv.appendChild(docFrag);	
}

// div randomizator
function randomizeDiv(div) {
		var st = div.style;
		var divHeight = getRandomInt(20, 100);
		st.height = divHeight + 'px';
		var divWidth = getRandomInt(20, 100);
		st.width = divWidth + 'px';
		
		st.backgroundColor = getRandomColor();
		st.color = getRandomColor();
		
		var strongElement = document.createElement('strong');
		strongElement.innerHTML = 'div';
		div.appendChild(strongElement);
		
		st.borderRadius = getRandomInt(0, 30) + 'px';
		st.borderColor = getRandomColor();
		var border = getRandomInt(0, 20);
		st.borderWidth = border + 'px';
		st.borderStyle = 'solid';
		
		st.position = 'absolute';		
		st.top = getRandomInt(0, screen.availHeight - divHeight - border) + 'px';
		st.left = getRandomInt(0, screen.availWidth - divWidth - border) + 'px';
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