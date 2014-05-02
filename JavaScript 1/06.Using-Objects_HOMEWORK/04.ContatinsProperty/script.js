taskName = "4. Contains property";

function hasProperty(obj, prop) {
    if (obj.hasOwnProperty(prop)) {
        return true;
    } else {
        return false;
    }    
}

function Main(bufferElement) {
    WriteLine('Two variables have been created. The first one is an Array.'
        + 'The second one is a number. We look for the property "length". Press Solve.');
    var arr = new Array(5);
    var arrHasProp = hasProperty(arr, 'length');
    var num = 5;
    var numHasProp = hasProperty(num, 'length')

    SetSolveButton(function () {
        if (arrHasProp) {
            WriteLine('The Array has the property "length".')
        } else {
            WriteLine('The Array does not have the property "length".')
        }

        if (numHasProp) {
            WriteLine('The number has the property "length".')
        } else {
            WriteLine('The number does not have the property "length".')
        }       
    });
}