using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGraphGenerator.BusinessLogic
{
    /// <summary>
    /// Fills top half of the adjacent matrix 0 or 1, with given probability
    /// </summary>
    class FillWithGivenProb : IAdjacentMatrixOperations
    {
        double _prob;
        public FillWithGivenProb(double prob) => _prob = prob;

        public void OperateOn(int[,] adjMatrix)
        {
            int fuck = adjMatrix.GetLength(0);
            int fuckmehard = adjMatrix.GetLength(1);

            Random rand = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 0; i < adjMatrix.GetLength(0); i++) //rows
            {
                for (int j = i+1; j < adjMatrix.GetLength(1); j++) //columns
                {
                    if (rand.NextDouble() < _prob)
                        adjMatrix[i, j] = 1;
                    else
                        adjMatrix[i, j] = 0;
                }
            }
        }
    }
}
