var objectsSize = 20;
var snakeHeadX = canvasDrawer.getFieldWidth() / 2;
var snakeHeadY = canvasDrawer.getFieldHeight() / 2;
var snakeHead = new gameObjects.SnakeHead(snakeHeadX, snakeHeadY, objectsSize);
var snakeLength = 4;
var theSnake = new gameObjects.Snake(snakeHead, snakeLength);
engine.generateApple(objectsSize);
engine.startGame();