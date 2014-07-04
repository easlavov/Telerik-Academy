/// <reference path="_references.js" />
var gameObjects = (function() {
    var GameObject = (function() {
        var GameObject = function GameObject(x, y, size) {
            this.x = x;
            this.y = y;
            this.size = size;
        };

        return GameObject;
    }());

    var Food = (function() {
        var Food = function Food(x, y, size) {
            GameObject.call(this, x, y, size);
        };

        Food.prototype = new GameObject();
        Food.prototype.constructor = GameObject;

        return Food;
    }());

    var SnakeBodyPart = (function() {
        var SnakeBodyPart = function SnakeBodyPart(x, y, size) {
            GameObject.call(this, x, y, size);
        };

        SnakeBodyPart.prototype = new GameObject();
        SnakeBodyPart.prototype.constructor = GameObject;

        return SnakeBodyPart;
    }());

    var SnakeHead = (function() {
        var SnakeHead = function SnakeHead(x, y, size) {
            SnakeBodyPart.call(this, x, y, size);
        }

        SnakeHead.prototype = new SnakeBodyPart();
        SnakeHead.prototype.constructor = SnakeBodyPart;

        return SnakeHead;
    }());

    var Snake = (function() {
        var Snake = function Snake(snakeHead, length) {
            this.head = snakeHead;
            this.body = [];
            for (var i = 1; i < length; i++) {
                var newBodyPartX = this.head.x - (this.head.size * i);
                var newBodyPartY = this.head.y;
                var newBodyPartSize = this.head.size;
                var newBodyPart = new SnakeBodyPart(newBodyPartX, newBodyPartY, newBodyPartSize);
                this.body.push(newBodyPart);
            }
        }

        Snake.prototype = {
            move: function(direction, shouldGrow) {
                this._follow(shouldGrow);
                var step = this.head.size;
                switch (direction) {
                    case 'right':
                        this.head.x += step;
                        break;
                    case 'down':
                        this.head.y += step;
                        break;
                    case 'left':
                        this.head.x -= step;
                        break;
                    case 'up':
                        this.head.y -= step;
                        break;
                }
            },
            _follow: function(shouldGrow) {
                for (var i = this.body.length - 1; i >= 0; i--) {
                    if (shouldGrow) {
                        var newPart;
                        var lastPartX = this.body[this.body.length - 1].x;
                        var lastPartY = this.body[this.body.length - 1].y;
                        newPart = new SnakeBodyPart(
                            lastPartX,
                            lastPartY,
                            this.head.size);
                        this.body.push(newPart);
                        shouldGrow = false;
                    }

                    if (i !== 0) {
                        this.body[i].x = this.body[i - 1].x;
                        this.body[i].y = this.body[i - 1].y;
                    } else {
                        this.body[i].x = this.head.x;
                        this.body[i].y = this.head.y;
                    }
                }
            }
        };

        return Snake;
    }());

    return {
        Food: Food,
        SnakeBodyPart: SnakeBodyPart,
        SnakeHead: SnakeHead,
        Snake: Snake
    }
}());