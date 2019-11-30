using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGraphGenerator.BusinessLogic
{
    interface IAdjacentMatrixOperations
    {
        void OperateOn(int[,] adjMatrix);
    }
}
