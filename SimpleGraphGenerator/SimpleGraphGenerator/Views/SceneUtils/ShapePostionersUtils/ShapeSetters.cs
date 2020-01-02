using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SimpleGraphGenerator.Views.SceneUtils.ShapePositionersUtils
{
    /// <summary>
    /// Contains methods, for setting properties of Shapes
    /// </summary>
    static class ShapesSetters
    {
        /// <summary>
        /// Sets background ellipse width, height, stroek, and opacity
        /// </summary>
        /// <param name="setEll"></param>
        /// <param name="leftX"></param>
        /// <param name="bottomY"></param>
        public static void SetSettingEllProperties(Ellipse setEll, int leftX, int bottomY)
        {
            setEll.Width = 400;
            setEll.Height = 400;
            setEll.Stroke = new SolidColorBrush(Colors.Black);
            setEll.StrokeThickness = 3;
            setEll.Opacity = 0.05;

            Canvas.SetLeft(setEll, leftX);
            Canvas.SetBottom(setEll, bottomY);
        }

        /// <summary>
        /// Sets Vertex style, content, name, x, y
        /// </summary>
        /// <param name="vertex"></param>
        /// <param name="leftX"></param>
        /// <param name="bottomY"></param>
        /// <param name="name"></param>
        public static void SetVertexProperties(Vertex vertex, int leftX, int bottomY, string name)
        {
            vertex.Style = Application.Current.FindResource("Vertex") as Style;
            vertex.Content = name;
            vertex.Name = $"v{name}";

            Canvas.SetLeft(vertex, leftX);
            Canvas.SetBottom(vertex, bottomY);
        }

        /// <summary>
        /// Sets Edge coords
        /// </summary>
        /// <param name="edge"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        public static void SetEdgeProperties(Line edge, int x1, int y1, int x2, int y2)
        {
            edge.X1 = x1;
            edge.Y1 = 750 - y1; //gotta transform origin

            edge.X2 = x2;
            edge.Y2 = 750 - y2;

            SetEdgeColorFromTag(edge);

            edge.StrokeThickness = 3;
            edge.Opacity = 0.85;
        }

        /// <summary>
        /// Resets Edge Colors, by changing its Tag property
        /// </summary>
        /// <param name="adjMatrix"></param>
        /// <param name="edges"></param>
        public static void ResetEdgesStrokes(int[,] adjMatrix, List<Line> edges)
        {
            for (int i = 0; i < adjMatrix.GetLength(0); i++)
            {
                for (int j = i + 1; j < adjMatrix.GetLength(1); j++)
                {
                    if (adjMatrix[i, j] > 0)
                    {
                        var edge = edges.First(x => x.Name == $"v{i + 1}to{j + 1}" || x.Name == $"v{j + 1}to{i + 1}");
                        edge.Tag = adjMatrix[i, j];
                        SetEdgeColorFromTag(edge);
                    }
                }
            }

        }

        /// <summary>
        /// Sets edge color, using info contained in its tag. 7 - most light, most far away. 1 - darker, closer
        /// </summary>
        /// <param name="edge"></param>
        private static void SetEdgeColorFromTag(Line edge)
        {
            switch (edge.Tag)
            {
                case 7:
                    edge.Stroke = (SolidColorBrush)(new BrushConverter().ConvertFrom("#85C1E9 ")); // lighty - far away
                    break;

                case 6:
                    edge.Stroke = (SolidColorBrush)(new BrushConverter().ConvertFrom("#5DADE2 "));
                    break;

                case 5:
                    edge.Stroke = (SolidColorBrush)(new BrushConverter().ConvertFrom("#3498DB"));
                    break;

                case 4:
                    edge.Stroke = (SolidColorBrush)(new BrushConverter().ConvertFrom("#2E86C1"));
                    break;

                case 3:
                    edge.Stroke = (SolidColorBrush)(new BrushConverter().ConvertFrom("#2874A6 "));
                    break;

                case 2:
                    edge.Stroke = (SolidColorBrush)(new BrushConverter().ConvertFrom("#21618C"));
                    break;

                case 1:
                    edge.Stroke = (SolidColorBrush)(new BrushConverter().ConvertFrom("#1B4F72")); // dark - close
                    break;

                default:
                    break;

            }
            

        }
    }
}
