taskName = "3. Deep clone";

function clone(obj) {
    // Handle the 3 simple types, and null or undefined
    if (null == obj || "object" != typeof obj) return obj;

    var copy;

    // Handle Date
    if (obj instanceof Date) {
        copy = new Date();
        copy.setTime(obj.getTime());		
        return copy;
    }

    // Handle Array
    if (obj instanceof Array) {
        copy = [];
        for (var i = 0, len = obj.length; i < len; i++) {
            copy[i] = clone(obj[i]);
        }		
        return copy;
    }

    // Handle Object
    if (obj instanceof Object) {
        copy = {};
        for (var attr in obj) {
            if (obj.hasOwnProperty(attr)) {
				copy[attr] = clone(obj[attr]);
			}
        }		
        return copy;
    }
}

function Main(bufferElement) {
    WriteLine('Element 1 will be of primitive type. Element 1a will be its deep copy.');
    WriteLine('Element 2 will be of reference type (object). Element 2a will be its deep copy.');

    var element1 = 'Karamba!';
    var element2 = {
        prop1: "hello",
        prop2: 1
    };

    SetSolveButton(function () {

        var element1a = clone(element1);
        var element2a = clone(element2);
        WriteLine('Performing deep cloning after which:');
        var equal1 = element1 === element1a;
        var equal2 = element2 === element2a;
        if (equal1) {
            WriteLine('Element1 is equal to Element1a. They are of the same value. Expected behavior.');
        } else {
            WriteLine('Element1 is not equal to Element1a');
        }
        
        if (equal2) {
            WriteLine('Element2 is equal to Element2a (deep copied incorrectly!).');
        } else {
            WriteLine('Element2 is not equal to Element2a (reference type deep copied correctly!)');
        }
    });
}