using System;
using System.Collections.Generic;
using System.Text;

namespace LabCompiladores
{
    public class Parser
    {
        string numerocadena = "";
        Scanner scanner;
        Token token;


        private double E(){
            switch (token.Tag)
            {
                case TokenType.Lparen:
                case TokenType.Num:
                case TokenType.Minus:
                    return T() + EP();
                    break;
                
                default:
                    return 0;
                    break;
            }

        }
        private double EP() {
            switch (token.Tag)
            {

                case TokenType.Plus:
                    Match(TokenType.Plus);
                    return T() + EP();
                    break;
                case TokenType.Minus:
                    Match(TokenType.Minus);
                    return -T() + EP();
                    break;
                default:
                    return 0;
                    break;
            }
        }
        private double L() {
            switch (token.Tag)
            {
                case TokenType.Minus:
                    Match(TokenType.Minus);
                    return -L();
                    break;

                default:
                    return 1;
                    break;
            }
        }
        private double T() {
            switch (token.Tag)
            {

                case TokenType.Lparen:
                case TokenType.Num:
                case TokenType.Minus:
                    return L() * F() * TP();
                    break;

                default:
                    return 0;
                    break;
            }

        }
        private double TP() {
            switch (token.Tag)
            {

                case TokenType.Star:
                    Match(TokenType.Star);
                    return L()*F() * TP();
                    break;
                case TokenType.Div:
                    Match(TokenType.Div);
                    return L() * 1/F()*TP();
                    break;
                default:
                    return 1;
                    break;
            }
        }
        private double F() {
            switch (token.Tag)
            {
                case TokenType.Lparen:
                    Match(TokenType.Lparen);
                    double num = E();
                    Match(TokenType.Rparen);
                    return num;
                    break;
                case TokenType.Num:
                    numerocadena = token.value.ToString();
                    Match(TokenType.Num);
                    return FP();
                    break;
                default:
                    return 0;
                    break;
            }
        }
        private double FP() {
            switch (token.Tag)
            {
                case TokenType.Num:
                    numerocadena += token.value;
                    Match(TokenType.Num);
                    FP();
                    return Convert.ToDouble(numerocadena);
                    break;
                default:
                    return Convert.ToDouble(numerocadena);
                    break;
            }
        }
        private void Match(TokenType tag) {
            if (tag != TokenType.EOF)
            {
                if (token.Tag == tag)
                {
                    token = scanner.GetToken();
                }
                else
                {
                    throw new Exception("Syntax Error");
                }
            }
            else {
                if (token.Tag == tag)
                {
                }
                else
                {
                    throw new Exception("Syntax Error");
                }

            }
            
        }


        public double Parse(string entrada) {
            scanner = new Scanner(entrada);
            double num=0;
            token = scanner.GetToken();

            switch (token.Tag)
            {
                
                case TokenType.Lparen:                   
                case TokenType.Num:                 
                case TokenType.Minus:
                    num=E();
                    break;
                default:
                    break;
            }
            Match(TokenType.EOF);
            return num;
        }
    }
}
