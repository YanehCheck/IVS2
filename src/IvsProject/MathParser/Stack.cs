using System.Collections;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using MathParser.Enums;

namespace MathParser 
{
    /// <summary>
    /// Stack used for parsing mathematical expressions.
    /// </summary>
    internal class Stack
    {
        /// <summary>
        /// List of <see cref="StackItem"/> 
        /// </summary>
        private List<StackItem> _stack;

        /// <summary>
        /// Creates a new list of <see cref="StackItem"/>.
        /// </summary>
        public Stack()
        {
            _stack = new List<StackItem>();
            _stack.Add(new StackItem("$", 0));
        }

        /// <summary>
        /// Returns the last inserted terminal on the stack.
        /// </summary>
        /// <returns> <see cref="StackItem"/> </returns>
        public StackItem GetLastTerminal()
        {
            for (var i = _stack.Count - 1; i >= 0; i--)
            {
                if (_stack[i].GetItemType() == StackItemType.Terminal)
                {
                    return _stack[i];
                }
            }

            return null!;
        }

        /// <summary>
        /// Returns index of the last inserted terminal on the stack.
        /// </summary>
        /// <returns> <see cref="int"/> </returns>
        public int GetLastTerminalIndex()
        {
            for (var i = _stack.Count - 1; i >= 0; i--)
            {
                if (_stack[i].GetItemType() == StackItemType.Terminal)
                {
                    return i;
                }
            }

            return 0;
        }

        /// <summary>
        /// Insert the new item after the last terminal.
        /// </summary>
        /// <param name="item"> Item to be inserted. </param>
        public void PushAfterLastTerminal(StackItem item)
        {
            _stack.Insert(GetLastTerminalIndex() + 1, item);
        }

        /// <summary>
        /// Inserts a new item at the top of the stack.
        /// </summary>
        /// <param name="item"> Item to be inserted. </param>
        public void Push(StackItem item)
        {
            _stack.Add(item);
        }

        /// <summary>
        /// Removes an element from the top of the stack and returns its.
        /// </summary>
        /// <returns> <see cref="StackItem"/> </returns>
        public StackItem Pop()
        {
            StackItem item = _stack[^1];
            _stack.RemoveAt(_stack.Count - 1);
            return item;
        }

        /// <summary>
        /// Returns the element from the top of the stack.
        /// </summary>
        /// <returns> <see cref="StackItem"/> </returns>
        public StackItem getTop()
        {
            return _stack[^1];
        }

        /// <summary>
        /// Based on the rules, it performs a reduction to an expression.
        /// </summary>
        /// <returns> <see cref="bool"/> Whether the action was successful </returns>
        public bool CreateExpression()
        {
            List<StackItem> items = new List<StackItem>();

            while (getTop().GetItemType() != StackItemType.Nonterminal)
            {
                items.Add(Pop());
            }

            Pop();
            StackItem expression;

            if (items.Count == 1)
            {
                //System.Diagnostics.Debug.WriteLine("RULE 11");
                if (!Regex.Match( Convert.ToString(items[^1].GetSelf()), @"(^[+-]?\d+(?:\.\d+)?(?:[eE][+-]\d+)?$)").Success)
                {
                    return false;
                }
                
                expression = new StackItem("E", 11);
                expression.SetValue(Convert.ToDouble(items[^1].GetSelf().Replace('.', ',')));
            }
            else if (items.Count == 2)
            {
                if (items[^1].GetSelf() == "+")
                {
                    //System.Diagnostics.Debug.WriteLine("RULE 8");
                    expression = new StackItem("E", 8);
                    expression.SetLeft(items[^2]);
                }
                else if (items[^1].GetSelf() == "-")
                {
                    //System.Diagnostics.Debug.WriteLine("RULE 9");
                    expression = new StackItem("E", 9);
                    expression.SetLeft(items[^2]);
                }
                else if (items[^2].GetSelf() == "!")
                {
                    //System.Diagnostics.Debug.WriteLine("RULE 12");
                    expression = new StackItem("E", 12);
                    expression.SetLeft(items[^1]);
                }
                else
                {
                    return false;
                }
            }
            else if (items.Count == 3)
            {
                if (items[^2].GetSelf() == "+")
                {
                    //System.Diagnostics.Debug.WriteLine("RULE 1");
                    expression = new StackItem("E", 1);
                    expression.SetLeft(items[^1]);
                    expression.SetRight(items[^3]);
                }
                else if (items[^2].GetSelf() == "-")
                {
                    //System.Diagnostics.Debug.WriteLine("RULE 2");
                    expression = new StackItem("E", 2);
                    expression.SetLeft(items[^1]);
                    expression.SetRight(items[^3]);
                }
                else if (items[^2].GetSelf() == "*")
                {
                    //System.Diagnostics.Debug.WriteLine("RULE 3");
                    expression = new StackItem("E", 3);
                    expression.SetLeft(items[^1]);
                    expression.SetRight(items[^3]);
                }
                else if (items[^2].GetSelf() == "/")
                {
                    //System.Diagnostics.Debug.WriteLine("RULE 4");
                    expression = new StackItem("E", 4);
                    expression.SetLeft(items[^1]);
                    expression.SetRight(items[^3]);
                }
                else if (items[^2].GetSelf() == "%")
                {
                    //System.Diagnostics.Debug.WriteLine("RULE 5");
                    expression = new StackItem("E", 5);
                    expression.SetLeft(items[^1]);
                    expression.SetRight(items[^3]);
                }
                else if (items[^2].GetSelf() == "^")
                {
                    //System.Diagnostics.Debug.WriteLine("RULE 6");
                    expression = new StackItem("E", 6);
                    expression.SetLeft(items[^1]);
                    expression.SetRight(items[^3]);
                }
                else if (items[^2].GetSelf() == "√")
                {
                    //System.Diagnostics.Debug.WriteLine("RULE 7");
                    expression = new StackItem("E", 7);
                    expression.SetLeft(items[^1]);
                    expression.SetRight(items[^3]);
                }
                else if (items[^1].GetSelf() == "(" && items[^3].GetSelf() == ")")
                {
                    //System.Diagnostics.Debug.WriteLine("RULE 10");
                    expression = new StackItem("E", 10);
                    expression.SetLeft(items[^2]);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            Push(expression);
            return true;
        }

        /// <summary>
        /// Returns the number of items on the stack.
        /// </summary>
        /// <returns> <see cref="int"/> </returns>
        public int GetStackLen()
        {
            return _stack.Count;
        }

    }
}
