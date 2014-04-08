var input = document.getElementById('input');
var addButton = document.getElementById('add-button');
var deleteButton = document.getElementById('delete-button');
var hideButton = document.getElementById('hide-button');
var showButton = document.getElementById('show-button');
var taskList = document.getElementById('tasks');

function addItem() {
	var text = input.value;
	var newLi = document.createElement('li');
	var newRadio = document.createElement('input');
	newRadio.type = 'radio';
	newRadio.name = 'todos';
	newLi.appendChild(newRadio);
	newLi.appendChild(document.createTextNode(text));
	taskList.appendChild(newLi);
}

function removeItem() {
	var selected = taskList.querySelectorAll(':checked');
	for (var i = 0; i < selected.length; i++) {
		var par = selected[i].parentElement;
		par.parentElement.removeChild(par);
	}
}

function hideItem() {
	var item = taskList.querySelectorAll(':checked')[0];
	var par = item.parentElement;
	par.style.display = 'none';
}

function showItems() {
	var hiddenItems = taskList.querySelectorAll('li');
	for (var i = 0; i < hiddenItems.length; i++) {
		hiddenItems[i].style.display = 'list-item';
	}
}

addButton.addEventListener('click', addItem, false);
deleteButton.addEventListener('click', removeItem, false);
hideButton.addEventListener('click', hideItem, false);
showButton.addEventListener('click', showItems, false);