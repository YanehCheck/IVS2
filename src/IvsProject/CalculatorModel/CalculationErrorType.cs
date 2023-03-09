namespace CalculatorModel 
{
    /// <summary>
    /// Specifies if and what kind of error in the calculation.
    /// </summary>
    public enum CalculationErrorType 
    {
        None,
        SyntaxError,
        DivisionByZeroError,
        NotNaturalFactorialError,
        NotNaturalExponentError,
        NegativeRootBaseError
    }
}