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

            for (int i = 0; i < adjMatrix.Length; i++)
            {
                for (int j = i + 1; j < adjMatrix.Length; j++)
                {
                    var line = new Line();
                    line.Name = $"{i + 1}to{j + 1}";
                    result.Add(line);
                }
            }
            return result;
        }

        public static List<Label> CreateVertexes(int n)
        {
            var result = new List<Label>();

            for (int i = 0; i < n; i++)
                result.Add(new Label());

            return result;
        }

        public static List<Ellipse> CreateSettingElls()
        {
            var result = new List<Ellipse>();

            for (int i = 0; i < 2; i++)
                result.Add(new Ellipse());
            
            return result;
        }

    }
}
