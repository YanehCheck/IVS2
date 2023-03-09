using Math = MathLib.Math;

namespace MathLibUnitTests
{
    public class MathLibAddTests 
    {
        /* Added simple test structure
         * ------------------------------------------------------------------------
         * Do not forget to test the exceptions!
         * i.e. negative int in factorial, divide by zero (see documentation for the full list of possible exceptions),
         * but try to find unspecified exceptions :)
         * To match house style prototype for testing exceptions should for example look like this:
         * public void DivideTest_ExpectDivideByZeroException<T>(T leftOperand, T rightOperand, T expectedResult)
         *
         * Do not forget to test multiple types!
         * Not only integers - i.e.              [InlineData(5,4,3)]
         * But also decimals - i.e.              [InlineData(5m,4m,3m)]
         * and other types like double, float, and so on...
         * Also do not forget about edge cases like NaN, Infinity and more.
         * (see https://learn.microsoft.com/en-us/dotnet/standard/numerics)
         * ------------------------------------------------------------------------
         * Also do not forget to delete this :P
         */

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
    }
}