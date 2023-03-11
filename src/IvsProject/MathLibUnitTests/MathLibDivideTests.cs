using Math = MathLib.Math;

namespace MathLibUnitTests
{
    /// <summary>
    /// Unit tests for MathLib Divide function.
    /// </summary>
    public class MathLibDivideTests
    {
        /// <summary>
        /// List of decimal test inputs that return quotient.
        /// </summary>
        public static IEnumerable<object[]> DecimalValues => new List<object[]>
        {
            new object[] { 0m, 2m, 0m },
            new object[] { 2m, 1m, 2m },
            new object[] { 1m, 2m, 0.5m },
            new object[] { -1m, -2m, 0.5m },
            new object[] { 1m, -2m, -0.5m },
            new object[] { -1m, 2m, -0.5m },
            new object[] { 25m, 5m, 5m },
            new object[] { -25m, -5m, 5m },
            new object[] { 25m, -5m, -5m },
            new object[] { -25m, 5m, -5m },
            new object[] { 5.625m, 2.25m, 2.5m },
            new object[] { -5.625m, -2.25m, 2.5m },
            new object[] { 5.625m, -2.25m, -2.5m },
            new object[] { -5.625m, 2.25m, -2.5m }
        };

        /// <summary>
        /// List of decimal test inputs that should throw OverflowException.
        /// </summary>
        public static IEnumerable<object[]> DecimalEdgeValues => new List<object[]>
        {
            new object[] { Constants.DECIMAL_MIN_VALUE, 0.5m },
            new object[] { Constants.DECIMAL_MIN_VALUE, -0.5m },
            new object[] { Constants.DECIMAL_MAX_VALUE, 0.5m },
            new object[] { Constants.DECIMAL_MAX_VALUE, -0.5m }
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
        [InlineData(2, 1, 2)]
        [InlineData(1, 2, 0)]
        [InlineData(-1, -2, 0)]
        [InlineData(1, -2, 0)]
        [InlineData(-1, 2, 0)]
        [InlineData(25, 5, 5)]
        [InlineData(-25, -5, 5)]
        [InlineData(25, -5, -5)]
        [InlineData(-25, 5, -5)]
        [InlineData(5, 2, 2)]
        [InlineData(-5, -2, 2)]
        [InlineData(5, -2, -2)]
        [InlineData(-5, 2, -2)]
        public void Divide_Int32Operands_ReturnsQuotient(Int32 leftOperand, Int32 rightOperand, Int32 expectedResult)
        {
            Int32 result = Math.Divide(leftOperand, rightOperand);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(Int32.MinValue, -1)]
        public void Divide_Int32Operands_ThrowsOverflowException(Int32 leftOperand, Int32 rightOperand)
        {
            Assert.Throws<OverflowException>(() => Math.Divide(leftOperand, rightOperand));
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 0)]
        [InlineData(-1, 0)]
        public void Divide_Int32Operands_ThrowsDivideByZeroException(Int32 leftOperand, Int32 rightOperand)
        {
            Assert.Throws<DivideByZeroException>(() => Math.Divide(leftOperand, rightOperand));
        }

        [Theory]
        [InlineData(0u, 2u, 0u)]
        [InlineData(2u, 1u, 2u)]
        [InlineData(1u, 2u, 0u)]
        [InlineData(25u, 5u, 5u)]
        [InlineData(5u, 2u, 2u)]
        public void Divide_UInt32Operands_ReturnsQuotient(UInt32 leftOperand, UInt32 rightOperand, UInt32 expectedResult)
        {
            UInt32 result = Math.Divide(leftOperand, rightOperand);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(0u, 0u)]
        [InlineData(1u, 0u)]
        public void Divide_UInt32Operands_ThrowsDivideByZeroException(UInt32 leftOperand, UInt32 rightOperand)
        {
            Assert.Throws<DivideByZeroException>(() => Math.Divide(leftOperand, rightOperand));
        }

