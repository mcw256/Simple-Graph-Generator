using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGraphGenerator.BusinessLogic
{
    static class AdjacentMatrix
    {
        /// <summary>
        /// Creates nxn int matrix
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int[,] Create(int n) => new int[n, n];

        /// <summary>
        /// Fills left-boottom half of the matrix in the realtion to the other half(right-top).
        /// </summary>
        /// <param name="adjMatrix"></param>
        public static void FillLeftBottomHalf(int[,] adjMatrix)
        {
            for (int i = 0; i < adjMatrix.GetLength(0); i++)//rows
            {
                for (int j = i + 1; j < adjMatrix.GetLength(1); j++) //colums
                {
                    adjMatrix[j, i] = adjMatrix[i, j];
                }
            }
        }

        public static void FillDiagonalWithZeros(int[,] adjMatrix)
        {
            for (int i = 0; i < adjMatrix.GetLength(0); i++)
                adjMatrix[i, i] = 0;
        }

        /// <summary>
        /// Fills top-right half of the matrix with given probability of each element being 1
        /// </summary>
        /// <param name="adjMatrix"></param>
        public static void FillWithGivenProbability(int[,] adjMatrix, double prob)
        {
            if (prob < 0 || prob > 1) throw new ArgumentException("probability must be in the range [0,1]");
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 0; i < adjMatrix.GetLength(0); i++) //rows
            {
                for (int j = i + 1; j < adjMatrix.GetLength(1); j++) //columns
                {
                    if (rand.NextDouble() < prob)
                        adjMatrix[i, j] = 1;
                    else
                        adjMatrix[i, j] = 0;
                }
            }
        }

    }
}
