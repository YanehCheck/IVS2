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
        /// <exception cref="NotFiniteNumberException"> Thrown when <paramref name="rightOperand"></paramref> or <paramref name="leftOperand"></paramref> is not a finite number.</exception>
        /// <exception cref="OverflowException"></exception> 
        public static T Add<T>(T leftOperand, T rightOperand) where T : INumber<T> 
        {
            if(!IsFinite(new[] { leftOperand, rightOperand }))
                throw new NotFiniteNumberException();

            T result;
            checked 
            {
                result = leftOperand + rightOperand;
            }

            if(!IsFinite(new[] { result })) 
            {
                throw new OverflowException();
            }
            return result;
        }

        /// <summary>
        /// Subtracts two numbers.
        /// </summary>
        /// <param name="leftOperand"> Minuend. </param>
        /// <param name="rightOperand"> Subtrahend. </param>
        /// <returns>
        /// The difference after subtracting <paramref name="rightOperand"></paramref> from <paramref name="leftOperand"></paramref>.
        /// </returns>
        /// <exception cref="NotFiniteNumberException"> Thrown when <paramref name="rightOperand"></paramref> or <paramref name="leftOperand"></paramref> is not a finite number.</exception>
        /// <exception cref="OverflowException"></exception> 
        public static T Subtract<T>(T leftOperand, T rightOperand) where T : INumber<T> 
        {
            if(!IsFinite(new[] { leftOperand, rightOperand }))
                throw new NotFiniteNumberException();

            T result;
            checked 
            {
                result = leftOperand - rightOperand;
            }

            if(!IsFinite(new[] { result })) 
            {
                throw new OverflowException();
            }
            return result;
        }

        /// <summary>
        /// Multiplies two numbers.
        /// </summary>
        /// <param name="leftOperand"> Multiplier. </param>
        /// <param name="rightOperand"> Multiplicand. </param>
        /// <returns>
        /// The product after multiplying <paramref name="leftOperand"></paramref> with <paramref name="rightOperand"></paramref>.
        /// </returns>
        /// <exception cref="NotFiniteNumberException"> Thrown when <paramref name="rightOperand"></paramref> or <paramref name="leftOperand"></paramref> is not a finite number.</exception>
        /// <exception cref="OverflowException"></exception> Thrown even if the calculation would result in non-finite number.
        public static T Multiply<T>(T leftOperand, T rightOperand) where T : INumber<T> 
        {
            if(!IsFinite(new[] { leftOperand, rightOperand }))
                throw new NotFiniteNumberException();

            T result;
            checked 
            {
                result = leftOperand * rightOperand;
            }

            if(!IsFinite(new[] { result })) 
            {
                throw new OverflowException();
            }
            return result;
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
        /// <exception cref="NotFiniteNumberException"> Thrown when <paramref name="rightOperand"></paramref> or <paramref name="leftOperand"></paramref> is not a finite number.</exception>
        /// <exception cref="OverflowException"></exception> Thrown even if the calculation would result in non-finite number.
        public static T Divide<T>(T leftOperand, T rightOperand) where T : INumber<T> 
        {
            if(!IsFinite(new[] { leftOperand, rightOperand })) 
                throw new NotFiniteNumberException();

            // default(T) is zero in any numeric type
            if(rightOperand == default(T)) 
            {
                throw new DivideByZeroException();
            }

            T result;
            checked 
            {
                result = leftOperand / rightOperand;
            }

            if (!IsFinite(new []{ result })) 
            {
                throw new OverflowException();
            }
            return result;
        }

        /// <summary>
        /// Finds the remainder after division of two numbers.
        /// </summary>
        /// <param name="leftOperand"> Dividend. </param>
        /// <param name="rightOperand"> Divisor. </param>
        /// <returns>
        /// The remainder after dividing <paramref name="leftOperand"></paramref> by <paramref name="rightOperand"></paramref>.
        /// </returns>
        /// <exception cref="DivideByZeroException"> Thrown when <paramref name="rightOperand"></paramref> is zero.</exception>
        /// <exception cref="NotFiniteNumberException"> Thrown when <paramref name="rightOperand"></paramref> or <paramref name="leftOperand"></paramref> is not a finite number.</exception>
        public static T Modulo<T>(T leftOperand, T rightOperand) where T : INumber<T> 
        {
            if (!IsFinite(new[] { leftOperand, rightOperand })) throw new NotFiniteNumberException();

            // default(T) is zero in any numeric type
            if (rightOperand == default(T)) 
            {
                throw new DivideByZeroException();
            }

            var result = leftOperand % rightOperand;

            // When the first operand is negative
            // and second positive or vice versa
            // C# tends to return the result with opposite sign
            // than most calculators, lets fix that behavior
            var isLeftNegative = Comparer<T>.Default.Compare(leftOperand, default) < 0;
            var isRightNegative = Comparer<T>.Default.Compare(rightOperand, default) < 0;

            if (isLeftNegative && !isRightNegative || !isLeftNegative && isRightNegative) 
            {
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
        /// <exception cref="OverflowException"></exception> 
        public static int Factorial(int n) 
        {
            if (n < 0) throw new ArgumentException();
            if (n == 0) return 1;


            int result = n;
            for (int i = n - 1; i > 0; i--) 
            {
                checked 
                {
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
        /// <exception cref="NotFiniteNumberException"> Thrown when <paramref name="b"></paramref> is not a finite number.</exception>
        /// <exception cref="OverflowException"></exception>
        public static T Pow<T>(T b, int n) where T : INumber<T> 
        {
            if(!IsFinite(new[] { b }))
                throw new NotFiniteNumberException();

            if (n < 0) 
            {
                throw new ArgumentException();
            }
            if (n == 0) {
                return (T) Convert.ChangeType(1, typeof(T));
            }
            if (b == default(T)) 
            {
                return default;
            }

            T result = b;
            for (int i = 1; i < n; i++) 
            {
                checked 
                {
                    result *= b;
                }
            }

            if(!IsFinite(new[] { result })) {
                throw new OverflowException();
            }
            return result;
        }

        /// <summary>
        /// Finds the specified root of a number. Radicand has to be non negative,
        /// </summary>
        /// <param name="n"> Index. </param>
        /// <param name="x"> Radicand. </param>
        /// <returns>
        /// <paramref name="n"></paramref>th root of <paramref name="x"></paramref>.
        /// </returns>
        /// <exception cref="ArgumentException"> Thrown when the calculation would result in complex numbers.</exception>
        /// <exception cref="DivideByZeroException"> Thrown when <paramref name="n"></paramref> is zero.</exception>
        /// <exception cref="NotFiniteNumberException"></exception>
        public static T Root<T>(T n, T x) where T : INumber<T> 
        {
            var isIndexNegative = Comparer<T>.Default.Compare(n, default) < 0;
            var isRadicandNegative = Comparer<T>.Default.Compare(x, default) < 0;

            if(!IsFinite(new[] { n, x }) || isIndexNegative && x == default)
                throw new NotFiniteNumberException();
            if(n == default)
                throw new DivideByZeroException();

            var nDouble = (double) Convert.ChangeType(n, typeof(double));
            var xDouble = (double) Convert.ChangeType(x, typeof(double));
            if (nDouble % 2 == 0 && isRadicandNegative)
            {
                throw new ArgumentException();
            }
            var result = System.Math.Pow(xDouble, 1 / nDouble);
            var resultGeneric = (T) Convert.ChangeType(result, typeof(T));
            if(!IsFinite(new[] { resultGeneric })) 
            {
                throw new OverflowException();
            }

            return resultGeneric;
        }

        private static bool IsFinite<T>(IEnumerable<T> numbers) where T : INumber<T> 
        {
            return !numbers.Any(number => 
                                number.Equals(double.NegativeInfinity) || number.Equals(float.NegativeInfinity) ||
                                number.Equals(double.PositiveInfinity) || number.Equals(float.PositiveInfinity) ||
                                number.Equals(double.NaN) || number.Equals(float.NaN));
        }
    }
}