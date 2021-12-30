using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drinks_Vending_Machine__.Classes
{
    public class Component_Missing_Exception : Exception
    {
        public Component_Missing_Exception() { }
        public Component_Missing_Exception(string message) : base(message) { }
        public Component_Missing_Exception(string message, Exception inner) : base(message, inner) { }
    }
}
