using Math = MathLib.Math;

namespace MathLibUnitTests
{
    /// <summary>
    /// Unit tests for MathLib Subtract function.
    /// </summary>
    public class MathLibSubtractTests
    {
        /// <summary>
        /// List of decimal test inputs that return difference.
        /// </summary>
        public static IEnumerable<object[]> DecimalValues => new List<object[]>
        {
            new object[] { 0m, 0m, 0m },
            new object[] { 2.5m, 0m, 2.5m },
            new object[] { 0m, 2.1m, -2.1m },
            new object[] { 0m, -2.1m, 2.1m },
            new object[] { 10_000.2m, 20_000.4m, -10_000.2m },
            new object[] { -10_000.2m, -20_000.2m, 10_000.0m },
            new object[] { 10_000.4m, -20_000.6m, 30_001.0m },
            new object[] { -10_000.4m, 20_000.2m, -30_000.6m },
            new object[] { 0.123_456_789m, -0.987_654_321m, 1.111_111_11m },
            new object[] { 0.123_456_789m, 0.987_654_321m, -0.864_197_532m },
            new object[] { -0.123_456_789m, -0.987_654_321m, 0.864_197_532m },
            new object[] { -0.123_456_789m, 0.987_654_321m, -1.111_111_11m },
            new object[] { Constants.DECIMAL_MIN_VALUE, -1m, Constants.DECIMAL_MIN_VALUE + 1m },
            new object[] { Constants.DECIMAL_MAX_VALUE, 1m, Constants.DECIMAL_MAX_VALUE - 1m }
        };

        /// <summary>
        /// List of decimal test inputs that should throw OverflowException.
        /// </summary>
        public static IEnumerable<object[]> DecimalEdgeValues => new List<object[]>
        {
            new object[] { Constants.DECIMAL_MAX_VALUE, -1m },
            new object[] { Constants.DECIMAL_MIN_VALUE, 1m }
        };

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(2, 0, 2)]
        [InlineData(0, 2, -2)]
        [InlineData(1, 2, -1)]
        [InlineData(-1, -2, 1)]
        [InlineData(1, -2, 3)]
        [InlineData(-1, 2, -3)]
        [InlineData(10_000, 20_000, -10_000)]
        [InlineData(-10_000, -20_000, 10_000)]
        [InlineData(10_000, -20_000, 30_000)]
        [InlineData(-10_000, 20_000, -30_000)]
        [InlineData(Int32.MaxValue, 1, Int32.MaxValue - 1)]
        [InlineData(Int32.MinValue, -1, Int32.MinValue + 1)]
        public void Subtract_Int32Operands_ReturnsDifference(Int32 leftOperand, Int32 rightOperand, Int32 expectedResult)
        {
            Int32 result = Math.Subtract(leftOperand, rightOperand);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(Int32.MaxValue, -1)]
        [InlineData(Int32.MinValue, 1)]
        public void Subtract_Int32Operands_ThrowsOverflowException(Int32 leftOperand, Int32 rightOperand)
        {
            Assert.Throws<OverflowException>(() => Math.Subtract(leftOperand, rightOperand));
        }

        [Theory]
        [InlineData(0u, 0u, 0u)]
        [InlineData(2u, 0u, 2u)]
        [InlineData(2u, 1u, 1u)]
        [InlineData(20_000u, 10_000u, 10_000u)]
        public void Subtract_UInt32Operands_ReturnsDifference(UInt32 leftOperand, UInt32 rightOperand, UInt32 expectedResult)
        {
            UInt32 result = Math.Subtract(leftOperand, rightOperand);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(0u, 2u)]
        [InlineData(1u, 2u)]
        [InlineData(10_000u, 20_000u)]
        [InlineData(UInt32.MinValue, 1u)]
        public void Subtract_UInt32Operands_ThrowsOverflowException(UInt32 leftOperand, UInt32 rightOperand)
        {
            Assert.Throws<OverflowException>(() => Math.Subtract(leftOperand, rightOperand));
        }

