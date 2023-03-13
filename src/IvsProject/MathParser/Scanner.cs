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
        private readonly string _expression;
        /// <summary>
        /// The current position in the input expression.
        /// Then the current position in the token list.
        /// </summary>
        private int _position;
        /// <summary>
        /// Tokens list.
        /// </summary>
        private List<string> _tokens;
        /// <summary>
        /// Determines if $ has already been returned.
        /// </summary>
        private bool _dollarReturned;
        /// <summary>
        /// Determines if expression was empty.
        /// </summary>
        private bool _emptyExpression;

        /// <summary>
        /// Initializes a new instance of <see cref="Scanner"/>.
        /// </summary>
        /// <param name="expression"></param>
        public Scanner(string expression)
        {
            _position = 0;
            _dollarReturned = false;
            _emptyExpression = false;
            _tokens = new List<string>(); ;
            _expression = expression;

            var token = ScannToken();

            while (token != "$")
            {
                if (token == "_")
                {
                    _tokens = new List<string>();
                    return;
                }
                _tokens.Add(token);
                token = ScannToken();
            }

            if (_tokens.Count == 0)
            {
                _emptyExpression = true;
            }
            else
            {
                _position = 0;
                _tokens = MergeTokens(_tokens);
            }
        }

        /// <summary>
        /// Returns the following token from <see cref="_expression"/>.
        /// </summary>
        /// <returns> <see cref="string"/> </returns>
        private string ScannToken()
        {
            while (_position < _expression.Length)
            {
                var match = Regex.Match(_expression.Substring(_position), @"^\s*(\d+(?:\.\d+)?)");
                if (match.Success)
                {
                    _position += match.Length;
                    return match.Groups[1].ToString();
                }

                match = Regex.Match(_expression.Substring(_position), @"^\s*(\^|√|\*|/|\+|-|%|\(|\)|!)");
                if (match.Success)
                {
                    _position += match.Length;
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
                else if (token == "!")
                {
                    tokensType.Add("FA");
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
            if (_emptyExpression)
            {
                return "_";
            }

            if (_dollarReturned)
            {
                return "$";
            }

            if (_position < _tokens.Count)
            {
                return _tokens[_position++];
            }

            _dollarReturned = true;
            return "$";
        }

        /// <summary>
        /// Returns the position of the token list back by 1.
        /// </summary>
        public void PutLastTokenBack()
        {
            if (_position > 0)
            {
                _position--;
            }
        }

    }
}
