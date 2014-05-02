taskName = "2. Remove elements";

Array.prototype.remove = function (element) {
    for (var i = this.length-1; i >= 0; i--) {
        if (this[i] == element) {
            this.splice(i, 1);
        }
    }
}

function Main(bufferElement) {
    var inputArray = ReadLine('Enter array elements sepparated by commas (,) or use default values: ', '1,5,3,1,5,5,8,9,1,3,4')
    var inputElement = ReadLine('Enter element to remove or use default: ', '1');

    SetSolveButton(function () {
        var array = ParseStringCollection(inputArray, ',');
        var element = inputElement.value;
        array.remove(element);
        WriteLine('New array is ' + array);
    });
}
