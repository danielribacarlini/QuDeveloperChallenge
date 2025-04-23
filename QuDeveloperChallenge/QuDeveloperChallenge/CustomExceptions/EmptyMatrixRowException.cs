using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuDeveloperChallenge.CustomExceptions
{
    public class EmptyMatrixRowException : Exception
    {
        public EmptyMatrixRowException(string message) : base(message)
        {

        }
    }
}
