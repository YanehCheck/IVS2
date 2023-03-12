using Math = MathLib.Math;

namespace MathLibUnitTests
{
    /// <summary>
    /// Unit tests for MathLib Pow function.
    /// </summary>
    public class MathLibPowTests
    {
        /// <summary>
        /// List of decimal test inputs that return power.
        /// </summary>
        public static IEnumerable<object[]> DecimalValues => new List<object[]>
        {
            new object[] { 2.5m, 0, 1m },
            new object[] { 2.5m, 1, 2.5m },
            new object[] { 2.5m, 2, 6.25m },
            new object[] { 2.5m, 3, 15.625m },
            new object[] { -2.5m, 0, 1 },
            new object[] { -2.5m, 1, -2.5m },
            new object[] { -2.5m, 2, 6.25m },
            new object[] { -2.5m, 3, -15.625m },
            new object[] { 0.5m, 0, 1m },
            new object[] { 0.5m, 1, 0.5m },
            new object[] { 0.5m, 2, 0.25m },
            new object[] { 0.5m, 3, 0.125m },
            new object[] { -0.5m, 0, 1m },
            new object[] { -0.5m, 1, -0.5m },
            new object[] { -0.5m, 2, 0.25m },
            new object[] { -0.5m, 3, -0.125m }
        };

        /// <summary>
        /// List of decimal test inputs that should throw OverflowException.
        /// </summary>
        public static IEnumerable<object[]> DecimalEdgeValues => new List<object[]>
        {
            new object[] { Constants.DECIMAL_MIN_VALUE, 2 },
            new object[] { Constants.DECIMAL_MAX_VALUE, 2 }
        };

        /// <summary>
        /// List of decimal test inputs that should throw ArgumentException.
        /// </summary>
        public static IEnumerable<object[]> DecimalArgumentValues => new List<object[]>
        {
            new object[] { 1m, -1 },
            new object[] { 1m, -2 },
            new object[] { -1m, -1 },
            new object[] { -1m, -2 }
        };

        [Theory]
        [InlineData(0, 0, 1)]
        [InlineData(0, 1, 0)]
        [InlineData(0, 2, 0)]
        [InlineData(1, 0, 1)]
        [InlineData(1, 1, 1)]
        [InlineData(1, 2, 1)]
        [InlineData(1, 3, 1)]
        [InlineData(-1, 0, 1)]
        [InlineData(-1, 1, -1)]
        [InlineData(-1, 2, 1)]
        [InlineData(-1, 3, -1)]
        [InlineData(2, 0, 1)]
        [InlineData(2, 1, 2)]
        [InlineData(2, 2, 4)]
        [InlineData(10, 0, 1)]
        [InlineData(10, 1, 10)]
        [InlineData(10, 2, 100)]
        [InlineData(-10, 1, -10)]
        [InlineData(-10, 2, 100)]
        [InlineData(-10, 3, -1_000)]
        [InlineData(10, 9, 1_000_000_000)]
        [InlineData(46_340, 2, 2_147_395_600)]
        [InlineData(-46_340, 2, 2_147_395_600)]
        public void Pow_Int32Base_ReturnsPower(Int32 baseNumber, Int32 exponent, Int32 expectedResult)
        {
            Int32 result = Math.Pow(baseNumber, exponent);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(10, 10)]
        [InlineData(46_341, 2)]
        [InlineData(Int32.MaxValue, 2)]
        public void Pow_Int32Base_ThrowsOverflowException(Int32 baseNumber, Int32 exponent)
        {
            Assert.Throws<OverflowException>(() => Math.Pow(baseNumber, exponent));
        }

        [Theory]
        [InlineData(1, -1)]
        [InlineData(1, -2)]
        [InlineData(-1, -1)]
        [InlineData(-1, -2)]
        public void Pow_Int32Operand_ThrowsArgumentException(Int32 baseNumber, Int32 exponent)
        {
            Assert.Throws<ArgumentException>(() => Math.Pow(baseNumber, exponent));
        }

        [Theory]
        [InlineData(0u, 0, 1u)]
        [InlineData(0u, 1, 0u)]
        [InlineData(0u, 2, 0u)]
        [InlineData(1u, 0, 1u)]
        [InlineData(1u, 1, 1u)]
        [InlineData(1u, 2, 1u)]
        [InlineData(1u, 3, 1u)]
        [InlineData(2u, 0, 1u)]
        [InlineData(2u, 1, 2u)]
        [InlineData(2u, 2, 4u)]
        [InlineData(10u, 0, 1u)]
        [InlineData(10u, 1, 10u)]
        [InlineData(10u, 2, 100u)]
        [InlineData(10u, 9, 1_000_000_000u)]
        [InlineData(65_535u, 2, 4_294_836_225u)]
        public void Pow_UInt32Base_ReturnsPower(UInt32 baseNumber, Int32 exponent, UInt32 expectedResult)
        {
            UInt32 result = Math.Pow(baseNumber, exponent);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(10u, 10)]
        [InlineData(65_536u, 2)]
        [InlineData(UInt32.MaxValue, 2)]
        public void Pow_UInt32Base_ThrowsOverflowException(UInt32 baseNumber, Int32 exponent)
        {
            Assert.Throws<OverflowException>(() => Math.Pow(baseNumber, exponent));
        }

