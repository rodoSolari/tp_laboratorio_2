﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        public DniInvalidoException() : base("Dni invalido por error de formato")
        {

        }

        public DniInvalidoException(string message) : base(message)
        {

        }
    }
}
