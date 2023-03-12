using System.Numerics;

namespace MathLib {
    /// <summary>
    /// Math library that provides modulo and elementary mathematical operations.
    /// </summary>
    public static class Math {
        /// <summary>
        /// Adds two numbers.
        /// </summary>
        /// <param name="leftOperand"> Addend. </param>
        /// <param name="rightOperand"> Addend. </param>
        /// <returns>
        /// The sum of <paramref name="leftOperand"></paramref> and <paramref name="rightOperand"></paramref>.
        /// </returns>
        public static T Add<T>(T leftOperand, T rightOperand) where T : INumber<T> 
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Subtracts two numbers.
        /// </summary>
        /// <param name="leftOperand"> Minuend. </param>
        /// <param name="rightOperand"> Subtrahend. </param>
        /// <returns>
        /// The difference after subtracting <paramref name="rightOperand"></paramref> from <paramref name="leftOperand"></paramref>.
        /// </returns>
        public static T Subtract<T>(T leftOperand, T rightOperand) where T : INumber<T> 
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Multiplies two numbers.
        /// </summary>
        /// <param name="leftOperand"> Multiplier. </param>
        /// <param name="rightOperand"> Multiplicand. </param>
        /// <returns>
        /// The product after multiplying <paramref name="leftOperand"></paramref> with <paramref name="rightOperand"></paramref>.
        /// </returns>
        public static T Multiply<T>(T leftOperand, T rightOperand) where T : INumber<T> 
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Divides two numbers.
        /// </summary>
        /// <param name="leftOperand"> Dividend. </param>
        /// <param name="rightOperand"> Divisor. </param>
        /// <returns>
        /// The quotient after dividing <paramref name="leftOperand">leftOperand</paramref> by <paramref name="rightOperand">rightOperand</paramref>.
        /// </returns>
        /// <exception cref="DivideByZeroException"> Thrown when the <paramref name="rightOperand">rightOperand</paramref> is zero.</exception>
        public static T Divide<T>(T leftOperand, T rightOperand) where T : INumber<T> 
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds the remainder after division of two numbers.
        /// </summary>
        /// <param name="leftOperand"> Dividend. </param>
        /// <param name="rightOperand"> Divisor. </param>
        /// <returns>
        /// The remainder after dividing <paramref name="leftOperand"></paramref> by <paramref name="rightOperand"></paramref>.
        /// </returns>
        /// <exception cref="DivideByZeroException"> Thrown when the <paramref name="rightOperand"></paramref> is zero.</exception>
        /// 
        public static T Modulo<T>(T leftOperand, T rightOperand) where T : INumber<T> {
            if (!IsFinite(new[] { leftOperand, rightOperand })) throw new NotFiniteNumberException();

            // default(T) is zero in any numeric type
            if (rightOperand == default(T)) {
                throw new DivideByZeroException();
            }

            var result = leftOperand % rightOperand;

            // When the first operand is negative
            // and second positive or vice versa
            // C# tends to return the result with opposite sign
            // than most calculators, lets fix that behavior
            var isLeftNegative = Comparer<T>.Default.Compare(leftOperand, default) < 0;
            var isRightNegative = Comparer<T>.Default.Compare(rightOperand, default) < 0;

            if (isLeftNegative && !isRightNegative || !isLeftNegative && isRightNegative) {
                return -result;
            }
            return result;
        }

        /// <summary>
        /// Finds the factorial of a specified number. Number has to be non negative 
        /// </summary>
        /// <param name="n"> Integer. </param>
        /// <returns>
        /// The factorial of <paramref name="n"></paramref>.
        /// </returns>
        /// <exception cref="ArgumentException"> Thrown when <paramref name="n"></paramref> is negative.</exception>
        public static int Factorial(int n) 
        {
            if (n < 0) throw new ArgumentException();
            if (n == 0) return 1;


            int result = n;
            for (int i = n - 1; i > 0; i--) {
                checked {
                    result *= i;
                }
            }
            return result;
        }


        /// <summary>
        /// Raises number to specified power. Exponent has to be non negative.
        /// </summary>
        /// <param name="b"> Base. </param>
        /// <param name="n"> Exponent. </param>
        /// <returns>
        /// <paramref name="n"></paramref>th power of <paramref name="b"></paramref>.
        /// </returns>
        /// <exception cref="ArgumentException"> Thrown when <paramref name="n"></paramref> is negative.</exception>
        public static T Pow<T>(T b, int n) where T : INumber<T> 
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds the specified root of a number. Radicand has to be non negative,
        /// </summary>
        /// <param name="n"> Index. </param>
        /// <param name="x"> Radicand. </param>
        /// <returns>
        /// <paramref name="n"></paramref>th root of <paramref name="x"></paramref>.
        /// </returns>
        /// <exception cref="ArgumentException"> Thrown when <paramref name="x"></paramref> is negative.</exception>
        public static T Root<T>(T x, T n) where T : INumber<T> 
        {
            throw new NotImplementedException();
        }

        private static bool IsFinite<T>(IEnumerable<T> numbers) where T : INumber<T> {
            return !numbers.Any(number => 
                                number.Equals(double.NegativeInfinity) || number.Equals(float.NegativeInfinity) ||
                                number.Equals(double.PositiveInfinity) || number.Equals(float.PositiveInfinity) ||
                                number.Equals(double.NaN) || number.Equals(float.NaN));
        }
    }
}