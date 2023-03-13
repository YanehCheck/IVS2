using System.Collections;
using System.Text.RegularExpressions;

namespace MathParser 
{
    /// <summary>
    /// A class for splitting the input expression into individual tokens.
    /// </summary>
    internal class Scanner
    {
        /// <summary>
        /// A string representation of a mathematical expression.
        /// </summary>
        private readonly string expression;
        /// <summary>
        /// The current position in the input expression.
        /// Then the current position in the token list.
        /// </summary>
        private int position;
        /// <summary>
        /// Tokens list.
        /// </summary>
        private readonly List<string> tokens;
        /// <summary>
        /// Determines if $ has already been returned.
        /// </summary>
        private bool dollarReturned;
        /// <summary>
        /// Determines if expression was empty.
        /// </summary>
        private readonly bool emptyExpression;

        /// <summary>
        /// Initializes a new instance of <see cref="Scanner"/>.
        /// </summary>
        /// <param name="expression"></param>
        public Scanner(string expression)
        {
            position = 0;
            dollarReturned = false;
            emptyExpression = false;
            tokens = new List<string>();
            this.expression = expression;

            var token = ScanToken();

            while (token != "$")
            {
                if (token == "_")
                {
                    tokens = new List<string>();
                    return;
                }
                tokens.Add(token);
                token = ScanToken();
            }

            if (tokens.Count == 0)
            {
                emptyExpression = true;
            }
            else
            {
                position = 0;
                tokens = MergeTokens(tokens);
            }
        }

        /// <summary>
        /// Returns the following token from <see cref="expression"/>.
        /// </summary>
        /// <returns> <see cref="string"/> </returns>
        private string ScanToken()
        {
            while (position < expression.Length)
            {
                var match = Regex.Match(expression.Substring(position), @"^\s*(\d+(?:\.\d+)?)");
                if (match.Success)
                {
                    position += match.Length;
                    return match.Groups[1].ToString();
                }

                match = Regex.Match(expression.Substring(position), @"^\s*(\^|√|\*|/|\+|-|%|\(|\)|!)");
                if (match.Success)
                {
                    position += match.Length;
                    return match.Groups[1].ToString();
                }

                return "_";
            }

            return "$";
        }

        /// <summary>
        /// Returns an array of token types of the same size as input list.
        /// </summary>
        /// <param name="tokens"> List of tokens. </param>
        /// <returns> <see cref="List{T}"/> T is <see cref="string"/>. </returns>
        private List<string> GetTokensType(List<string> tokens)
        {
            var tokensType = new List<string>();

            foreach (var token in tokens)
            {
                if (token is "^" or "√" or "*" or "/" or "%")
                {
                    tokensType.Add("OP");
                }
                else if (token is "+" or "-")
                {
                    tokensType.Add("PM");
                }
                else if (token == "(")
                {
                    tokensType.Add("LB");
                }
                else if (Regex.Match(token, @"\s*(\d+(?:\.\d+)?)").Success)
                {
                    tokensType.Add("NU");
                }
                else
                {
                    tokensType.Add("ELSE");
                }
            }

            return tokensType;
        }

        /// <summary>
        /// Makes the following adjustments: <br/>
        /// [ "-", "5", "+", "5" ] => [ "-5", "+", 5" ] <br/>
        /// [ "(", "-", "5", ")" ] => [ "(", "-5", ")" ] <br/>
        /// [ "5", "*", "-", "5" ] => [ "5", "*", "-5" ] <br/>
        /// And similar cases.
        /// </summary>
        /// <param name="tokens"></param>
        /// <returns> Modified token list  <see cref="List{T}"/> T is <see cref="string"/>. </returns>
        private List<string> MergeTokens(List<string> tokens)
        {
            var tokensType = GetTokensType(tokens);

            if (tokens.Count == 2)
            {
                if (tokensType[0]! == "PM" && tokensType[1]! == "NU")
                {
                    tokens[0] = string.Concat(tokens[0], tokens[1]);
                    tokens.RemoveAt(1);
                    tokensType.RemoveAt(1);
                }
            }
            else if (tokens.Count > 2)
            {
                if (tokensType[0]! == "PM" && tokensType[1]! == "NU" && tokensType[2]! != "FA")
                {
                    tokens[0] = string.Concat(tokens[0], tokens[1]);
                    tokens.RemoveAt(1);
                    tokensType.RemoveAt(1);
                }
            }

            for (var i = 0; i < tokens.Count - 2; i++)
            {
                if (tokensType[i]! == "OP" && tokensType[i + 1]! == "PM" && tokensType[i + 2]! == "NU")
                {
                    tokens[i + 1] = string.Concat(tokens[i + 1], tokens[i + 2]);
                    tokens.RemoveAt(i + 2);
                    tokensType.RemoveAt(i + 2);
                }
                else if (tokensType[i]! == "LB" && tokensType[i + 1]! == "PM" && tokensType[i + 2]! == "NU")
                {
                    tokens[i + 1] = string.Concat(tokens[i + 1], tokens[i + 2]);
                    tokens.RemoveAt(i + 2);
                    tokensType.RemoveAt(i + 2);
                }
            }
            return tokens;
        }

        /// <summary>
        /// Returns the next token if there are any. If there are no more tokens, it returns "$". <br/>
        /// If "$" has already been returned, then it always returns a dollar regardless of <seealso cref="PutLastTokenBack"/>
        /// </summary>
        /// <returns> <see cref="string"/> </returns>
        public string GetNextToken()
        {
            if (emptyExpression)
            {
                return "_";
            }

            if (dollarReturned)
            {
                return "$";
            }

            if (position < tokens.Count)
            {
                return tokens[position++];
            }

            dollarReturned = true;
            return "$";
        }

        /// <summary>
        /// Returns the position of the token list back by 1.
        /// </summary>
        public void PutLastTokenBack()
        {
            if (position > 0)
            {
                position--;
            }
        }

    }
}
