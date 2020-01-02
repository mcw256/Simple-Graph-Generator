using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace SimpleGraphGenerator.Views.SceneUtils
{
    static class Creators
    {
        public static List<Line> CreateEdgesFromAdjMatrix(int[,] adjMatrix )
        {
            var result = new List<Line>();

            for (int i = 0; i < adjMatrix.GetLength(0); i++)
            {
                for (int j = i + 1; j < adjMatrix.GetLength(1); j++)
                {
                    if(adjMatrix[i,j] > 0)
                    {
                        var line = new Line();
                        line.Name = $"v{i + 1}to{j + 1}";
                        line.Tag = adjMatrix[i, j];
                        result.Add(line);
                    }
                }
            }
            return result;
        }

        public static List<Vertex> CreateVertexes(int n)
        {
            var result = new List<Vertex>();

            for (int i = 0; i < n; i++)
                result.Add(new Vertex());

            return result;
        }

        /// <summary>
        /// Creates 2 ellipses, that will be used as background(setting)
        /// </summary>
        /// <returns></returns>
        public static List<Ellipse> CreateSettingElls()
        {
            var result = new List<Ellipse>();

            for (int i = 0; i < 2; i++)
                result.Add(new Ellipse());
            
            return result;
        }

    }
}
