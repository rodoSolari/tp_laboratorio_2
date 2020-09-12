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
                    resultado = num1 * num2;
                    break;
                case "/":
                    resultado = num1 / num2;
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


        public string BinarioDecimal(string binario)
        {
            string resultado = "Valor invalido";
            int valorDecimal = 0;
            if (esBinario(binario))
            {
                foreach (int i in binario)
                {
                    if (binario[i] == '1')
                    {
                        if (i == 0)
                        {
                            valorDecimal++;
                        }
                        else
                        {
                            valorDecimal += Convert.ToInt32(Math.Pow(2, i));
                        }
                    }
                }
                resultado = Convert.ToString(valorDecimal);
            }
            return resultado;
        }

        public string DecimalBinario(double numero)
        {
            return Convert.ToString(numero);
        }

        public string DecimalBinario(string numero)
        {
            string valorBinario = "Valor invalido";
            
            //Convierto el numero recibido en entero
            int valor = Convert.ToInt32(numero);

            //Convierto el valor entero en string con base 2
            valorBinario = Convert.ToString(valor, 2);

            return valorBinario;
        }

        private static bool esBinario(string binario)
        {
            bool esBinario = false;
            foreach (char caracter in binario)
            {
                if(binario[caracter] != '1' || binario[caracter] != '0')
                {
                    break;
                }
                else
                {
                    esBinario = true;
                }
            }
            return esBinario;
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
            double resultado;
            if (n2.numero == 0)
            {
                resultado = double.MinValue;
            }
            else
            {
                resultado = n1.numero / n2.numero;
            }
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
