using System.Data;
using System.Linq.Expressions;
using MathParser.Enums;

namespace MathParser 
{
    /// <summary>
    /// Parser of mathematical expressions.
    /// </summary>
    public class Parser
    {
        private List<string> _result;

        /// <summary>
        /// Returns a non-terminal character from the precedent table based on the terminal on the stack and the input token.
        /// </summary>
        /// <param name="terminal"> Last terminal on the stack. </param>
        /// <param name="input"> Input token obtained by the GetNextToken() function </param>
        /// <returns> <see cref="string"/> </returns>
        private string GetPrecedenceChar(StackItem terminal, StackItem input)
        {
            string terminals = "^√*/+-%()i$!";
            int row = terminal.GeTerminalType() == TerminalType.Operand ? 9 : terminals.IndexOf(Convert.ToChar(terminal.GetSelf()));
            int col = input.GeTerminalType() == TerminalType.Operand ? 9 : terminals.IndexOf(Convert.ToChar(input.GetSelf()));

            string[,] PrecTable =
            {
                { "<", "<", ">", ">", ">", ">", "<", "<", ">", "<", ">", "<" },
                { "<", "<", ">", ">", ">", ">", "<", "<", ">", "<", ">", "<" },
                { "<", "<", ">", ">", ">", ">", "<", "<", ">", "<", ">", "<" },
                { "<", "<", ">", ">", ">", ">", "<", "<", ">", "<", ">", "<" },
                { "<", "<", "<", "<", ">", ">", "<", "<", ">", "<", ">", "<" },
                { "<", "<", "<", "<", ">", ">", "<", "<", ">", "<", ">", "<" },
                { "<", "<", ">", ">", ">", ">", "<", "<", ">", "<", ">", "<" },
                { "<", "<", "<", "<", "<", "<", "<", "<", "=", "<", " ", "<" },
                { ">", ">", ">", ">", ">", ">", ">", " ", ">", " ", ">", ">" },
                { ">", ">", ">", ">", ">", ">", ">", " ", ">", " ", ">", ">" },
                { "<", "<", "<", "<", "<", "<", "<", "<", "<", "<", " ", "<" },
                { ">", ">", ">", ">", ">", ">", ">", "<", ">", "<", ">", ">" }
            };

            return PrecTable[row, col];
        }

        /// <summary>
        /// Converts specified mathematical expression to reverse polish form.
        /// </summary>
        /// <param name="expression"> Mathematical expression. </param>
        /// <returns> <see cref="ParseResult"/> </returns>
        public ParseResult Parse(string expression) 
        {
            _result = new List<string>();
            var _error = false;
            var stack = new Stack();
            var scanner = new Scanner(expression);


            while (true)
            {
                string token = scanner.GetNextToken();

                if (token == "_")
                {
                    _error = true;
                    break;
                }

                var terminal = stack.GetLastTerminal();
                var input = new StackItem(token, 0);

                if (terminal.GetSelf() == "$" && input.GetSelf() == "$")
                {
                    break;
                }

                string precChar = GetPrecedenceChar(terminal, input);

                if (precChar == "=")
                {
                    stack.Push(input);
                }
                else if (precChar == "<")
                {
                    stack.PushAfterLastTerminal(new StackItem("<", 0));
                    stack.Push(input);
                }
                else if (precChar == ">")
                {
                    if (!stack.CreateExpression())
                    {
                        _error = true;
                        break;
                    }
                    scanner.PutLastTokenBack();
                }
                else
                {
                    _error = true;
                    break;
                }
            }

            if (_error)
            {
                return new ParseResult(_result, true);
            }
            if (stack.GetStackLen() < 2)
            {
                return new ParseResult(_result, true);
            }
            InvPostOrder(stack.Pop());
            return new ParseResult(_result, false);
        }

        /// <summary>
        /// Performs a recursive pass using the Inverse PostOrder method and
        /// creates a reverse polish form from the expression tree based on the rules.
        /// </summary>
        /// <param name="e"> <see cref="StackItem"/> Root of tree. </param>
        private void InvPostOrder (StackItem? e)
        {
            if (e == null) return;

            InvPostOrder(e.GetRight());
            InvPostOrder(e.GetLeft());

            if (e.GetRule() == 1)
            {
                _result.Add("+");
            }
            else if (e.GetRule() == 2)
            {
                _result.Add("-");
            }
            else if (e.GetRule() == 3)
            {
                _result.Add("*");
            }
            else if (e.GetRule() == 4)
            {
                _result.Add("/");
            }
            else if (e.GetRule() == 5)
            {
                _result.Add("%");
            }
            else if (e.GetRule() == 6)
            {
                _result.Add("^");
            }
            else if (e.GetRule() == 7)
            {
                _result.Add("√");
            }
            else if (e.GetRule() == 8)
            {
                _result.Add("1");
                _result.Add("*");
            }
            else if (e.GetRule() == 9)
            {
                _result.Add("-1");
                _result.Add("*");
            }
            else if (e.GetRule() == 11)
            {
                _result.Add(Convert.ToString(e.GetValue()).Replace(",", "."));
            }
            else if (e.GetRule() == 12)
            {
                _result.Add("!");
            }
        }

    }
}