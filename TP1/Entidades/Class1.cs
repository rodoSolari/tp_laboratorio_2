using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            string operadorVerificado = ValidarOperador(Convert.ToChar(operador));
            double resultado = 0;
            switch (operadorVerificado)
            {
                case "-":
                    resultado = num1 - num2;
                    break;
                case "+":
                    resultado = num1 + num2;
                    break;
                case "*":
                    resultado = num1 / num2;
                    break;
                case "/":
                    resultado = num1 * num2;
                    break;
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

    public class Numero
    {
        #region Atributo
        private double numero;

        public string SetNumero
        {
            set { this.numero = ValidarNumero(value); }
        }
        #endregion

        #region Constructores
        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string strNumero)
        {
            this.numero = Convert.ToDouble(strNumero);
        }
        #endregion


        public static string BinarioDecimal(string binario)
        {
            string resultado = "";
            return resultado;
        }

        public static string DecimalBinario(double numero)
        {
            string resultado = "";
            return resultado;
        }

        public static string DecimalBinario(string numero)
        {
            string resultado = "";
            return resultado;
        }

        public static bool esBinario(string binario)
        {
            return true;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            double resultado = n1.numero - n2.numero;

            return resultado;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            double resultado = n1.numero * n2.numero;
            
            return resultado;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            double resultado = n1.numero / n2.numero;

            return resultado;
        }

        public static double operator +(Numero n1, Numero n2)
        {
            double resultado = n1.numero + n2.numero;

            return resultado;
        }

        public static double ValidarNumero(string numero)
        {
            double numeroVerificado;
            if (double.TryParse(numero, out numeroVerificado)){
                return Convert.ToDouble(numero);
            }
            return 0;

        }
      
    }
}
