namespace CalculatorModel 
{
    /// <summary>
    /// Record holding information about calculation result.
    /// </summary>
    public record CalculationResult 
    {
        /// <summary>
        /// The value of mathematical expression.
        /// Property is set to zero when the expression is undefined.
        /// </summary>
        public decimal Value { get; init; }
        /// <summary>
        /// Set to <value>None</value> if mathematical expression was valid.
        /// Otherwise set to the appropriate error.
        /// </summary>
        public CalculationErrorType ErrorType { get; init; }

        /// <summary>
        /// Initializes a new instance of <see cref="Calculator"/> record.
        /// </summary>
        public CalculationResult(decimal value, CalculationErrorType errorType) 
        {
            Value = value;
            ErrorType = errorType;
        }
    }
}
