using Math = MathLib.Math;

namespace MathLibUnitTests
{
    /// <summary>
    /// Unit tests for MathLib Factorial function.
    /// </summary>
    public class MathLibFactorialTests
    {
        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 6)]
        [InlineData(10, 3_628_800)]
        [InlineData(12, 479_001_600)]
        public void Factorial_Int32Operand_ReturnsFactorial(Int32 n, Int32 expectedResult)
        {
            Int32 result = Math.Factorial(n);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(13)]
        [InlineData(14)]
        [InlineData(Int32.MaxValue)]
        public void Factorial_Int32Operand_ThrowsOverflowException(Int32 n)
        {
            Assert.Throws<OverflowException>(() => Math.Factorial(n));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(Int32.MinValue)]
        public void Factorial_Int32Operand_ThrowsArgumentException(Int32 n)
        {
            Assert.Throws<ArgumentException>(() => Math.Factorial(n));
        }
    }
}
