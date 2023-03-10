using Math = MathLib.Math;

namespace MathLibUnitTests
{
    /// <summary>
    /// Unit tests for MathLib Subtract function.
    /// </summary>
    public class MathLibSubtractTests
    {
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
    }
}
