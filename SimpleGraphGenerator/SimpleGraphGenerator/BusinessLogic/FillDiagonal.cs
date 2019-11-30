using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGraphGenerator.BusinessLogic
{
    //Fills diagonal of the Adjacent Matrix with 0s
    class FillDiagonal : IAdjacentMatrixOperations
    {
        public void OperateOn(int[,] adjMatrix)
        {
            for (int i = 0; i < adjMatrix.Length; i++)
                adjMatrix[i, i] = 0;
        }
    }
}
