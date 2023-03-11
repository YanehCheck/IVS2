using Math = MathLib.Math;

namespace MathLibUnitTests
{
    /// <summary>
    /// Unit tests for MathLib Modulo function.
    /// </summary>
    public class MathLibModuloTests
    {
        [Theory]
        [InlineData(0, 2, 0)]
        [InlineData(2, 1, 0)]
        [InlineData(1, 2, 1)]
        [InlineData(-1, -2, -1)]
        [InlineData(1, -2, -1)]
        [InlineData(-1, 2, 1)]
        [InlineData(25, 5, 0)]
        [InlineData(-25, -5, 0)]
        [InlineData(25, -5, 0)]
        [InlineData(-25, 5, 0)]
        public void Modulo_Int32Operands_ReturnsRemainder(Int32 leftOperand, Int32 rightOperand, Int32 expectedResult)
        {
            Int32 result = Math.Modulo(leftOperand, rightOperand);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(Int32.MinValue, -1)]
        public void Modulo_Int32Operands_ThrowsOverflowException(Int32 leftOperand, Int32 rightOperand)
        {
            Assert.Throws<OverflowException>(() => Math.Modulo(leftOperand, rightOperand));
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 0)]
        [InlineData(-1, 0)]
        public void Modulo_Int32Operands_ThrowsDivideByZeroException(Int32 leftOperand, Int32 rightOperand)
        {
            Assert.Throws<DivideByZeroException>(() => Math.Modulo(leftOperand, rightOperand));
        }

        [Theory]
        [InlineData(0u, 2u, 0u)]
        [InlineData(2u, 1u, 0u)]
        [InlineData(1u, 2u, 1u)]
        [InlineData(25u, 5u, 0u)]
        public void Modulo_UInt32Operands_ReturnsRemainder(UInt32 leftOperand, UInt32 rightOperand, UInt32 expectedResult)
        {
            UInt32 result = Math.Modulo(leftOperand, rightOperand);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(0u, 0u)]
        [InlineData(1u, 0u)]
        public void Modulo_UInt32Operands_ThrowsDivideByZeroException(UInt32 leftOperand, UInt32 rightOperand)
        {
            Assert.Throws<DivideByZeroException>(() => Math.Modulo(leftOperand, rightOperand));
        }
    }
}
