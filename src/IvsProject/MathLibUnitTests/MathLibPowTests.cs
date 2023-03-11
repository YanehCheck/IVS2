using Math = MathLib.Math;

namespace MathLibUnitTests
{
    /// <summary>
    /// Unit tests for MathLib Pow function.
    /// </summary>
    public class MathLibPowTests
    {
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
        [InlineData(0, 0, 1)]
        [InlineData(0, 1, 0)]
        [InlineData(0, 2, 0)]
        [InlineData(1, 0, 1)]
        [InlineData(1, 1, 1)]
        [InlineData(1, 2, 1)]
        [InlineData(1, 3, 1)]
        [InlineData(2, 0, 1)]
        [InlineData(2, 1, 2)]
        [InlineData(2, 2, 4)]
        [InlineData(10, 0, 1)]
        [InlineData(10, 1, 10)]
        [InlineData(10, 2, 100)]
        [InlineData(10, 9, 1_000_000_000)]
        [InlineData(65_535, 2, 4_294_836_225)]
        public void Pow_UInt32Base_ReturnsPower(UInt32 baseNumber, Int32 exponent, UInt32 expectedResult)
        {
            UInt32 result = Math.Pow(baseNumber, exponent);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(10, 10)]
        [InlineData(65_536, 2)]
        [InlineData(UInt32.MaxValue, 2)]
        public void Pow_UInt32Base_ThrowsOverflowException(UInt32 baseNumber, Int32 exponent)
        {
            Assert.Throws<OverflowException>(() => Math.Pow(baseNumber, exponent));
        }
    }
}
