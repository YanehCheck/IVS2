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

        [Theory]
        [InlineData(0.0f, 0.0f, 0.0f)]
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
        [InlineData(Single.MinValue, 1f, Single.NegativeInfinity)]
        [InlineData(Single.MinValue, -1f, Single.MinValue + 1f)]
        [InlineData(Single.MaxValue, 1f, Single.MaxValue - 1f)]
        [InlineData(Single.MaxValue, -1f, Single.PositiveInfinity)]
        public void Subtract_SingleOperands_ReturnsDifference(Single leftOperand, Single rightOperand, Single expectedResult)
        {
            Single result = Math.Subtract(leftOperand, rightOperand);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(0.0, 0.0, 0.0)]
        [InlineData(2.5, 0, 2.5)]
        [InlineData(0, 2.1, -2.1)]
        [InlineData(0, -2.1, 2.1)]
        [InlineData(10_000.2, 20_000.4, -10_000.2)]
        [InlineData(-10_000.2, -20_000.2, 10_000.0)]
        [InlineData(10_000.4, -20_000.6, 30_001.0)]
        [InlineData(-10_000.4, 20_000.2, -30_000.6)]
        [InlineData(0.123_456_789, -0.987_654_321, 1.111_111_11)]
        [InlineData(0.123_456_789, 0.987_654_321, -0.864_197_532)]
        [InlineData(-0.123_456_789, -0.987_654_321, 0.864_197_532)]
        [InlineData(-0.123_456_789, 0.987_654_321, -1.111_111_11)]
        [InlineData(Double.MinValue, 1, Double.NegativeInfinity)]
        [InlineData(Double.MinValue, -1, Double.MinValue + 1)]
        [InlineData(Double.MaxValue, 1, Double.MaxValue - 1)]
        [InlineData(Double.MaxValue, -1, Double.PositiveInfinity)]
        public void Subtract_DoubleOperands_ReturnsDifference(Double leftOperand, Double rightOperand, Double expectedResult)
        {
            Double result = Math.Subtract(leftOperand, rightOperand);

            Assert.Equal(expectedResult, result);
        }
    }
}
