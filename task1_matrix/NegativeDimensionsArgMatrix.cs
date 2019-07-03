using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1_matrix
{
    public class NegativeDimensionsArgMatrix : Exception
    {
        public NegativeDimensionsArgMatrix(string message) : base(message) { }
    }
}
