using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGraphGenerator.BusinessLogic
{
    /// <summary>
    /// Mirrors top half of the adjacent matrix to the bottom half
    /// </summary>
    class FillBottomHalf : IAdjacentMatrixOperations
    {
        public void OperateOn(int[,] adjMatrix)
        {
            for (int i = 0; i < adjMatrix.GetLength(0); i++)//rows
            {
                for (int j = i + 1; j < adjMatrix.GetLength(1); j++) //colums
                {
                    adjMatrix[j, i] = adjMatrix[i, j];
                }
            }
        }
    }
}