        [Theory]
        [InlineData(0f, 2f, 0f)]
        [InlineData(2f, 1f, 2f)]
        [InlineData(1f, 2f, 0.5f)]
        [InlineData(-1f, -2f, 0.5f)]
        [InlineData(1f, -2f, -0.5f)]
        [InlineData(-1f, 2f, -0.5f)]
        [InlineData(25f, 5f, 5f)]
        [InlineData(-25f, -5f, 5f)]
        [InlineData(25f, -5f, -5f)]
        [InlineData(-25f, 5f, -5f)]
        [InlineData(5.625f, 2.25f, 2.5f)]
        [InlineData(-5.625f, -2.25f, 2.5f)]
        [InlineData(5.625f, -2.25f, -2.5f)]
        [InlineData(-5.625f, 2.25f, -2.5f)]
        public void Divide_SingleOperands_ReturnsQuotient(Single leftOperand, Single rightOperand, Single expectedResult)
        {
            Single result = Math.Divide(leftOperand, rightOperand);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(Single.MinValue, 0.5f)]
        [InlineData(Single.MinValue, -0.5f)]
        [InlineData(Single.MaxValue, 0.5f)]
        [InlineData(Single.MaxValue, -0.5f)]
        public void Divide_SingleOperands_ThrowsOverflowException(Single leftOperand, Single rightOperand)
        {
            Assert.Throws<OverflowException>(() => Math.Divide(leftOperand, rightOperand));
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
        public void Divide_SingleOperands_ThrowsNotFiniteNumberException(Single leftOperand, Single rightOperand)
        {
            Assert.Throws<NotFiniteNumberException>(() => Math.Divide(leftOperand, rightOperand));
        }

        [Theory]
        [InlineData(0f, 0f)]
        [InlineData(1.5f, 0f)]
        [InlineData(-1.5f, 0f)]
        public void Divide_SingleOperands_ThrowsDivideByZeroException(Single leftOperand, Single rightOperand)
        {
            Assert.Throws<DivideByZeroException>(() => Math.Divide(leftOperand, rightOperand));
        }

        [Theory]
        [InlineData(0, 2, 0)]
        [InlineData(2, 1, 2)]
        [InlineData(1, 2, 0.5)]
        [InlineData(-1, -2, 0.5)]
        [InlineData(1, -2, -0.5)]
        [InlineData(-1, 2, -0.5)]
        [InlineData(25, 5, 5)]
        [InlineData(-25, -5, 5)]
        [InlineData(25, -5, -5)]
        [InlineData(-25, 5, -5)]
        [InlineData(5.625, 2.25, 2.5)]
        [InlineData(-5.625, -2.25, 2.5)]
        [InlineData(5.625, -2.25, -2.5)]
        [InlineData(-5.625, 2.25, -2.5)]
        public void Divide_DoubleOperands_ReturnsQuotient(Double leftOperand, Double rightOperand, Double expectedResult)
        {
            Double result = Math.Divide(leftOperand, rightOperand);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(Double.MinValue, 0.5)]
        [InlineData(Double.MinValue, -0.5)]
        [InlineData(Double.MaxValue, 0.5)]
        [InlineData(Double.MaxValue, -0.5)]
        public void Divide_DoubleOperands_ThrowsOverflowException(Double leftOperand, Double rightOperand)
        {
            Assert.Throws<OverflowException>(() => Math.Divide(leftOperand, rightOperand));
        }

        [Theory]
        [InlineData(Double.NaN, Double.NaN)]
        [InlineData(Double.PositiveInfinity, Double.PositiveInfinity)]
        [InlineData(Double.NegativeInfinity, Double.NegativeInfinity)]
        [InlineData(Double.NaN, Double.PositiveInfinity)]
        [InlineData(Double.NaN, Double.NegativeInfinity)]
        [InlineData(Double.PositiveInfinity, Double.NegativeInfinity)]
        [InlineData(Double.NaN, 1)]
        [InlineData(Double.PositiveInfinity, 1)]
        [InlineData(Double.NegativeInfinity, 1)]
        public void Divide_DoubleOperands_ThrowsNotFiniteNumberException(Double leftOperand, Double rightOperand)
        {
            Assert.Throws<NotFiniteNumberException>(() => Math.Divide(leftOperand, rightOperand));
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1.5, 0)]
        [InlineData(-1.5, 0)]
        public void Divide_DoubleOperands_ThrowsDivideByZeroException(Double leftOperand, Double rightOperand)
        {
            Assert.Throws<DivideByZeroException>(() => Math.Divide(leftOperand, rightOperand));
        }

        [Theory]
        [MemberData(nameof(DecimalValues))]
        public void Divide_DecimalOperands_ReturnsQuotient(Decimal leftOperand, Decimal rightOperand, Decimal expectedResult)
        {
            Decimal result = Math.Divide(leftOperand, rightOperand);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [MemberData(nameof(DecimalEdgeValues))]
        public void Divide_DecimalOperands_OverflowException(Decimal leftOperand, Decimal rightOperand)
        {
            Assert.Throws<OverflowException>(() => Math.Divide(leftOperand, rightOperand));
        }

        [Theory]
        [MemberData(nameof(DecimalZeroValues))]
        public void Divide_DecimalOperands_ThrowsDivideByZeroException(Decimal leftOperand, Decimal rightOperand)
        {
            Assert.Throws<DivideByZeroException>(() => Math.Divide(leftOperand, rightOperand));
        }
    }
}
