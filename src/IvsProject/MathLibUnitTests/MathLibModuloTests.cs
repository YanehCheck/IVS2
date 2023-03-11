using Math = MathLib.Math;

namespace MathLibUnitTests
{
    /// <summary>
    /// Unit tests for MathLib Modulo function.
    /// </summary>
    public class MathLibModuloTests
    {
        /// <summary>
        /// List of decimal test inputs that return remainder.
        /// </summary>
        public static IEnumerable<object[]> DecimalValues => new List<object[]>
        {
            new object[] { 0d, 2d, 0d },
            new object[] { 2d, 1d, 0d },
            new object[] { 1d, 2d, 1d },
            new object[] { -1d, -2d, -1d },
            new object[] { 1d, -2d, -1d },
            new object[] { -1d, 2d, 1d },
            new object[] { 25d, 5d, 0d },
            new object[] { -25d, -5d, 0d },
            new object[] { 25d, -5d, 0d },
            new object[] { -25d, 5d, 0d },
            new object[] { 5.625d, 2.25d, 1.125d },
            new object[] { -5.625d, -2.25d, -1.125d },
            new object[] { 5.625d, -2.25d, -1.125d },
            new object[] { -5.625d, 2.25d, 1.125d }
        };

        /// <summary>
        /// List of decimal test inputs that should throw DivideByZeroException.
        /// </summary>
        public static IEnumerable<object[]> DecimalZeroValues => new List<object[]>
        {
            new object[] { 0m, 0m },
            new object[] { 1.5m, 0m },
            new object[] { -1.5m, 0m }
        };

        [Theory]
        [InlineData(0, 2, 0)]
        [InlineData(2, 1, 0)]
        [InlineData(1, 2, 1)]
        [InlineData(-1, -2, -1)]
        [InlineData(1, -2, -1)]
        [InlineData(-1, 2, 1)]
        [InlineData(25, 5, 0)]
        [InlineData(-25, -5, 0)]
        [InlineData(25, -5, 0)]
        [InlineData(-25, 5, 0)]
        public void Modulo_Int32Operands_ReturnsRemainder(Int32 leftOperand, Int32 rightOperand, Int32 expectedResult)
        {
            Int32 result = Math.Modulo(leftOperand, rightOperand);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(Int32.MinValue, -1)]
        public void Modulo_Int32Operands_ThrowsOverflowException(Int32 leftOperand, Int32 rightOperand)
        {
            Assert.Throws<OverflowException>(() => Math.Modulo(leftOperand, rightOperand));
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 0)]
        [InlineData(-1, 0)]
        public void Modulo_Int32Operands_ThrowsDivideByZeroException(Int32 leftOperand, Int32 rightOperand)
        {
            Assert.Throws<DivideByZeroException>(() => Math.Modulo(leftOperand, rightOperand));
        }

        [Theory]
        [InlineData(0u, 2u, 0u)]
        [InlineData(2u, 1u, 0u)]
        [InlineData(1u, 2u, 1u)]
        [InlineData(25u, 5u, 0u)]
        public void Modulo_UInt32Operands_ReturnsRemainder(UInt32 leftOperand, UInt32 rightOperand, UInt32 expectedResult)
        {
            UInt32 result = Math.Modulo(leftOperand, rightOperand);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(0u, 0u)]
        [InlineData(1u, 0u)]
        public void Modulo_UInt32Operands_ThrowsDivideByZeroException(UInt32 leftOperand, UInt32 rightOperand)
        {
            Assert.Throws<DivideByZeroException>(() => Math.Modulo(leftOperand, rightOperand));
        }

        [Theory]
        [InlineData(0f, 2f, 0f)]
        [InlineData(2f, 1f, 0f)]
        [InlineData(1f, 2f, 1f)]
        [InlineData(-1f, -2f, -1f)]
        [InlineData(1f, -2f, -1f)]
        [InlineData(-1f, 2f, 1f)]
        [InlineData(25f, 5f, 0f)]
        [InlineData(-25f, -5f, 0f)]
        [InlineData(25f, -5f, 0f)]
        [InlineData(-25f, 5f, 0f)]
        [InlineData(5.625f, 2.25f, 1.125f)]
        [InlineData(-5.625f, -2.25f, -1.125f)]
        [InlineData(5.625f, -2.25f, -1.125f)]
        [InlineData(-5.625f, 2.25f, 1.125f)]
        public void Modulo_SingleOperands_ReturnsRemainder(Single leftOperand, Single rightOperand, Single expectedResult)
        {
            Single result = Math.Modulo(leftOperand, rightOperand);

            Assert.Equal(expectedResult, result, Constants.EPSILON);
        }

