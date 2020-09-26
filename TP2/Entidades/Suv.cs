﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    
    public class Suv
    {
        public Suv(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
        }
        /// <summary>
        /// Las camionetas son grandes
        /// </summary>
        protected override short Tamanio
        {
            get
            {
                return 0;
            }
        }

        public override sealed StringBuilder Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SUV");
            sb.AppendLine(base);
            sb.AppendLine("TAMAÑO : {0}", this.Tamanio);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb;
        }
    }
}