var canvasDrawer = (function() {
    var ctx;
    setContext('the-canvas');
    var fieldWidth;
    var fieldHeight;

    function drawObject(obj, color) {
        ctx.beginPath();
        ctx.fillStyle = color;
        ctx.fillRect(obj.x, obj.y, obj.size, obj.size);
        ctx.closePath();
    }

    function setContext(canvasId) {
        var canvas = document.getElementById(canvasId);
        ctx = canvas.getContext('2d');

        fieldWidth = ctx.canvas.width;
        fieldHeight = ctx.canvas.height;
    }

    function clearContext() {
        ctx.clearRect(0, 0, fieldWidth, fieldHeight);
    }

    function getFieldWidth() {
        return fieldWidth;
    }

    function getFieldHeight() {
        return fieldHeight;
    }

    return {
        drawObject: drawObject,
        clearContext: clearContext,
        getFieldWidth: getFieldWidth,
        getFieldHeight: getFieldHeight
    }
}());