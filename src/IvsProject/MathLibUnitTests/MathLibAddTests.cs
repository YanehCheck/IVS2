using Math = MathLib.Math;

namespace MathLibUnitTests
{
    /// <summary>
    /// Unit tests for MathLib Add function.
    /// </summary>
    public class MathLibAddTests 
    {
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(2, 0, 2)]
        [InlineData(0, 2, 2)]
        [InlineData(1, 2, 3)]
        [InlineData(-1, -2, -3)]
        [InlineData(1, -2, -1)]
        [InlineData(-1, 2, 1)]
        [InlineData(10000, 20000, 30000)]
        [InlineData(-10000, -20000, -30000)]
        [InlineData(10000, -20000, -10000)]
        [InlineData(-10000, 20000, 10000)]
        [InlineData(Int32.MaxValue, 1, Int32.MaxValue)]
        [InlineData(Int32.MinValue, -1, Int32.MinValue)]
        public void Add_Int32Addends_ReturnsSum(Int32 leftOperand, Int32 rightOperand, Int32 expectedResult)
        {
            Int32 result = Math.Add(leftOperand, rightOperand);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(2, 0, 2)]
        [InlineData(0, 2, 2)]
        [InlineData(1, 2, 3)]
        [InlineData(UInt32.MaxValue, 1, UInt32.MaxValue)]
        public void Add_UInt32Addends_ReturnsSum(UInt32 leftOperand, UInt32 rightOperand, UInt32 expectedResult)
        {
            UInt32 result = Math.Add(leftOperand, rightOperand);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(0.0, 0.0, 0.0)]
        [InlineData(2.5, 0, 2.5)]
        [InlineData(0, 2.1, 2.1)]
        [InlineData(10000.2, 20000.4, 30000.6)]
        [InlineData(-10000.2, -20000.2, -30000.0)]
        [InlineData(10000.4, -20000.6, -10000.2)]
        [InlineData(-10000.4, 20000.2, 9999.8)]
        [InlineData(0.123456789, 0.987654321, 1.11111111)]
        [InlineData(0.123456789, -0.987654321, -0.864197532)]
        [InlineData(Single.MinValue, -1, Single.PositiveInfinity)]
        [InlineData(Single.MaxValue, 1, Single.NegativeInfinity)]
        public void Add_SingleAddends_ReturnsSum(Single leftOperand, Single rightOperand, Single expectedResult)
        {
            Single result = Math.Add(leftOperand, rightOperand);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(0.0, 0.0, 0.0)]
        [InlineData(2.5, 0, 2.5)]
        [InlineData(0, 2.1, 2.1)]
        [InlineData(10000.2, 20000.4, 30000.6)]
        [InlineData(-10000.2, -20000.2, -30000.0)]
        [InlineData(10000.4, -20000.6, -10000.2)]
        [InlineData(-10000.4, 20000.2, 9999.8)]
        [InlineData(0.123456789, 0.987654321, 1.11111111)]
        [InlineData(0.123456789, -0.987654321, -0.864197532)]
        [InlineData(Double.MinValue, -1, Double.PositiveInfinity)]
        [InlineData(Double.MaxValue, 1, Double.NegativeInfinity)]
        public void Add_DoubleAddends_ReturnsSum(Double leftOperand, Double rightOperand, Double expectedResult)
        {
            Double result = Math.Add(leftOperand, rightOperand);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(0.0, 0.0, 0.0)]
        [InlineData(2.5, 0, 2.5)]
        [InlineData(0, 2.1, 2.1)]
        [InlineData(10000.2, 20000.4, 30000.6)]
        [InlineData(-10000.2, -20000.2, -30000.0)]
        [InlineData(10000.4, -20000.6, -10000.2)]
        [InlineData(-10000.4, 20000.2, 9999.8)]
        [InlineData(0.123456789, 0.987654321, 1.11111111)]
        [InlineData(0.123456789, -0.987654321, -0.864197532)]
        [InlineData(-79228162514264337593543950335.0, -1.0, -79228162514264337593543950335.0)]
        [InlineData(79228162514264337593543950335.0, 1.0, 79228162514264337593543950335.0)]
        public void Add_DecimalAddends_ReturnsSum(Decimal leftOperand, Decimal rightOperand, Decimal expectedResult)
        {
            Decimal result = Math.Add(leftOperand, rightOperand);

            Assert.Equal(expectedResult, result);
        }
    }
}