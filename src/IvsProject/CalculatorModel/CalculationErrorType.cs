namespace CalculatorModel 
{
    /// <summary>
    /// Specifies if and what kind of error in the calculation.
    /// </summary>
    public enum CalculationErrorType 
    {
        None,
        InternalError, // This is used in code that could break by addition of a new features
        SyntaxError,
        DivisionByZeroError,
        DivisionByZeroErrorInIndex,
        NotNaturalFactorialError,
        NotNaturalExponentError,
        NoRealSolutionError,
        OverflowError
    }
}