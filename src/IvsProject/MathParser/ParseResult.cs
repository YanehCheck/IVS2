namespace MathParser 
{
    /// <summary>
    /// The result of parsing by <see cref="Parser"/> class.
    /// Holds the resulting expression (<see cref="Expression"/>) and if syntax error (<see cref="SyntaxError"/>) occurred.
    /// </summary>
    public record ParseResult 
    {
        /// <summary>
        /// Parsed expression in reverse polish notation.
        /// </summary>
        public List<string> Expression { get; init; }
        /// <summary>
        /// Indicates if there was an error in the input expression.
        /// </summary>
        public bool SyntaxError { get; init; }

        /// <summary>
        /// Initializes a new instance of <see cref="ParseResult"/>.
        /// </summary>
        /// <param name="expression"> Indicates if there was an error in the input expression. </param>
        /// <param name="syntaxError"> Parsed expression in reverse polish notation. </param>
        public ParseResult(List<string> expression, bool syntaxError) 
        {
            Expression = expression;
            SyntaxError = syntaxError;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ParseResult"/> record with an empty <see cref="Expression"/>.
        /// </summary>
        /// <param name="syntaxError"> Indicates if there was an error in the input expression. </param>
        public ParseResult(bool syntaxError) 
        {
            Expression = new List<string>();
            SyntaxError = syntaxError;
        }
    }
}
