/* Crеate a function that gets the value of <input
type="color"> and sets the background of the body to this value */

var changeColorButton = document.getElementsByTagName('button')[0];
changeColorButton.addEventListener('click', changeBGColor, false);