using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGraphGenerator.BusinessLogic.Algorithms
{

    class ConnectivityChecker
    {
        int[,] _adjMatrix;
        int N;
        bool[] _isVisited;

        public ConnectivityChecker(int[,] adjMatrix)
        {
            N = adjMatrix.GetLength(0);
            _adjMatrix = adjMatrix;
            _isVisited = new bool[N];
        }

        public bool IsConnected()
        {
            TravelAndMark(0);
            foreach (var item in _isVisited)
                if (item == false) return false;

            return true;
        }

        void TravelAndMark(int s)
        {
            _isVisited[s] = true;

            for (int j = 0; j < N; j++)
            {
                if ((_adjMatrix[s, j] != 0) && (_isVisited[j] == false))
                    TravelAndMark(j);
            }
        }

    }
}
