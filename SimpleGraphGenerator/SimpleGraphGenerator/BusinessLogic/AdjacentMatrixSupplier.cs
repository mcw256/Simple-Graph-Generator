using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGraphGenerator.BusinessLogic
{
    static class AdjacentMatrixSupplier
    {
        public static int[,] Supply(uint n) => new int[n, n];
    }
}
