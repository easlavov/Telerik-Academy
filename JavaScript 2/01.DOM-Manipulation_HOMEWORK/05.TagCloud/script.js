
// TODO: Fix styling; clear cloud on button click; pick a good example!

function onCreateCloudButtonClick() {
	var source = document.getElementById('source');
	var text = source.textContent;
	
	fillTagCloud(text);
	
	return false;
}

function fillTagCloud (text) {
	var words = text.match(/\b\w*\b/g); // returns a lot of empty elements
	words = removeEmptyEntries(words);
	var total = words.length;
	
	// create a dictionary to hold count of words
	var wordsDict = countWords(words);	
	
	// get font size
	var minFontSize = document.getElementById('min-size-input').value | 0;
	var maxFontSize = document.getElementById('max-size-input').value | 0;
	var diff = Math.abs(maxFontSize - minFontSize);
	
	// get cloud container
	var cloud = document.getElementById('cloud-div');
	
	// append tags to container
	for (var word in wordsDict){
		if (wordsDict.hasOwnProperty(word)){
			var count = wordsDict[word];
			appendTag(word, count);
		}
	}
	
	return false;
	
	function appendTag(word, count) {
		var appearancePerc = count/total;
		var fontSize = (appearancePerc * diff) + minFontSize;
		var tag = document.createElement('span');
		tag.textContent = word;
		tag.style.fontSize = fontSize + 'px';
		cloud.appendChild(tag);
	}
}



function removeEmptyEntries(array) {
	var result = new Array();
	for (var i = 0; i < array.length; i++) {
		if (array[i] != '') {
			result.push(array[i].toLowerCase());
		}
	}
	
	return result;
}

function countWords(words) {
	var wordsDict = new Object();
	for (var i = 0; i < words.length; i++) {
		if (!wordsDict.hasOwnProperty(words[i])){
			wordsDict[words[i]] = 1;
		}
		else {
			wordsDict[words[i]]++;
		}		
	}
	
	return wordsDict;
}