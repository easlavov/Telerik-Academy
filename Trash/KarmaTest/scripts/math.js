define(function () {
    var math;
    math = (function () {
        function sum(a, b) {
            return a + b;
        }

        return {
            sum: sum
        }
    })

    return math;
});