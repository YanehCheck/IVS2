using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser.Enums
{
    internal enum StackItemType
    {
        Dollar,
        Operand,
        Add,
        Sub,
        Mul,
        Div,
        LeftBracket,
        RightBracket,
        Mod,
        Pow,
        Root,
        Expression,
        Factorial
    }
}
