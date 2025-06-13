using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ClassDesign
{
    public class InvalidProductException : Exception
    {  
        public InvalidProductException(string message) : base(message)
        {
            
        }
    }
}
