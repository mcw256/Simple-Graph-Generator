using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace SimpleGraphGenerator.Views.SceneUtils
{
    static class MyExtensionMethods
    {
        public static Point GetCenter(this Ellipse ellipse)
        {
            var result = new Point();

            result.X = Canvas.GetLeft(ellipse) + (ellipse.Width / 2);
            result.Y = Canvas.GetBottom(ellipse) + (ellipse.Height / 2);

            return result;
        }

        public static Point GetCenter(this Vertex vertex)
        {
            var result = new Point();

            result.X = Canvas.GetLeft(vertex) + (vertex.Width / 2);
            result.Y = Canvas.GetBottom(vertex) + (vertex.Height / 2);

            return result;
        }

        public static int GetRadius(this Ellipse ellipse)
        {
            int result = (int)(ellipse.Width/2);

            return result; 
        }
    }
}
