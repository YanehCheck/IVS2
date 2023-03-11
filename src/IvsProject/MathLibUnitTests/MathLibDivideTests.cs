using Math = MathLib.Math;

namespace MathLibUnitTests
{
    /// <summary>
    /// Unit tests for MathLib Divide function.
    /// </summary>
    public class MathLibDivideTests
    {
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
    }
}
