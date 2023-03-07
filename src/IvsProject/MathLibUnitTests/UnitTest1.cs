namespace MathLibUnitTests 
{
    public class UnitTest1 
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

        //[Theory]
        public void AddTest<T>(T leftOperand, T rightOperand, T expectedResult) 
        {

        }

        //[Theory]
        public void SubtractTest<T>(T leftOperand, T rightOperand, T expectedResult) 
        {

        }

        //[Theory]
        public void MultiplyTest<T>(T leftOperand, T rightOperand, T expectedResult)
        {

        }

        //[Theory]
        public void DivideTest<T>(T leftOperand, T rightOperand, T expectedResult)
        {

        }

        //[Theory]
        public void ModuloTest<T>(T leftOperand, T rightOperand, T expectedResult) 
        {

        }

        //[Theory]
        public void FactorialTest(int n, int expectedResult) 
        {

        }

        //[Theory]
        public void PowTest<T>(T b, int n, T expectedResult) 
        {

        }

        //[Theory]
        public void PowTest<T>(T x, T n, T expectedResult) 
        {

        }
    }
}