using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1_matrix
{
    public class MatrixDimensionExeption : Exception
    {

        public MatrixDimensionExeption(string message) : base(message) { }
    }
}
