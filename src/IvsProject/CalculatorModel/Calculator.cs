using MathParser;

namespace CalculatorModel 
{
    /// <summary>
    /// Used to calculate mathematical expression.
    /// </summary>
    public class Calculator 
    {
        /// <summary>
        /// Indicates to how many places is the calculation value rounded.
        /// </summary>
        public int DecimalPlaces { get; set; }

        /// <summary>
        /// Holds reference to <see cref="Parser"/> instance.
        /// </summary>
        private Parser Parser { get; init; }

        /// <summary>
        /// Holds reference to <see cref="ReversePolishNotationEvaluator"/> instance.
        /// </summary>
        private ReversePolishNotationEvaluator RpnEvaluator { get; init; }

        /// <summary>
        /// Initializes a new instance of <see cref="Calculator"/> type.
        /// </summary>
        /// <param name="decimalPlaces"> To how many decimal places to round. </param>
        public Calculator(int decimalPlaces = 8) 
        {
            DecimalPlaces = decimalPlaces;
            Parser = new Parser();
            RpnEvaluator = new ReversePolishNotationEvaluator();
        }

        /// <summary>
        /// Calculates the value of mathematical expression.
        /// </summary>
        /// <param name="expression"> Mathematical expression. </param>
        /// <returns><see cref="CalculationResult"/></returns>
        public CalculationResult Calculate(string expression) 
        {
            var parseResult = Parser.Parse(expression);
            if (parseResult.SyntaxError) 
            {
                return new CalculationResult(0, CalculationErrorType.SyntaxError);
            }

            return RpnEvaluator.EvaluateExpression(parseResult.Expression);
        }
    }
}