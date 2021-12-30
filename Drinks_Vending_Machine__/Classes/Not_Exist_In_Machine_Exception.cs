using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drinks_Vending_Machine__.Classes
{
    public class Not_Exist_In_Machine_Exception : Exception
    {
        public Not_Exist_In_Machine_Exception() { }
        public Not_Exist_In_Machine_Exception(string message) : base(message) { }
        public Not_Exist_In_Machine_Exception(string message, Exception inner) : base(message, inner) { }
    }
}