        [Theory]
        [InlineData(0f, 0f, 0f)]
        [InlineData(2.5f, 0f, 2.5f)]
        [InlineData(0f, 2.1f, -2.1f)]
        [InlineData(0f, -2.1f, 2.1f)]
        [InlineData(10_000.2f, 20_000.4f, -10_000.2f)]
        [InlineData(-10_000.2f, -20_000.2f, 10_000.0f)]
        [InlineData(10_000.4f, -20_000.6f, 30_001.0f)]
        [InlineData(-10_000.4f, 20_000.2f, -30_000.6f)]
        [InlineData(0.123_456_789f, -0.987_654_321f, 1.111_111_11f)]
        [InlineData(0.123_456_789f, 0.987_654_321f, -0.864_197_532f)]
        [InlineData(-0.123_456_789f, -0.987_654_321f, 0.864_197_532f)]
        [InlineData(-0.123_456_789f, 0.987_654_321f, -1.111_111_11f)]
        [InlineData(Single.MinValue, -1f, Single.MinValue + 1f)]
        [InlineData(Single.MaxValue, 1f, Single.MaxValue - 1f)]
        public void Subtract_SingleOperands_ReturnsDifference(Single leftOperand, Single rightOperand, Single expectedResult)
        {
            Single result = Math.Subtract(leftOperand, rightOperand);

            Assert.Equal(expectedResult, result, Constants.EPSILON);
        }

        [Theory]
        [InlineData(Single.MinValue, 1f)]
        [InlineData(Single.MaxValue, -1f)]
        public void Subtract_SingleOperands_ThrowsOverflowException(Single leftOperand, Single rightOperand)
        {
            Assert.Throws<OverflowException>(() => Math.Add(leftOperand, rightOperand));
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
        public void Subtract_SingleOperands_ThrowsNotFiniteNumberException(Single leftOperand, Single rightOperand)
        {
            Assert.Throws<NotFiniteNumberException>(() => Math.Add(leftOperand, rightOperand));
        }

        [Theory]
        [InlineData(0d, 0d, 0d)]
        [InlineData(2.5d, 0d, 2.5d)]
        [InlineData(0d, 2.1d, -2.1d)]
        [InlineData(0d, -2.1d, 2.1d)]
        [InlineData(10_000.2d, 20_000.4d, -10_000.2d)]
        [InlineData(-10_000.2d, -20_000.2d, 10_000.0d)]
        [InlineData(10_000.4d, -20_000.6d, 30_001.0d)]
        [InlineData(-10_000.4d, 20_000.2d, -30_000.6d)]
        [InlineData(0.123_456_789d, -0.987_654_321d, 1.111_111_11d)]
        [InlineData(0.123_456_789d, 0.987_654_321d, -0.864_197_532d)]
        [InlineData(-0.123_456_789d, -0.987_654_321d, 0.864_197_532d)]
        [InlineData(-0.123_456_789d, 0.987_654_321d, -1.111_111_11d)]
        [InlineData(Double.MinValue, -1d, Double.MinValue + 1d)]
        [InlineData(Double.MaxValue, 1d, Double.MaxValue - 1d)]
        public void Subtract_DoubleOperands_ReturnsDifference(Double leftOperand, Double rightOperand, Double expectedResult)
        {
            Double result = Math.Subtract(leftOperand, rightOperand);

            Assert.Equal(expectedResult, result, Constants.PRECISION);
        }

        [Theory]
        [InlineData(Double.MinValue, 1d)]
        [InlineData(Double.MaxValue, -1d)]
        public void Subtract_DoubleOperands_ThrowsOverflowException(Double leftOperand, Double rightOperand)
        {
            Assert.Throws<OverflowException>(() => Math.Add(leftOperand, rightOperand));
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
        public void Subtract_DoubleOperands_ThrowsNotFiniteNumberException(Double leftOperand, Double rightOperand)
        {
            Assert.Throws<NotFiniteNumberException>(() => Math.Add(leftOperand, rightOperand));
        }

        [Theory]
        [MemberData(nameof(DecimalValues))]
        public void Subtract_DecimalOperands_ReturnsDifference(Decimal leftOperand, Decimal rightOperand, Decimal expectedResult)
        {
            Decimal result = Math.Subtract(leftOperand, rightOperand);

            Assert.Equal(expectedResult, result, Constants.PRECISION);
        }

        [Theory]
        [MemberData(nameof(DecimalEdgeValues))]
        public void Subtract_DecimalOperands_ThrowsOverflowException(Decimal leftOperand, Decimal rightOperand)
        {
            Assert.Throws<OverflowException>(() => Math.Subtract(leftOperand, rightOperand));
        }
    }
}
