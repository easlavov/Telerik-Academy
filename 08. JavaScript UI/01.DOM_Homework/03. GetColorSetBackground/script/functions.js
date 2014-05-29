function changeBGColor() {
    var colorPicker = document.querySelector('input[type=color]');
    var value = colorPicker.value;
    document.body.style.backgroundColor = value;
}