        [Theory]
        [InlineData(2.5f, 0, 1f)]
        [InlineData(2.5f, 1, 2.5f)]
        [InlineData(2.5f, 2, 6.25f)]
        [InlineData(2.5f, 3, 15.625f)]
        [InlineData(-2.5f, 0, 1)]
        [InlineData(-2.5f, 1, -2.5f)]
        [InlineData(-2.5f, 2, 6.25f)]
        [InlineData(-2.5f, 3, -15.625f)]
        [InlineData(0.5f, 0, 1f)]
        [InlineData(0.5f, 1, 0.5f)]
        [InlineData(0.5f, 2, 0.25f)]
        [InlineData(0.5f, 3, 0.125f)]
        [InlineData(-0.5f, 0, 1f)]
        [InlineData(-0.5f, 1, -0.5f)]
        [InlineData(-0.5f, 2, 0.25f)]
        [InlineData(-0.5f, 3, -0.125f)]
        public void Pow_SingleBase_ReturnsPower(Single baseNumber, Int32 exponent, Single expectedResult)
        {
            Single result = Math.Pow(baseNumber, exponent);

            Assert.Equal(expectedResult, result, Constants.EPSILON);
        }

        [Theory]
        [InlineData(Single.MinValue, 2)]
        [InlineData(Single.MaxValue, 2)]
        public void Pow_SingleBase_ThrowsOverflowException(Single baseNumber, Int32 exponent)
        {
            Assert.Throws<OverflowException>(() => Math.Pow(baseNumber, exponent));
        }

        [Theory]
        [InlineData(Single.NaN, 0)]
        [InlineData(Single.PositiveInfinity, 0)]
        [InlineData(Single.NegativeInfinity, 0)]
        [InlineData(Single.NaN, 1)]
        [InlineData(Single.PositiveInfinity, 1)]
        [InlineData(Single.NegativeInfinity, 1)]
        public void Pow_SingleBase_ThrowsNotFiniteNumberException(Single baseNumber, Int32 exponent)
        {
            Assert.Throws<NotFiniteNumberException>(() => Math.Pow(baseNumber, exponent));
        }

        [Theory]
        [InlineData(1f, -1)]
        [InlineData(1f, -2)]
        [InlineData(-1f, -1)]
        [InlineData(-1f, -2)]
        public void Pow_SingleBase_ThrowsArgumentException(Single baseNumber, Int32 exponent)
        {
            Assert.Throws<ArgumentException>(() => Math.Pow(baseNumber, exponent));
        }

        [Theory]
        [InlineData(2.5d, 0, 1d)]
        [InlineData(2.5d, 1, 2.5d)]
        [InlineData(2.5d, 2, 6.25d)]
        [InlineData(2.5d, 3, 15.625d)]
        [InlineData(-2.5d, 0, 1)]
        [InlineData(-2.5d, 1, -2.5d)]
        [InlineData(-2.5d, 2, 6.25d)]
        [InlineData(-2.5d, 3, -15.625d)]
        [InlineData(0.5d, 0, 1d)]
        [InlineData(0.5d, 1, 0.5d)]
        [InlineData(0.5d, 2, 0.25d)]
        [InlineData(0.5d, 3, 0.125d)]
        [InlineData(-0.5d, 0, 1d)]
        [InlineData(-0.5d, 1, -0.5d)]
        [InlineData(-0.5d, 2, 0.25d)]
        [InlineData(-0.5d, 3, -0.125d)]
        public void Pow_DoubleBase_ReturnsPower(Double baseNumber, Int32 exponent, Double expectedResult)
        {
            Double result = Math.Pow(baseNumber, exponent);

            Assert.Equal(expectedResult, result, Constants.PRECISION);
        }

        [Theory]
        [InlineData(Double.MinValue, 2)]
        [InlineData(Double.MaxValue, 2)]
        public void Pow_DoubleBase_ThrowsOverflowException(Double baseNumber, Int32 exponent)
        {
            Assert.Throws<OverflowException>(() => Math.Pow(baseNumber, exponent));
        }

        [Theory]
        [InlineData(Double.NaN, 0)]
        [InlineData(Double.PositiveInfinity, 0)]
        [InlineData(Double.NegativeInfinity, 0)]
        [InlineData(Double.NaN, 1)]
        [InlineData(Double.PositiveInfinity, 1)]
        [InlineData(Double.NegativeInfinity, 1)]
        public void Pow_DoubleBase_ThrowsNotFiniteNumberException(Double baseNumber, Int32 exponent)
        {
            Assert.Throws<NotFiniteNumberException>(() => Math.Pow(baseNumber, exponent));
        }

        [Theory]
        [InlineData(1d, -1)]
        [InlineData(1d, -2)]
        [InlineData(-1d, -1)]
        [InlineData(-1d, -2)]
        public void Pow_DoubleBase_ThrowsArgumentException(Double baseNumber, Int32 exponent)
        {
            Assert.Throws<ArgumentException>(() => Math.Pow(baseNumber, exponent));
        }

        [Theory]
        [MemberData(nameof(DecimalValues))]
        public void Pow_DecimalBase_ReturnsPower(Decimal baseNumber, Int32 exponent, Decimal expectedResult)
        {
            Decimal result = Math.Pow(baseNumber, exponent);

            Assert.Equal(expectedResult, result, Constants.PRECISION);
        }

        [Theory]
        [MemberData(nameof(DecimalEdgeValues))]
        public void Pow_DecimalBase_ThrowsOverflowException(Decimal baseNumber, Int32 exponent)
        {
            Assert.Throws<OverflowException>(() => Math.Pow(baseNumber, exponent));
        }

        [Theory]
        [MemberData(nameof(DecimalArgumentValues))]
        public void Pow_DecimalBase_ThrowsArgumentException(Decimal baseNumber, Int32 exponent)
        {
            Assert.Throws<ArgumentException>(() => Math.Pow(baseNumber, exponent));
        }
    }
}
