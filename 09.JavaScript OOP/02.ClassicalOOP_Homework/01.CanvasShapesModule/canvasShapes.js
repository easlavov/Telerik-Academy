var CanvasShapes = (function () {
    var CanvasShapes = function(canvasId){
        this.context = getContext(canvasId);
        this.DEFAULT_FILL_COLOR = 'black';
        this.DEFAULT_STROKE_COLOR = 'black';
        this.DEFAULT_STROKE_WIDTH = 2;

        function getContext(id) {
            var canvas = document.getElementById(id);
            if (!canvas) {
                throw 'Incorrect ID passed as argument';
            }

            var ctx = canvas.getContext('2d');
            return ctx;
        }
    };

    CanvasShapes.prototype = {
        fillRectangle : function fillRectangle(x, y, width, height, fillColor) {
            this.context.fillStyle = fillColor || this.DEFAULT_FILL_COLOR;
            this.context.fillRect(x, y, width, height);
        },

        strokeRectangle : function strokeRectangle(x, y, width, height, strokeColor, strokeWidth) {
            this.context.strokeStyle = strokeColor || this.DEFAULT_STROKE_COLOR;
            this.context.lineWidth = strokeWidth || this.DEFAULT_STROKE_WIDTH;
            this.context.strokeRect(x, y, width, height);
        },

        fillCircle : function fillCircle(x, y, radius, fillColor) {
            this.context.fillStyle = fillColor || this.DEFAULT_FILL_COLOR;
            this.context.beginPath();
            this.context.arc(x, y, radius, 0, 2 * Math.PI, true);
            this.context.fill();
            this.context.closePath();
        },

        strokeCircle : function strokeCircle(x, y, radius, strokeColor, strokeWidth) {
            this.context.strokeStyle = strokeColor || this.DEFAULT_STROKE_COLOR;
            this.context.lineWidth = strokeWidth || this.DEFAULT_STROKE_WIDTH;
            this.context.beginPath();
            this.context.arc(x, y, radius, 0, 2 * Math.PI, true);
            this.context.stroke();
            this.context.closePath();
        },

        line : function line(x1, y1, x2, y2, color, strokeWidth) {
            this.context.strokeStyle = color || this.DEFAULT_STROKE_COLOR;
            this.context.lineWidth = strokeWidth || this.DEFAULT_STROKE_WIDTH;
            this.context.beginPath();
            this.context.moveTo(x1, y1);
            this.context.lineTo(x2, y2);
            this.context.stroke();
            this.context.closePath();
        }
    };

    return CanvasShapes;
})();
