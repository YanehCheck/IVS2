using Math = MathLib.Math;

namespace MathLibUnitTests
{
    /// <summary>
    /// Unit tests for MathLib Add function.
    /// </summary>
    public class MathLibAddTests 
    {
        /// <summary>
        /// List of decimal test inputs that return sum.
        /// </summary>
        public static IEnumerable<object[]> DecimalValues => new List<object[]>
        {
            new object[] { 0m, 0m, 0m},
            new object[] { 2.5m, 0m, 2.5m},
            new object[] { 0m, 2.1m, 2.1m},
            new object[] { 10_000.2m, 20_000.4m, 2.5m},
            new object[] { -10_000.2m, -20_000.2m, -30_000.0m},
            new object[] { 10_000.4m, -20_000.6m, -10000.2m},
            new object[] { -10_000.4m, 20_000.2m, 9999.8m},
            new object[] { 0.123_456_789m, 0.987_654_321m, 1.111_111_11m},
            new object[] { 0.123_456_789m, -0.987_654_321m, -0.864_197_532m}
        };

        /// <summary>
        /// List of decimal test inputs that should throw OverflowException.
        /// </summary>
        public static IEnumerable<object[]> DecimalEdgeValues => new List<object[]>
        {
            new object[] { Constants.DECIMAL_MAX_VALUE, 1m },
            new object[] { Constants.DECIMAL_MIN_VALUE, -1m }
        };

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(2, 0, 2)]
        [InlineData(0, 2, 2)]
        [InlineData(1, 2, 3)]
        [InlineData(-1, -2, -3)]
        [InlineData(1, -2, -1)]
        [InlineData(-1, 2, 1)]
        [InlineData(10_000, 20_000, 30_000)]
        [InlineData(-10_000, -20_000, -30_000)]
        [InlineData(10_000, -20_000, -10_000)]
        [InlineData(-10_000, 20_000, 10_000)]
        public void Add_Int32Addends_ReturnsSum(Int32 leftOperand, Int32 rightOperand, Int32 expectedResult)
        {
            Int32 result = Math.Add(leftOperand, rightOperand);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(Int32.MaxValue, 1)]
        [InlineData(Int32.MinValue, -1)]
        public void Add_Int32Addends_ThrowsOverflowException(Int32 leftOperand, Int32 rightOperand)
        {
            Assert.Throws<OverflowException>(() => Math.Add(leftOperand, rightOperand));
        }

        [Theory]
        [InlineData(0u, 0u, 0u)]
        [InlineData(2u, 0u, 2u)]
        [InlineData(0u, 2u, 2u)]
        [InlineData(1u, 2u, 3u)]
        [InlineData(10_000u, 20_000u, 30_000u)]
        public void Add_UInt32Addends_ReturnsSum(UInt32 leftOperand, UInt32 rightOperand, UInt32 expectedResult)
        {
            UInt32 result = Math.Add(leftOperand, rightOperand);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(UInt32.MaxValue, 1u)]
        public void Add_UInt32Addends_ThrowsOverflowException(UInt32 leftOperand, UInt32 rightOperand)
        {
            Assert.Throws<OverflowException>(() => Math.Add(leftOperand, rightOperand));
        }

        [Theory]
        [InlineData(0.0f, 0.0f, 0.0f)]
        [InlineData(2.5f, 0f, 2.5f)]
        [InlineData(0f, 2.1f, 2.1f)]
        [InlineData(10_000.2f, 20_000.4f, 30_000.6f)]
        [InlineData(-10_000.2f, -20_000.2f, -30_000.0f)]
        [InlineData(10_000.4f, -20_000.6f, -10_000.2f)]
        [InlineData(-10_000.4f, 20_000.2f, 9999.8f)]
        [InlineData(0.123_456_789f, 0.987_654_321f, 1.111_111_11f)]
        [InlineData(0.123_456_789f, -0.987_654_321f, -0.864_197_532f)]
        public void Add_SingleAddends_ReturnsSum(Single leftOperand, Single rightOperand, Single expectedResult)
        {
            Single result = Math.Add(leftOperand, rightOperand);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(Single.MinValue, -1f)]
        [InlineData(Single.MaxValue, 1f)]
        public void Add_SingleAddends_ThrowsOverflowException(Single leftOperand, Single rightOperand)
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
        public void Add_SingleAddends_ThrowsNotFiniteNumberException(Single leftOperand, Single rightOperand)
        {
            Assert.Throws<NotFiniteNumberException>(() => Math.Add(leftOperand, rightOperand));
        }

        [Theory]
        [InlineData(0.0, 0.0, 0.0)]
        [InlineData(2.5, 0.0, 2.5)]
        [InlineData(0.0, 2.1, 2.1)]
        [InlineData(10_000.2, 20_000.4, 30_000.6)]
        [InlineData(-10_000.2, -20_000.2, -30_000.0)]
        [InlineData(10_000.4, -20_000.6, -10_000.2)]
        [InlineData(-10_000.4, 20_000.2, 9999.8)]
        [InlineData(0.123_456_789, 0.987_654_321, 1.111_111_11)]
        [InlineData(0.123_456_789, -0.987_654_321, -0.864_197_532)]
        public void Add_DoubleAddends_ReturnsSum(Double leftOperand, Double rightOperand, Double expectedResult)
        {
            Double result = Math.Add(leftOperand, rightOperand);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(Double.MinValue, -1)]
        [InlineData(Double.MaxValue, 1)]
        public void Add_DoubleAddends_ThrowsOverflowException(Double leftOperand, Double rightOperand)
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
        [InlineData(Double.NaN, 1)]
        [InlineData(Double.PositiveInfinity, 1)]
        [InlineData(Double.NegativeInfinity, 1)]
        public void Add_DoubleAddends_ThrowsNotFiniteNumberException(Double leftOperand, Double rightOperand)
        {
            Assert.Throws<NotFiniteNumberException>(() => Math.Add(leftOperand, rightOperand));
        }

        [Theory]
        [MemberData(nameof(DecimalValues))]
        public void Add_DecimalAddends_ReturnsSum(Decimal leftOperand, Decimal rightOperand, Decimal expectedResult)
        {
            Decimal result = Math.Add(leftOperand, rightOperand);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [MemberData(nameof(DecimalEdgeValues))]
        public void Add_DecimalAddends_ThrowsOverflowException(Decimal leftOperand, Decimal rightOperand)
        {
            Assert.Throws<OverflowException>(() => Math.Add(leftOperand, rightOperand));
        }
    }
}