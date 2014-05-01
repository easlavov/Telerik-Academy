var write = jsConsole.writeLine;

function printRealRoots(constantA, constantB, constantC) {
    var x1, x2, discriminant;

    // Check if the equation is quadratic:
    if (constantA === 0) {
        write("The given constants don't constitute a quadratic equation.");
    } else {
        discriminant = (constantB * constantB) - (4 * constantA * constantC);
        if (discriminant < 0) {
            write("The quadratic equation does not have real roots.");
        } else if (discriminant === 0) {
            x1 = -constantB / (2 * constantA);
            write("The quadratic equation's only real root is " + x1);
        } else if (discriminant > 0) {
            x1 = (-constantB + Math.sqrt(discriminant)) / (2 * constantA);
            x2 = (-constantB - Math.sqrt(discriminant)) / (2 * constantA);
            write("The quadratic equation's real roots are " + x1 + " and " + x2);
        }
    }
}

write('Task: Write a script that enters the coefficients a, b and c of a quadratic equation');
write('Look in scripts/06.QuadraticEquation.js for the code.');
write(' ');
write('Testing function.');

write('Testing with 5, -2 and 3: ');
printRealRoots(5, -2, 3);
write('Testing with -2, 3 and 2: ');
printRealRoots(-2, 3, 2);
write('Testing with 0, 3 and 2: ');
printRealRoots(0, 3, 2);