        [Theory]
        [InlineData(Single.NaN, Single.NaN)]
        [InlineData(Single.PositiveInfinity, Single.PositiveInfinity)]
        [InlineData(Single.NegativeInfinity, Single.NegativeInfinity)]
        [InlineData(Single.NaN, Single.PositiveInfinity)]
        [InlineData(Single.NaN, Single.NegativeInfinity)]
        [InlineData(Single.PositiveInfinity, Single.NegativeInfinity)]
        [InlineData(Single.NaN, 1f)]
        [InlineData(Single.PositiveInfinity, 1f)]
        [InlineData(Single.NegativeInfinity, 1f)]
        public void Modulo_SingleOperands_ThrowsNotFiniteNumberException(Single leftOperand, Single rightOperand)
        {
            Assert.Throws<NotFiniteNumberException>(() => Math.Modulo(leftOperand, rightOperand));
        }

        [Theory]
        [InlineData(0f, 0f)]
        [InlineData(1.5f, 0f)]
        [InlineData(-1.5f, 0f)]
        public void Modulo_SingleOperands_ThrowsDivideByZeroException(Single leftOperand, Single rightOperand)
        {
            Assert.Throws<DivideByZeroException>(() => Math.Modulo(leftOperand, rightOperand));
        }

        [Theory]
        [InlineData(0d, 2d, 0d)]
        [InlineData(2d, 1d, 0d)]
        [InlineData(1d, 2d, 1d)]
        [InlineData(-1d, -2d, -1d)]
        [InlineData(1d, -2d, -1d)]
        [InlineData(-1d, 2d, 1d)]
        [InlineData(25d, 5d, 0d)]
        [InlineData(-25d, -5d, 0d)]
        [InlineData(25d, -5d, 0d)]
        [InlineData(-25d, 5d, 0d)]
        [InlineData(5.625d, 2.25d, 1.125d)]
        [InlineData(-5.625d, -2.25d, -1.125d)]
        [InlineData(5.625d, -2.25d, -1.125d)]
        [InlineData(-5.625d, 2.25d, 1.125d)]
        public void Modulo_DoubleOperands_ReturnsRemainder(Double leftOperand, Double rightOperand, Double expectedResult)
        {
            Double result = Math.Modulo(leftOperand, rightOperand);

            Assert.Equal(expectedResult, result, Constants.PRECISION);
        }

        [Theory]
        [InlineData(Double.NaN, Double.NaN)]
        [InlineData(Double.PositiveInfinity, Double.PositiveInfinity)]
        [InlineData(Double.NegativeInfinity, Double.NegativeInfinity)]
        [InlineData(Double.NaN, Double.PositiveInfinity)]
        [InlineData(Double.NaN, Double.NegativeInfinity)]
        [InlineData(Double.PositiveInfinity, Double.NegativeInfinity)]
        [InlineData(Double.NaN, 1d)]
        [InlineData(Double.PositiveInfinity, 1d)]
        [InlineData(Double.NegativeInfinity, 1d)]
        public void Modulo_DoubleOperands_ThrowsNotFiniteNumberException(Double leftOperand, Double rightOperand)
        {
            Assert.Throws<NotFiniteNumberException>(() => Math.Modulo(leftOperand, rightOperand));
        }

        [Theory]
        [InlineData(0d, 0d)]
        [InlineData(1.5d, 0d)]
        [InlineData(-1.5d, 0d)]
        public void Modulo_DoubleOperands_ThrowsDivideByZeroException(Double leftOperand, Double rightOperand)
        {
            Assert.Throws<DivideByZeroException>(() => Math.Modulo(leftOperand, rightOperand));
        }

        [Theory]
        [MemberData(nameof(DecimalValues))]
        public void Modulo_DecimalOperands_ReturnsQuotient(Decimal leftOperand, Decimal rightOperand, Decimal expectedResult)
        {
            Decimal result = Math.Modulo(leftOperand, rightOperand);

            Assert.Equal(expectedResult, result, Constants.PRECISION);
        }

        [Theory]
        [MemberData(nameof(DecimalZeroValues))]
        public void Modulo_DecimalOperands_ThrowsDivideByZeroException(Decimal leftOperand, Decimal rightOperand)
        {
            Assert.Throws<DivideByZeroException>(() => Math.Modulo(leftOperand, rightOperand));
        }
    }
}
