using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MathParser;
using Math = MathLib.Math;

namespace CalculatorModel 
{
    internal class ReversePolishNotationEvaluator 
    {
        /// <summary>
        /// Used for storing the operands when evaluating the expression.
        /// </summary>
        private Stack<decimal> operands { get; init; }

        /// <summary>
        /// Creates new <see cref="ReversePolishNotationEvaluator"/> instance.
        /// </summary>
        public ReversePolishNotationEvaluator() 
        {
            operands = new Stack<decimal>();
        }

        /// <summary>
        /// Evaluates a reverse polish notation expression.
        /// </summary>
        /// <param name="expression"> A list containing valid tokens and ordered in reverse polish notation. </param>
        /// <returns><see cref="CalculationResult"/></returns>
        public CalculationResult EvaluateExpression(List<string> expression) 
        {
            foreach (var token in expression) 
            {
                var isNumber = ParseNumber(token, out var number);
                if (isNumber) 
                {
                    operands.Push(number);
                    continue;
                }
                var @operator = ParseOperator(token);
                // Invalid operators should be covered by Parser class
                // But lets make it more future-proof
                if (@operator == OperatorType.Invalid) {
                    return new CalculationResult(0, CalculationErrorType.SyntaxError);
                }

                var numberOfOperands = GetNumberOfOperands(@operator);
                if (numberOfOperands == 1) {
                    var operand = operands.Pop();

                    CalculationResult result;
                    try {
                        result = EvaluateOneOperand(@operator, operand);
                    }
                    catch {
                        return new CalculationResult(0, CalculationErrorType.OverflowError);
                    }

                    if (result.ErrorType != CalculationErrorType.None) {
                        return result;
                    }
                    operands.Push(result.Value);
                }
                else {
                    var leftOperand = operands.Pop();
                    var rightOperand = operands.Pop();
                    CalculationResult result;
                    try {
                        result = EvaluateTwoOperands(@operator, leftOperand, rightOperand);
                    }
                    catch {
                        return new CalculationResult(0, CalculationErrorType.OverflowError);
                    }

                    if (result.ErrorType != CalculationErrorType.None) {
                        return result;
                    }
                    operands.Push(result.Value);
                }
            }

            var popSuccess = operands.TryPop(out var finalResult);
            if (!popSuccess || popSuccess && operands.TryPeek(out _)) {
                operands.Clear();
                return new CalculationResult(0, CalculationErrorType.InternalError);
            }
            return new CalculationResult(finalResult);
        }

        /// <summary>
        /// Evaluates unary operation.
        /// </summary>
        /// <param name="operator"> Unary <see cref="OperatorType"/></param>
        /// <param name="operand"> Operand. </param>
        /// <returns><see cref="CalculationResult"/></returns>
        private CalculationResult EvaluateOneOperand(OperatorType @operator, decimal operand) 
        {
            decimal result;
            if (@operator == OperatorType.Factorial) {
                return operand switch {
                    _ when operand < 0 => new CalculationResult(0, CalculationErrorType.NotNaturalFactorialError),
                    _ when operand % 1 != 0 => new CalculationResult(0, CalculationErrorType.NotNaturalFactorialError),
                    _ => new CalculationResult( (decimal) Math.Factorial((int) operand))
                };
            }

            return new CalculationResult(0, CalculationErrorType.InternalError);
        }

