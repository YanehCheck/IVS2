// This file is purely used as a development UI for debugging and testing the libraries

using System.Globalization;
using CalculatorModel;
using System.Linq.Expressions;

var calculator = new Calculator();

(string, CalculationResult)[] testingSet = new ValueTuple<string, CalculationResult>[] {
        ("5 * (24 - 2 ^ 3 + (18 - (24 - 16 / 2 ^ 4))) + 7", new CalculationResult(62)),
        ("18 - 3 * 4 + (20 / (10 + 2 * (3 * 2^2 - 21 / 3))) - 3 * 2", new CalculationResult(1)),
        ("36+10*0.5-18/6", new CalculationResult(38))
};

Console.WriteLine("> 1 = TESTS\n> 2 = INPUT MODE");
Console.ForegroundColor = ConsoleColor.Yellow;
Console.Write("> ");
string answer = Console.ReadLine();

Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine(">---------------------------");

if (answer == "1") {
    foreach (var test in testingSet) {
        var result = calculator.Calculate(test.Item1);
        Console.ForegroundColor = ConsoleColor.Green;
        if (result.Value != test.Item2.Value || result.ErrorType != test.Item2.ErrorType) {
            Console.ForegroundColor = ConsoleColor.Red;
        }

        Console.WriteLine($"> EXPECTED RESULT: {test.Item2.Value.ToString(CultureInfo.InvariantCulture.NumberFormat)}");
        Console.WriteLine($"> RESULT: {result.Value.ToString(CultureInfo.InvariantCulture.NumberFormat)}");
        Console.WriteLine($"> EXPECTED ERROR: {test.Item2.ErrorType}");
        Console.WriteLine($"> ERROR: {result.ErrorType}");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(">-------");
    }

    Console.ReadLine();
}

while (true) {
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("> ");

    var expression = Console.ReadLine();
    var result = calculator.Calculate(expression);

    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine($"> RESULT: {result.Value.ToString(CultureInfo.InvariantCulture.NumberFormat)}");
    Console.WriteLine($"> ERROR: {result.ErrorType.ToString()}");
}
