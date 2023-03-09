using System.Linq.Expressions;
using System.Text.RegularExpressions;
using MathParser.Enums;

namespace MathParser {
    /// <summary>
    /// Item that may be on the stack.
    /// </summary>
    internal class StackItem
    {
        /// <summary>
        /// The rule to use when evaluating the expression.
        /// </summary>
        private int Rule { get; }
        /// <summary>
        /// A string representing an item.
        /// </summary>
        private string Item { get; }
        /// <summary>
        /// Numeric value representing an item.
        /// </summary>
        private double Value { get; set; }
        /// <summary>
        /// Left child.
        /// </summary>
        private StackItem? Left { get; set; }
        /// <summary>
        /// Right child.
        /// </summary>
        private StackItem? Right { get; set; }
        /// <summary>
        /// Item type.
        /// </summary>
        private StackItemType Type { get; }
        /// <summary>
        /// Terminal type.
        /// </summary>
        private TerminalType TerminalType { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="StackItem"/>.
        /// </summary>
        /// <param name="item"> A string representing an item on the stack. </param>
        /// <param name="rule"> The rule to use when evaluating the expression. </param>
        public StackItem(string item, int rule)
        {
            Item = item;
            Rule = rule;
            Left = null!;
            Right = null!;
            string[] terminals = { "$", "+", "-", "*", "/", "(", ")", "%", "^", "√", "!" };
            string[] nonterminals = { ">", "<", "=" };
            if (Regex.Match(item, @"(^[+-]?\d+(?:\.\d+)?(?:[eE][+-]\d+)?$)").Success)
            {
                Type = StackItemType.Terminal;
                TerminalType = TerminalType.Operand;
            }
            else if (terminals.Contains(Item))
            {
                Type = StackItemType.Terminal;
                TerminalType = TerminalType.Else;
            }
            else if (nonterminals.Contains(Item))
            {
                Type = StackItemType.Nonterminal;
                TerminalType = TerminalType.Else;
            }
            else
            {
                Type = StackItemType.Expression;
                TerminalType = TerminalType.Expression;
            }
        }

        /// <summary>
        /// Adds the left child.
        /// </summary>
        /// <param name="left"> Left child. </param>
        public void SetLeft(StackItem left)
        {
            Left = left;
        }

        /// <summary>
        /// Adds the right child.
        /// </summary>
        /// <param name="right"> Right child. </param>
        public void SetRight(StackItem right)
        {
            Right = right;
        }

        /// <summary>
        /// Returns the left child.
        /// </summary>
        /// <returns> <see cref="StackItem"/> </returns>
        public StackItem GetLeft()
        {
            return Left;
        }

        /// <summary>
        /// Returns the right child.
        /// </summary>
        /// <returns> <see cref="StackItem"/> </returns>
        public StackItem GetRight()
        {
            return Right;
        }

        /// <summary>
        /// Stores a numeric value representing an item.
        /// </summary>
        /// <param name="value"></param>
        public void SetValue(double value)
        {
            Value = value;
        }

        /// <summary>
        /// Returns numeric value representing an item.
        /// </summary>
        /// <returns> <see cref="double"/> </returns>
        public double GetValue()
        {
            return Value;
        }

        /// <summary>
        /// Returns the rule to be used to evaluate the expression.
        /// </summary>
        /// <returns> <see cref="int"/> </returns>
        public int GetRule()
        {
            return Rule;
        }

        /// <summary>
        /// Returns a string representing the item.
        /// </summary>
        /// <returns> <see cref="string"/> </returns>
        public string GetSelf()
        {
            return Item;
        }

        /// <summary>
        /// Returns the item type.
        /// </summary>
        /// <returns> <see cref="StackItemType"/> </returns>
        public StackItemType GetItemType()
        {
            return Type;
        }

        /// <summary>
        /// Returns the terminal type.
        /// </summary>
        /// <returns> <see cref="Enums.TerminalType"/> </returns>
        public TerminalType GeTerminalType()
        {
            return TerminalType;
        }

    }
}
