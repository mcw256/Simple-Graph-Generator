using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SimpleGraphGenerator.BusinessLogic.Algorithms
{
    class DijkstraShortestPath
    {
        class Node
        {
            public Node(int id, int distance, int pathvia)
            {
                Id = id;
                Distance = distance;
                PathVia = pathvia;
            }

            public int Id { get; set; }
            public int Distance { get; set; }
            public int PathVia { get; set; }
        }

        List<Node> _nodes;
        List<Node> _serachedNodes;
        int[,] _adjMatrix;
        int N;

        public DijkstraShortestPath(int[,] adjMatrix)
        {
            _adjMatrix = adjMatrix;
            N = adjMatrix.GetLength(0);
            _nodes = new List<Node>();
            for (int i = 0; i < N; i++)
                _nodes.Add(new Node(i, int.MaxValue, -1));

            _serachedNodes = new List<Node>();
        }

        public List<Vector> ShortestPath(int beg, int end)
        {
            var result = new List<Vector>();
            _nodes[beg - 1].Distance = 0;
            Search(beg - 1);

            var e = _serachedNodes.First(x => x.Id == (end - 1));
            do
            {
                result.Add(new Vector(e.PathVia, e.Id));
                e = _serachedNodes.First(x => x.Id == e.PathVia);
            } while (e.Id != (beg - 1));

            return result;
        }

        private void Search(int s)
        {
            var startingNode = _nodes.First(x => x.Id == s);
            for (int i = 0; i < N; i++)
            {
                if (_adjMatrix[s, i] != 0)
                {
                    if (_nodes.Exists(x => x.Id == i))
                    {
                        var currentNode = _nodes.First(x => x.Id == i);
                        if ((startingNode.Distance + _adjMatrix[s, i]) < currentNode.Distance)
                        {
                            currentNode.Distance = startingNode.Distance + _adjMatrix[s, i];
                            currentNode.PathVia = startingNode.Id;
                        }
                    }
                }
            }
            _serachedNodes.Add(startingNode);
            _nodes.Remove(startingNode);
            if (_nodes.Count <= 0)
                return;
            else
            {
                _nodes = _nodes.OrderBy(x => x.Distance).ToList();
                Search(_nodes[0].Id);
            }

        }


    }
}
