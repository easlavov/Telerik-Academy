function Solve(params) {
    for (var i = 0; i < params.length; i++) {
        var command = params[i].split(' ');
        
        debugger;
    }
}

var testArr = [];
testArr[0] = '(def func 10)';
testArr[1] = '(def newFunc (+  func 2))';
testArr[2] = '(def sumFunc (+ func func newFunc 0 0 0))';
testArr[3] = '(* sumFunc 2)';

console.log(Solve(testArr));