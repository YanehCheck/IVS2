using Math = MathLib.Math;

namespace MathLibUnitTests
{
    /// <summary>
    /// Unit tests for MathLib Multiply function.
    /// </summary>
    public class MathLibMultiplyTests
    {
        /// <summary>
        /// List of decimal test inputs that return product.
        /// </summary>
        public static IEnumerable<object[]> DecimalValues => new List<object[]>
        {
            new object[] { 0m, -0m, 0m },
            new object[] { 2.5m, 0m, 0m },
            new object[] { 0m, 2.1m, 0m },
            new object[] { 100.2m, 200.4m, 20_080.08m },
            new object[] { -100.2m, -200.4m, 20_080.08m },
            new object[] { 100.2m, -200.4m, -20_080.08m },
            new object[] { -100.2m, 200.4m, -20_080.08m },
            new object[] { 0.123_456m, -0.987_654m, -0.121_931_812_224m },
            new object[] { 0.123_456m, 0.987_654m, 0.121_931_812_224m }
        };

        /// <summary>
        /// List of decimal test inputs that should throw OverflowException.
        /// </summary>
        public static IEnumerable<object[]> DecimalEdgeValues => new List<object[]>
        {
            new object[] { Constants.DECIMAL_MIN_VALUE, 2m },
            new object[] { Constants.DECIMAL_MIN_VALUE, -2m },
            new object[] { Constants.DECIMAL_MAX_VALUE, 2m },
            new object[] { Constants.DECIMAL_MAX_VALUE, -2m }
        };

        [Theory]
        [InlineData(0, -0, 0)]
        [InlineData(2, 0, 0)]
        [InlineData(0, 2, 0)]
        [InlineData(1, 2, 2)]
        [InlineData(-1, -2, 2)]
        [InlineData(1, -2, -2)]
        [InlineData(-1, 2, -2)]
        [InlineData(25, 5, 125)]
        [InlineData(-25, -5, 125)]
        [InlineData(25, -5, -125)]
        [InlineData(-25, 5, -125)]
        public void Multiply_Int32Operands_ReturnsProduct(Int32 leftOperand, Int32 rightOperand, Int32 expectedResult)
        {
            Int32 result = Math.Multiply(leftOperand, rightOperand);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(Int32.MinValue, -1)]
        [InlineData(Int32.MinValue, 2)]
        [InlineData(Int32.MinValue, -2)]
        [InlineData(Int32.MaxValue, 2)]
        [InlineData(Int32.MaxValue, -2)]
        public void Multiply_Int32Operands_ThrowsOverflowException(Int32 leftOperand, Int32 rightOperand)
        {
            Assert.Throws<OverflowException>(() => Math.Multiply(leftOperand, rightOperand));
        }

        [Theory]
        [InlineData(0u, 0u, 0u)]
        [InlineData(2u, 0u, 0u)]
        [InlineData(0u, 2u, 0u)]
        [InlineData(1u, 2u, 2u)]
        [InlineData(25u, 5u, 125u)]
        public void Multiply_UInt32Operands_ReturnsProduct(UInt32 leftOperand, UInt32 rightOperand, UInt32 expectedResult)
        {
            UInt32 result = Math.Multiply(leftOperand, rightOperand);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(UInt32.MaxValue, 2u)]
        public void Multiply_UInt32Operands_ThrowsOverflowException(UInt32 leftOperand, UInt32 rightOperand)
        {
            Assert.Throws<OverflowException>(() => Math.Multiply(leftOperand, rightOperand));
        }

        [Theory]
        [InlineData(0f, -0f, 0f)]
        [InlineData(2.5f, 0f, 0f)]
        [InlineData(0f, 2.1f, 0f)]
        [InlineData(100.2f, 200.4f, 20_080.08f)]
        [InlineData(-100.2f, -200.4f, 20_080.08f)]
        [InlineData(100.2f, -200.4f, -20_080.08f)]
        [InlineData(-100.2f, 200.4f, -20_080.08f)]
        [InlineData(0.123_4f, 0.987_6f, 0.121_869_84f)]
        [InlineData(0.123_4f, -0.987_6f, -0.121_869_84f)]
        public void Multiply_SingleOperands_ReturnsProduct(Single leftOperand, Single rightOperand, Single expectedResult)
        {
            Single result = Math.Multiply(leftOperand, rightOperand);

            Assert.Equal(expectedResult, result, Constants.EPSILON);
        }

        [Theory]
        [InlineData(Single.MinValue, 2f)]
        [InlineData(Single.MinValue, -2f)]
        [InlineData(Single.MaxValue, 2f)]
        [InlineData(Single.MaxValue, -2f)]
        public void Multiply_SingleOperands_ThrowsOverflowException(Single leftOperand, Single rightOperand)
        {
            Assert.Throws<OverflowException>(() => Math.Multiply(leftOperand, rightOperand));
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
        public void Multiply_SingleOperands_ThrowsNotFiniteNumberException(Single leftOperand, Single rightOperand)
        {
            Assert.Throws<NotFiniteNumberException>(() => Math.Multiply(leftOperand, rightOperand));
        }

        [Theory]
        [InlineData(0d, -0d, 0d)]
        [InlineData(2.5d, 0d, 0d)]
        [InlineData(0d, 2.1d, 0d)]
        [InlineData(100.2d, 200.4d, 20_080.08d)]
        [InlineData(-100.2d, -200.4d, 20_080.08d)]
        [InlineData(100.2d, -200.4d, -20_080.08d)]
        [InlineData(-100.2d, 200.4d, -20_080.08d)]
        [InlineData(0.123_4d, 0.987_6d, 0.121_869_84d)]
        [InlineData(0.123_4d, -0.987_6d, -0.121_869_84d)]
        public void Multiply_DoubleOperands_ReturnsProduct(Double leftOperand, Double rightOperand, Double expectedResult)
        {
            Double result = Math.Multiply(leftOperand, rightOperand);

            Assert.Equal(expectedResult, result, Constants.PRECISION);
        }

        [Theory]
        [InlineData(Double.MinValue, 2d)]
        [InlineData(Double.MinValue, -2d)]
        [InlineData(Double.MaxValue, 2d)]
        [InlineData(Double.MaxValue, -2d)]
        public void Multiply_DoubleOperands_ThrowsOverflowException(Double leftOperand, Double rightOperand)
        {
            Assert.Throws<OverflowException>(() => Math.Multiply(leftOperand, rightOperand));
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
        public void Multiply_DoubleOperands_ThrowsNotFiniteNumberException(Double leftOperand, Double rightOperand)
        {
            Assert.Throws<NotFiniteNumberException>(() => Math.Multiply(leftOperand, rightOperand));
        }

        [Theory]
        [MemberData(nameof(DecimalValues))]
        public void Multiply_DecimalOperands_ReturnsProduct(Decimal leftOperand, Decimal rightOperand, Decimal expectedResult)
        {
            Decimal result = Math.Multiply(leftOperand, rightOperand);

            Assert.Equal(expectedResult, result, Constants.PRECISION);
        }

        [Theory]
        [MemberData(nameof(DecimalEdgeValues))]
        public void Multiply_DecimalOperands_ThrowsOverflowException(Decimal leftOperand, Decimal rightOperand)
        {
            Assert.Throws<OverflowException>(() => Math.Multiply(leftOperand, rightOperand));
        }
    }
}
