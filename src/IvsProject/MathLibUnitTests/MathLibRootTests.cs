using Math = MathLib.Math;

namespace MathLibUnitTests
{
    /// <summary>
    /// Unit tests for MathLib Root function.
    /// </summary>
    public class MathLibRootTests
    {
        [Theory]
        [InlineData(1, 0, 0)]
        [InlineData(1, 1, 1)]
        [InlineData(1, 2, 2)]
        [InlineData(1, 3, 3)]
        [InlineData(-1, 1, 1)]
        [InlineData(-1, 2, 0)]
        [InlineData(-1, 3, 0)]
        [InlineData(2, 0, 0)]
        [InlineData(2, 1, 1)]
        [InlineData(2, 2, 1)]
        [InlineData(10, 0, 0)]
        [InlineData(10, 1, 1)]
        [InlineData(-2, 100, 0)]
        [InlineData(2, 100, 10)]
        [InlineData(3, 1_000, 10)]
        public void Root_Int32Operands_ReturnsRoot(Int32 index, Int32 radicand, Int32 expectedResult)
        {
            Int32 result = Math.Root(index, radicand);

            Assert.Equal(expectedResult, result);
        }

        // radicand^(1/index) => index can not be 0
        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(0, -1)]
        public void Root_Int32Operands_ThrowsDivideByZeroException(Int32 index, Int32 radicand)
        {
            Assert.Throws<DivideByZeroException>(() => Math.Root(index, radicand));
        }

        // radicand == 0 && index is negative => root will be infinity
        [Theory]
        [InlineData(-1, 0)]
        [InlineData(-2, 0)]
        public void Root_Int32Operands_ThrowsNotFiniteNumberException(Int32 index, Int32 radicand)
        {
            Assert.Throws<NotFiniteNumberException>(() => Math.Root(index, radicand));
        }

        // radicand must be positive
        [Theory]
        [InlineData(1, -1)]
        [InlineData(-1, -1)]
        [InlineData(2, -1)]
        public void Root_Int32Operands_ThrowsArgumentException(Int32 index, Int32 radicand)
        {
            Assert.Throws<ArgumentException>(() => Math.Root(index, radicand));
        }

        [Theory]
        [InlineData(1u, 0u, 0u)]
        [InlineData(1u, 1u, 1u)]
        [InlineData(1u, 2u, 2u)]
        [InlineData(1u, 3u, 3u)]
        [InlineData(2u, 0u, 0u)]
        [InlineData(2u, 1u, 1u)]
        [InlineData(2u, 2u, 1u)]
        [InlineData(10u, 0u, 0u)]
        [InlineData(10u, 1u, 1u)]
        [InlineData(2u, 100u, 10u)]
        [InlineData(3u, 1_000u, 10u)]
        public void Root_UInt32Operands_ReturnsRoot(UInt32 index, UInt32 radicand, UInt32 expectedResult)
        {
            UInt32 result = Math.Root(index, radicand);

            Assert.Equal(expectedResult, result);
        }

        // radicand^(1/index) => index can not be 0
        [Theory]
        [InlineData(0u, 0u)]
        [InlineData(0u, 1u)]
        public void Root_UInt32Operands_ThrowsDivideByZeroException(UInt32 index, UInt32 radicand)
        {
            Assert.Throws<DivideByZeroException>(() => Math.Root(index, radicand));
        }
    }
}
