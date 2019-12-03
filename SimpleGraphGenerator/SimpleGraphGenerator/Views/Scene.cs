using SimpleGraphGenerator.BusinessLogic;
using SimpleGraphGenerator.Views.SceneUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SimpleGraphGenerator.Views
{
    class Scene : Canvas 
    {
        public Scene()
        {
            this.Width = 750;
            this.Height = 750;
            
            this.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ecf4ef"));

            var adjMatrix = AdjacentMatrixSupplier.Supply(15);

            IAdjacentMatrixOperations operation = new FillWithGivenProb(0.3);
            operation.OperateOn(adjMatrix);

            operation = new FillDiagonal();
            operation.OperateOn(adjMatrix);

            operation = new FillBottomHalf();
            operation.OperateOn(adjMatrix);


            var vertexes = Creators.CreateVertexes(15);
            var settingElls = Creators.CreateSettingElls();
            var edges = Creators.CreateEdgesFromAdjMatrix(adjMatrix);


            ShapePositioners.ArrangeSettingElls(settingElls);
            ShapePositioners.ArrangeVertexesRandomly(vertexes, settingElls);
            ShapePositioners.ArrangeEdges(edges, vertexes);
            ShapePositioners.LinkEdgesToVertexes(vertexes, edges);

            foreach (var item in vertexes)
            {
                item.MouseLeftButtonDown += VertexMouseLeftButtonDown;
                item.MouseLeftButtonUp += VertexMouseLeftButtonUp;
                item.MouseMove += VertexMouseMove;
            }
            


            for (int i = 0; i < settingElls.Count; i++)
            {
                this.Children.Add(settingElls[i]);
            }
            for (int i = 0; i < edges.Count; i++)
            {
                this.Children.Add(edges[i]);
            }

            for (int i = 0; i < vertexes.Count; i++)
            {
                this.Children.Add(vertexes[i]);
            }       
        }




        bool _isVertexDragInProg;
        private void VertexMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _isVertexDragInProg = true;
            ((Label)sender).CaptureMouse();
        }

        private void VertexMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _isVertexDragInProg = false;
            ((Label)sender).ReleaseMouseCapture();
        }

        private void VertexMouseMove(object sender, MouseEventArgs e)
        {
            if (!_isVertexDragInProg) return;

            // get the position of the mouse relative to the Canvas
            var mousePos = e.GetPosition(this);

            // center the rect on the mouse
            double left = mousePos.X - (((Label)sender).ActualWidth / 2);
            double top = mousePos.Y - (((Label)sender).ActualHeight / 2);
            Canvas.SetLeft(((Label)sender), left);
            Canvas.SetTop(((Label)sender), top);

            foreach (var item in ((Vertex)sender).LinkedEdges)
            {
                if (item.isBegining)
                {
                    item.Line.X1 = left + 13;
                    item.Line.Y1 = top + 13;
                }
                else
                {
                    item.Line.X2 = left + 13;
                    item.Line.Y2 = top + 13;
                }
            }

        }

       
    }
}
