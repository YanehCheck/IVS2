using Math = MathLib.Math;

namespace MathLibUnitTests
{
    /// <summary>
    /// Unit tests for MathLib Multiply function.
    /// </summary>
    public class MathLibMultiplyTests
    {
        [Theory]
        [InlineData(0, 0, 0)]
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
    }
}
