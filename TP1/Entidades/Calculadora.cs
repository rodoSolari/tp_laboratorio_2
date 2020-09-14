using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            string operadorVerificado;
            double resultado = 0;
            //Para verificar si se ingresa un solo caracter
            if(operador.Length<=1 && !string.IsNullOrEmpty(operador))
            {
                operadorVerificado = ValidarOperador(Convert.ToChar(operador));
                switch (operadorVerificado)
                {
                    case "-":
                        resultado = num1 - num2;
                        break;
                    case "+":
                        resultado = num1 + num2;
                        break;
                    case "*":
                        resultado = num1 * num2;
                        break;
                    case "/":
                        resultado = num1 / num2;
                        break;
                    default:
                        resultado = 0;
                        break;
                }
            } 
            return resultado;
        }

        private static string ValidarOperador(char operador)
        {
            if (operador == '-' || operador == '/' || operador == '*' || operador == '+')
            {
                return Convert.ToString(operador);
            }
            else
            {
                return "+";
            }
        }
    }
}
