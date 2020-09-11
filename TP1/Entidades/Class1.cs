using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        double Operar(Numero num1, Numero num2, string operador) {
            double resultado = 0;
            return resultado;
        }

        string ValidarOperador(char operador) {
            return "hola";
        }
    }

    public class Numero 
    {

        private double numero;

        public string SetNumero
        {
            set { this.numero = ValidarNumero(value); }
        }

        public Numero()
        {
            numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string strNumero)
        {
            
        }

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

        public static bool esBinario(string binario) {
            return true;
        }

        public static double operator -(Numero n1,Numero n2) {
            double resultado = 0;
            return resultado;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            double resultado = 0;
            return resultado;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            double resultado = 0;
            return resultado;
        }

        public static double operator +(Numero n1, Numero n2)
        {
            double resultado = 0;
            return resultado;
        }

        public static double ValidarNumero(string numero) {
            return 0;
            
        }

    }
}
