using Math = MathLib.Math;

namespace MathLibUnitTests
{
    /// <summary>
    /// Unit tests for MathLib Root function.
    /// </summary>
    public class MathLibRootTests
    {
        /// <summary>
        /// List of decimal test inputs that return root.
        /// </summary>
        public static IEnumerable<object[]> DecimalValues => new List<object[]>
        {
            new object[] { 1m, 0m, 0m },
            new object[] { 1m, 1m, 1m },
            new object[] { 1m, 2m, 2m },
            new object[] { 1m, 3m, 3m },
            new object[] { -1m, 1m, 1m },
            new object[] { -1m, 2m, 0.5m },
            new object[] { 2m, 0m, 0m },
            new object[] { 2m, 1m, 1m },
            new object[] { 10m, 0m, 0m },
            new object[] { 10m, 1m, 1m },
            new object[] { -2m, 100m, 0.1m },
            new object[] { 2m, 100m, 10m },
            new object[] { 3m, 1_000m, 10m },
            new object[] { -3m, 1_000m, 0.1m },
            new object[] { 0.5m, 2m, 4m },
            new object[] { -0.5m, 2m, 0.25m },
            new object[] { 1m, 1.5m, 1.5m },
            new object[] { -1m, 1.25m, 0.8m },
            new object[] { 2m, 110.25m, 10.5m }
        };

        /// <summary>
        /// List of decimal test inputs that should throw OverflowException.
        /// </summary>
        public static IEnumerable<object[]> DecimalOverflowValues => new List<object[]>
        {
            new object[] { 0.5m, Constants.DECIMAL_MIN_VALUE },
            new object[] { 0.5m, Constants.DECIMAL_MAX_VALUE }
        };

        /// <summary>
        /// List of decimal test inputs that should throw DivideByZeroException.
        /// </summary>
        public static IEnumerable<object[]> DecimalZeroValues => new List<object[]>
        {
            new object[] { 0m, 0m },
            new object[] { 0m, 1m },
            new object[] { 0m, -1m }
        };

        /// <summary>
        /// List of decimal test inputs that should throw NotFiniteNumberException.
        /// </summary>
        public static IEnumerable<object[]> DecimalNotFiniteValues => new List<object[]>
        {
            new object[] { -1m, 0m },
            new object[] { -2m, 0m }
        };

        /// <summary>
        /// List of decimal test inputs that should throw ArgumentException.
        /// </summary>
        public static IEnumerable<object[]> DecimalArgumentValues => new List<object[]>
        {
            new object[] { 1m, -1m },
            new object[] { -1m, -1m }
        };

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

        [Theory]
        [InlineData(1f, 0f, 0f)]
        [InlineData(1f, 1f, 1f)]
        [InlineData(1f, 2f, 2f)]
        [InlineData(1f, 3f, 3f)]
        [InlineData(-1f, 1f, 1f)]
        [InlineData(-1f, 2f, 0.5f)]
        [InlineData(2f, 0f, 0f)]
        [InlineData(2f, 1f, 1f)]
        [InlineData(10f, 0f, 0f)]
        [InlineData(10f, 1f, 1f)]
        [InlineData(-2f, 100f, 0.1f)]
        [InlineData(2f, 100f, 10f)]
        [InlineData(3f, 1_000f, 10f)]
        [InlineData(-3f, 1_000f, 0.1f)]
        [InlineData(0.5f, 2f, 4f)]
        [InlineData(-0.5f, 2f, 0.25f)]
        [InlineData(1f, 1.5f, 1.5f)]
        [InlineData(-1f, 1.25f, 0.8f)]
        [InlineData(2f, 110.25f, 10.5f)]
        public void Root_SingleOperands_ReturnsRoot(Single index, Single radicand, Single expectedResult)
        {
            Single result = Math.Root(index, radicand);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(0.5f, Single.MinValue)]
        [InlineData(0.5f, Single.MaxValue)]
        public void Root_SingleOperands_ThrowsOverflowException(Single index, Single radicand)
        {
            Assert.Throws<OverflowException>(() => Math.Root(index, radicand));
        }

        // radicand^(1/index) => index can not be 0
        [Theory]
        [InlineData(0f, 0f)]
        [InlineData(0f, 1f)]
        [InlineData(0f, -1f)]
        public void Root_SingleOperands_ThrowsDivideByZeroException(Single index, Single radicand)
        {
            Assert.Throws<DivideByZeroException>(() => Math.Root(index, radicand));
        }

        // radicand == 0 && index is negative => root will be infinity
        [Theory]
        [InlineData(-1f, 0f)]
        [InlineData(-2f, 0f)]
        [InlineData(Single.NaN, Single.NaN)]
        [InlineData(Single.PositiveInfinity, Single.PositiveInfinity)]
        [InlineData(Single.NegativeInfinity, Single.NegativeInfinity)]
        [InlineData(Single.NaN, Single.PositiveInfinity)]
        [InlineData(Single.NaN, Single.NegativeInfinity)]
        [InlineData(Single.PositiveInfinity, Single.NegativeInfinity)]
        [InlineData(Single.NaN, 1f)]
        [InlineData(Single.PositiveInfinity, 1f)]
        [InlineData(Single.NegativeInfinity, 1f)]
        [InlineData(1f, Single.NaN)]
        [InlineData(1f, Single.PositiveInfinity)]
        [InlineData(1f, Single.NegativeInfinity)]
        public void Root_SingleOperands_ThrowsNotFiniteNumberException(Single index, Single radicand)
        {
            Assert.Throws<NotFiniteNumberException>(() => Math.Root(index, radicand));
        }

