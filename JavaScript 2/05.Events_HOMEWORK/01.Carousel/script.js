var wrapper = document.getElementById('images');
var currentFirst = 1;
var totalImages = 21;
var prevButton = document.getElementById('prev');
var nextButton = document.getElementById('next');
// initialization
for (var i = 1; i <= 3; i++) {
	var img = document.createElement('img');
	img.src = 'images\\' + i + '.jpg';
	wrapper.appendChild(img);
}

function next() {
	var children = wrapper.childNodes;
	currentFirst += 1;	
	if (currentFirst > totalImages) {
		currentFirst = 1;
	}
	var index = currentFirst;
	for (var i = 0; i < children.length; i++) {
		children[i].src = 'images\\' + index + '.jpg';
		index++;
		if (index > totalImages) {
			index = 1;
		}
	}
}

function prev() {
	var children = wrapper.childNodes;	
	currentFirst -= 1;
	if (currentFirst < 1) {
		currentFirst = totalImages;
	}
	var index = currentFirst;
	for (var i = 0; i < children.length; i++) {
		children[i].src = 'images\\' + index + '.jpg';
		index++;
		if (index > totalImages) {
			index = 1;
		}
		
	}
}

prevButton.addEventListener('click', prev, false);
nextButton.addEventListener('click', next, false);