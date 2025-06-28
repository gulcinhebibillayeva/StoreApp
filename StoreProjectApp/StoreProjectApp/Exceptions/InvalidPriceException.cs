using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreProjectApp.Exceptions
{
    public class InvalidPriceException : Exception
    {
        public InvalidPriceException() : base("Inccorect Price") { }

    }
}
