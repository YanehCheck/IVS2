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
        /// The sum of <paramref name="leftOperand">leftOperand</paramref> and <paramref name="rightOperand">rightOperand</paramref>.
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
        /// The difference after subtracting <paramref name="rightOperand">rightOperand</paramref> from <paramref name="leftOperand">leftOperand</paramref>.
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
        /// The product after multiplying <paramref name="leftOperand">leftOperand</paramref> with <paramref name="rightOperand">rightOperand</paramref>.
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
        /// The remainder after dividing <paramref name="leftOperand">leftOperand</paramref> by <paramref name="rightOperand">rightOperand</paramref>.
        /// </returns>
        /// <exception cref="DivideByZeroException"> Thrown when the <paramref name="rightOperand">rightOperand</paramref> is zero.</exception>
        public static T Modulo<T>(T leftOperand, T rightOperand) where T : INumber<T> 
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds the factorial of a specified number. Number has to be non negative 
        /// </summary>
        /// <param name="n"> Integer. </param>
        /// <returns>
        /// The factorial of <paramref name="n">n</paramref>.
        /// </returns>
        /// <exception cref="ArgumentException"> Thrown when <paramref name="n">n</paramref> is negative.</exception>
        public static int Factorial(int n) 
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Raises number to specified power. Exponent has to be non negative.
        /// </summary>
        /// <param name="b"> Base. </param>
        /// <param name="n"> Exponent. </param>
        /// <returns>
        /// <paramref name="n">n</paramref>th power of <paramref name="b">b</paramref>.
        /// </returns>
        /// <exception cref="ArgumentException"> Thrown when <paramref name="n">n</paramref> is negative.</exception>
        public static T Pow<T>(T b, int n) where T : INumber<T> {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds the specified root of a number. Radicand has to be non negative,
        /// </summary>
        /// <param name="n"> Index. </param>
        /// <param name="x"> Radicand. </param>
        /// <returns>
        /// <paramref name="n">n</paramref>th root of <paramref name="x">x</paramref>.
        /// </returns>
        /// <exception cref="ArgumentException"> Thrown when <paramref name="x">x</paramref> is negative.</exception>
        public static T Root<T>(T x, T n) where T : INumber<T> {
            throw new NotImplementedException();
        }
    }
}