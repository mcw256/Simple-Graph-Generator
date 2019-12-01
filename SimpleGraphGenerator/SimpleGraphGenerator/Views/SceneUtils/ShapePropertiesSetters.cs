using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SimpleGraphGenerator.Views.SceneUtils
{
    static class ShapesPropertiesSetters
    {
        
        public static void SetSettingEllProperties(Ellipse setEll,int leftX, int bottomY)
        {
            setEll.Width = 400;
            setEll.Height = 400;
            setEll.Stroke = new SolidColorBrush(Colors.Black);
            setEll.StrokeThickness = 3;
            setEll.Opacity = 0.05;

            Canvas.SetLeft(setEll, leftX);
            Canvas.SetBottom(setEll, bottomY);
        }


        public static void SetVertexProperties(Label vertex, int leftX, int bottomY, string name)
        {
            vertex.Style = Application.Current.FindResource("Vertex") as Style;
            vertex.Content = name;

            Canvas.SetLeft(vertex, leftX);
            Canvas.SetBottom(vertex, bottomY);
        }

        public static void SetEdgeProperties(Line edge,int x1, int y1, int x2, int y2)
        {
            edge.X1 = x1;
            edge.Y1 = 750 - y1; //gotta transform origin

            edge.X2 = x2;
            edge.Y2 = 750 - y2;

            edge.Stroke = new SolidColorBrush(Colors.Black);
            edge.StrokeThickness = 3;
            edge.Opacity = 0.85;

        }

    }
}
