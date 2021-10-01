using System;
using System.Collections.Generic;
using System.Text;

namespace LabCompiladores
{
    public class Scanner
    {
        private const char EOF = (char)0;
        private string  entrada="";
        private int index = 0;
        private int estado;
        public Scanner(string cadena) {
            entrada = cadena+(char)TokenType.EOF;
            index = 0;
            estado = 0;
        }

        public Token GetToken() {
            Token result = new Token() {value = (char)0 };
            bool TokenFound = false;
            while (!TokenFound) {
                char peek = entrada[index];
                switch (estado) {
                    case 0:
                        while (char.IsWhiteSpace(peek))
                        {
                            index++;
                            peek = entrada[index];
                        }
                            switch (peek)
                            {
                            case '0':
                            case '1':
                            case '2':
                            case '3':
                            case '4':
                            case '5':
                            case '6':
                            case '7':
                            case '8':
                            case '9':
                                TokenFound = true;
                                result.Tag = TokenType.Num;
                                result.value = peek;
                                break;
                            case (char)TokenType.Minus:
                            case (char)TokenType.Div:
                            case (char)TokenType.Lparen:
                            case (char)TokenType.Rparen:
                            case (char)TokenType.Plus:
                            case (char)TokenType.Star:
                            case (char)TokenType.EOF:
                                    TokenFound = true;
                                    result.Tag = (TokenType)peek;
                                    break;
                            default:
                                    TokenFound = true;
                                    result.Tag = TokenType.Symbol;
                                    result.value = peek;
                                    break;
                            }
                        break;
                    default:
                        break;
                
                }
                index++;
            
            }
            estado = 0;
            return result;
            
        }
    }
}
