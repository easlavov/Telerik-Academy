taskName = "1. Planar coordinate system";

function Main(bufferElement) {

	var number = ReadLine("Enter a number: ", "13");

    SetSolveButton(function () {

    	CheckOddOrEven(number.value);
    });
}

function CheckOddOrEven(number) {
	number = parseInt(number);

	WriteLine(Format("The number {0} is: {1}", number, (number % 2 != 0 ? "ODD" : "EVEN")));
}