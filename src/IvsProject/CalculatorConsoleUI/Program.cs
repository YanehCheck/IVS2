// This file is purely used as a development UI for debugging and testing the libraries

using CalculatorModel;
var calculator = new Calculator();

while (true) {
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("> ");

    var expression = Console.ReadLine();
    var result = calculator.Calculate(expression);

    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine($"> RESULT: {result.Value.ToString()}");
    Console.WriteLine($"> ERROR: {result.ErrorType.ToString()}");
}
