namespace CalculatorModel {
    /// <summary>
    /// List all the possible operators.
    /// </summary>
    internal enum OperatorType 
    {
        Invalid,    // Invalid operator.
        Add,        // Binary.
        Subtract,   // Binary.
        Multiply,   // Binary.
        Divide,     // Binary.
        Modulo,     // Binary.
        Factorial,  // Unary.
        Pow,        // Binary.
        Root        // Binary.
    }
}
