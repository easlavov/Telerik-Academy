textbox = document.getElementById('txt-area');
fontInput = document.getElementById('font-color-input');
bgInput = document.getElementById('bg-color-input');

function onChangeFontColorInput() {
	var color = fontInput.value;
	if (color[0] != '#') {
		color = '#' + color;
	}
	textbox.style.color = color;
}

function onChangeBgColorInput() {
	var color = bgInput.value;
	if (color[0] != '#') {
		color = '#' + color;
	}
	textbox.style.backgroundColor = color;
}

function reset() {
	textbox.value = 'Test text';
	fontInput.value = null;
	bgInput.value = null;
}