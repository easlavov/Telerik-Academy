var CanvasShapes = function(canvasId){
    var context = getContext(canvasId);
    var DEFAULT_FILL_COLOR = 'black';
    var DEFAULT_STROKE_COLOR = 'black';
    var DEFAULT_STROKE_WIDTH = 2;

    function fillRectangle(x, y, width, height, fillColor) {
        context.fillStyle = fillColor || DEFAULT_FILL_COLOR;
        context.fillRect(x, y, width, height);
    }

    function strokeRectangle(x, y, width, height, strokeColor, strokeWidth) {
        context.strokeStyle = strokeColor || DEFAULT_STROKE_COLOR;
        context.lineWidth = strokeWidth || DEFAULT_STROKE_WIDTH;
        context.strokeRect(x, y, width, height);
    }

    function fillCircle(x, y, radius, fillColor) {
        context.fillStyle = fillColor || DEFAULT_FILL_COLOR;
        context.beginPath();
        context.arc(x, y, radius, 0, 2 * Math.PI, true);
        context.fill();
        context.closePath();
    }

    function strokeCircle(x, y, radius, strokeColor, strokeWidth) {
        context.strokeStyle = strokeColor || DEFAULT_STROKE_COLOR;
        context.lineWidth = strokeWidth || DEFAULT_STROKE_WIDTH;
        context.beginPath();
        context.arc(x, y, radius, 0, 2 * Math.PI, true);
        context.stroke();
        context.closePath();
    }

    function line(x1, y1, x2, y2, color, strokeWidth) {
        context.strokeStyle = color || DEFAULT_STROKE_COLOR;
        context.lineWidth = strokeWidth || DEFAULT_STROKE_WIDTH;
        context.beginPath();
        context.moveTo(x1, y1);
        context.lineTo(x2, y2);
        context.stroke();
        context.closePath();
    }

    function getContext(id) {
        var canvas = document.getElementById(id);
        if (!canvas) {
            throw 'Incorrect ID passed as argument';
        }

        var ctx = canvas.getContext('2d');
        return ctx;
    }

    return {
        fillRectangle : fillRectangle,
        strokeRectangle : strokeRectangle,
        fillCircle : fillCircle,
        strokeCircle : strokeCircle,
        line : line
    }
};