        // radicand must be positive
        [Theory]
        [InlineData(1f, -1f)]
        [InlineData(-1f, -1f)]
        public void Root_SingleOperands_ThrowsArgumentException(Single index, Single radicand)
        {
            Assert.Throws<ArgumentException>(() => Math.Root(index, radicand));
        }

        [Theory]
        [InlineData(1d, 0d, 0d)]
        [InlineData(1d, 1d, 1d)]
        [InlineData(1d, 2d, 2d)]
        [InlineData(1d, 3d, 3d)]
        [InlineData(-1d, 1d, 1d)]
        [InlineData(-1d, 2d, 0.5d)]
        [InlineData(2d, 0d, 0d)]
        [InlineData(2d, 1d, 1d)]
        [InlineData(10d, 0d, 0d)]
        [InlineData(10d, 1d, 1d)]
        [InlineData(-2d, 100d, 0.1d)]
        [InlineData(2d, 100d, 10d)]
        [InlineData(3d, 1_000d, 10d)]
        [InlineData(-3d, 1_000d, 0.1d)]
        [InlineData(0.5d, 2d, 4d)]
        [InlineData(-0.5d, 2d, 0.25d)]
        [InlineData(1d, 1.5d, 1.5d)]
        [InlineData(-1d, 1.25d, 0.8d)]
        [InlineData(2d, 110.25d, 10.5d)]
        public void Root_DoubleOperands_ReturnsRoot(Double index, Double radicand, Double expectedResult)
        {
            Double result = Math.Root(index, radicand);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(0.5f, Double.MinValue)]
        [InlineData(0.5f, Double.MaxValue)]
        public void Root_DoubleOperands_ThrowsOverflowException(Double index, Double radicand)
        {
            Assert.Throws<OverflowException>(() => Math.Root(index, radicand));
        }

        // radicand^(1/index) => index can not be 0
        [Theory]
        [InlineData(0d, 0d)]
        [InlineData(0d, 1d)]
        [InlineData(0d, -1d)]
        public void Root_DoubleOperands_ThrowsDivideByZeroException(Double index, Double radicand)
        {
            Assert.Throws<DivideByZeroException>(() => Math.Root(index, radicand));
        }

        // radicand == 0 && index is negative => root will be infinity
        [Theory]
        [InlineData(-1d, 0d)]
        [InlineData(-2d, 0d)]
        [InlineData(Double.NaN, Double.NaN)]
        [InlineData(Double.PositiveInfinity, Double.PositiveInfinity)]
        [InlineData(Double.NegativeInfinity, Double.NegativeInfinity)]
        [InlineData(Double.NaN, Double.PositiveInfinity)]
        [InlineData(Double.NaN, Double.NegativeInfinity)]
        [InlineData(Double.PositiveInfinity, Double.NegativeInfinity)]
        [InlineData(Double.NaN, 1f)]
        [InlineData(Double.PositiveInfinity, 1f)]
        [InlineData(Double.NegativeInfinity, 1f)]
        [InlineData(1f, Double.NaN)]
        [InlineData(1f, Double.PositiveInfinity)]
        [InlineData(1f, Double.NegativeInfinity)]
        public void Root_DoubleOperands_ThrowsNotFiniteNumberException(Double index, Double radicand)
        {
            Assert.Throws<NotFiniteNumberException>(() => Math.Root(index, radicand));
        }

        // radicand must be positive
        [Theory]
        [InlineData(1d, -1d)]
        [InlineData(-1d, -1d)]
        public void Root_DoubleOperands_ThrowsArgumentException(Double index, Double radicand)
        {
            Assert.Throws<ArgumentException>(() => Math.Root(index, radicand));
        }

        [Theory]
        [MemberData(nameof(DecimalValues))]
        public void Root_DecimalOperands_ReturnsRoot(Decimal index, Decimal radicand, Decimal expectedResult)
        {
            Decimal result = Math.Root(index, radicand);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [MemberData(nameof(DecimalOverflowValues))]
        public void Root_DecimalOperands_ThrowsOverflowException(Decimal index, Decimal radicand)
        {
            Assert.Throws<OverflowException>(() => Math.Root(index, radicand));
        }

        [Theory]
        [MemberData(nameof(DecimalZeroValues))]
        public void Root_DecimalOperands_ThrowsDivideByZeroException(Decimal index, Decimal radicand)
        {
            Assert.Throws<DivideByZeroException>(() => Math.Root(index, radicand));
        }

        [Theory]
        [MemberData(nameof(DecimalNotFiniteValues))]
        public void Root_DecimalOperands_ThrowsNotFiniteNumberException(Decimal index, Decimal radicand)
        {
            Assert.Throws<NotFiniteNumberException>(() => Math.Root(index, radicand));
        }

        [Theory]
        [MemberData(nameof(DecimalArgumentValues))]
        public void Root_DecimalOperands_ThrowsArgumentException(Decimal index, Decimal radicand)
        {
            Assert.Throws<ArgumentException>(() => Math.Root(index, radicand));
        }
    }
}