        /// <summary>
        /// Evaluates binary operation.
        /// </summary>
        /// <param name="operator"> Binary <see cref="OperatorType"/></param>
        /// <param name="leftOperand"> Left operand. </param>
        /// <param name="rightOperand"> Right operand. </param>
        /// <returns><see cref="CalculationResult"/></returns>
        private CalculationResult EvaluateTwoOperands(OperatorType @operator, decimal leftOperand, decimal rightOperand) 
        {
            decimal result;
            // Any operands should be valid for these
            if(@operator is OperatorType.Add or OperatorType.Subtract or OperatorType.Multiply) 
            {
                return @operator switch 
                {
                    OperatorType.Add => new CalculationResult(Math.Add(leftOperand, rightOperand)),
                    OperatorType.Subtract => new CalculationResult(Math.Subtract(leftOperand, rightOperand)),
                    OperatorType.Multiply => new CalculationResult(Math.Multiply(leftOperand, rightOperand)),
                    _ => new CalculationResult(0, CalculationErrorType.InternalError)
                };
            }
            // Division by zero is invalid
            if (@operator is OperatorType.Divide or OperatorType.Modulo) 
            {
                if (rightOperand == default) {
                    return new CalculationResult(0, CalculationErrorType.DivisionByZeroError);
                }

                return @operator switch
                {
                    OperatorType.Divide => new CalculationResult(Math.Divide(leftOperand, rightOperand)),
                    OperatorType.Modulo => new CalculationResult(Math.Modulo(leftOperand, rightOperand)),
                    _ => new CalculationResult(0, CalculationErrorType.InternalError)
                };
            }
            // Non natural exponent is invalid
            if (@operator is OperatorType.Pow) 
            {
                if (rightOperand < 0 || rightOperand % 1 != 0) 
                {
                    return new CalculationResult(0, CalculationErrorType.NotNaturalExponentError);
                }

                return new CalculationResult(Math.Pow(leftOperand, (int) rightOperand));
            }
            // Zero in index and forms that would result only in complex solutions are not allowed.
            if (@operator is OperatorType.Root) {
                if (leftOperand == 0) 
                    return new CalculationResult(0, CalculationErrorType.DivisionByZeroErrorInIndex);
                if (rightOperand < 0 && leftOperand % 2 == 0 && IsFractionOfTwo(leftOperand))
                    return new CalculationResult(0, CalculationErrorType.NoRealSolutionError);
                return new CalculationResult(Math.Root(leftOperand, rightOperand));
            }

            // Unreachable
            return new CalculationResult(0, CalculationErrorType.InternalError);
        }

        /// <summary>
        /// Wrapper for parsing decimal from string.
        /// </summary>
        /// <param name="number">String to be converted.</param>
        /// <param name="result">Variable where to store the result.</param>
        /// <returns>Value indicating if the conversion was successful.</returns>
        private bool ParseNumber(string number, out decimal result) 
        {
            return decimal.TryParse(number, NumberStyles.Any, CultureInfo.GetCultureInfo("en-EN").NumberFormat, out result);
        }

        /// <summary>
        /// Converts operator from string representation to enum.
        /// </summary>
        /// <param name="operator">String representation of a single operator.</param>
        /// <returns><see cref="OperatorType"/></returns>
        private OperatorType ParseOperator(string @operator) 
        {
            return @operator switch {
                "+" => OperatorType.Add,
                "-" => OperatorType.Subtract,
                "*" => OperatorType.Multiply,
                "/" => OperatorType.Divide,
                "%" => OperatorType.Modulo,
                "!" => OperatorType.Factorial,
                "^" => OperatorType.Pow,
                "√" => OperatorType.Root,
                _ => OperatorType.Invalid
            };
        }

        /// <summary>
        /// Gets the number of operands of an operator.
        /// </summary>
        /// <param name="operator"><see cref="OperatorType"/></param>
        /// <returns>Number of operators.</returns>
        private int GetNumberOfOperands(OperatorType @operator) 
        {
            switch (@operator) {
                case OperatorType.Add:
                case OperatorType.Subtract:
                case OperatorType.Multiply:
                case OperatorType.Divide:
                case OperatorType.Modulo:
                case OperatorType.Pow:
                case OperatorType.Root:
                    return 2;
                case OperatorType.Factorial:
                    return 1;
                default:
                    return 0;
            }
        }

        /// <summary>
        ///  Checks if a number is fraction of two.
        ///  Warning - May not always be accurate due to floating point errors.
        /// </summary>
        /// <param name="n"> Decimal number</param>
        /// <returns></returns>
        private bool IsFractionOfTwo(decimal n) 
        {
            if (n == 0) return true;

            if (n < 0) 
            {
                while(n > -2.000001m) 
                {
                    if(n == -2m)
                        return true;
                    n *= 2;
                }
            }

            while (n < 2.000001m) 
            {
                if(n == 2m) 
                    return true;
                n *= 2;
            }

            return false;
        }
    }
}
