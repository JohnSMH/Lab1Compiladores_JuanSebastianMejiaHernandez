using System;
using System.Collections.Generic;
using System.Text;

namespace LabCompiladores
{
    public enum TokenType
    {
        Plus = '+',
        Star = '*',
        Lparen = '(',
        Rparen = ')',
        Minus = '-',
        Div = '/',
        EOF = (char)0,
        Empty = (char)1,
        Null = (char)2,
        Symbol = (char)3,
        Num = (char)4

    }
}
