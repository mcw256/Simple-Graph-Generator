using SimpleGraphGenerator.BusinessLogic;
using SimpleGraphGenerator.BusinessLogic.Algorithms;
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
        int[,] _adjMatirx;
        List<Ellipse> _settingElls;
        List<Vertex> _vertexes;
        List<Line> _edges;


        public Scene()
        {
            this.Width = 750;
            this.Height = 750; 
            this.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ecf4ef"));
        }

        #region public methods
        /// <summary>
        /// Draws new graph, returns amount of edges
        /// </summary>
        /// <param name="prob"></param>
        /// <returns></returns>
        public int DrawNewGraph(double prob, int vertexesAmount)
        {
            //clean up
            this.Children.Clear();

            _adjMatirx = AdjacentMatrix.Create(vertexesAmount);
            AdjacentMatrix.FillWithGivenProbability(_adjMatirx, prob);
            AdjacentMatrix.FillDiagonalWithZeros(_adjMatirx);
            AdjacentMatrix.FillLeftBottomHalf(_adjMatirx);

            _settingElls = Creators.CreateSettingElls();
            _vertexes = Creators.CreateVertexes(vertexesAmount);
            _edges = Creators.CreateEdgesFromAdjMatrix(_adjMatirx);

            ShapePositioners.ArrangeSettingElls(_settingElls);
            ShapePositioners.ArrangeVertexesRandomly(_vertexes, _settingElls);
            ShapePositioners.ArrangeEdges(_edges, _vertexes);
            ShapePositioners.LinkEdgesToVertexes(_vertexes, _edges);

            //Link dragging events
            foreach (var item in _vertexes)
            {
                item.MouseLeftButtonDown += VertexMouseLeftButtonDown;
                item.MouseLeftButtonUp += VertexMouseLeftButtonUp;
                item.MouseMove += VertexMouseMove;
            }

            //Add elements to the scene
            foreach (var item in _settingElls)
                this.Children.Add(item);

            foreach (var item in _edges)
                this.Children.Add(item);

            foreach (var item in _vertexes)
                this.Children.Add(item);


            return _edges.Count;
        }

        public void RerollVertexesLocations()
        {
            //clean up
            this.Children.Clear();
            

            ShapePositioners.ArrangeVertexesRandomly(_vertexes, _settingElls);
            ShapePositioners.ArrangeEdges(_edges, _vertexes);
            ShapePositioners.LinkEdgesToVertexes(_vertexes, _edges);

            //Add elements to the scene
            foreach (var item in _settingElls)
                this.Children.Add(item);

            foreach (var item in _edges)
                this.Children.Add(item);

            foreach (var item in _vertexes)
                this.Children.Add(item);
        }

        public void SpaceVertexesEvenly()
        {
            //clean up
            this.Children.Clear();

            ShapePositioners.ArrangeVertexesEvenly(_vertexes, _settingElls);
            ShapePositioners.ArrangeEdges(_edges, _vertexes);
            ShapePositioners.LinkEdgesToVertexes(_vertexes, _edges);

            //Add elements to the scene
            foreach (var item in _settingElls)
                this.Children.Add(item);

            foreach (var item in _edges)
                this.Children.Add(item);

            foreach (var item in _vertexes)
                this.Children.Add(item);

        }

        public void ColorShortestPath(int beg, int end)
        {
            if (beg == end) return;

            var q = new DijkstraShortestPath(_adjMatirx);
            var list = q.ShortestPath(beg, end);
            foreach (var item in list)
            {
                var edge = _edges.First(x => x.Name == $"v{item.X+1}to{item.Y+1}" || x.Name == $"v{item.Y+1}to{item.X+1}");
                edge.Tag = -1;
                edge.Stroke = (SolidColorBrush)(new BrushConverter().ConvertFrom("#b700ff"));
            }
        }

        public bool IsGraphConnected()
        {
            var q = new ConnectivityChecker(_adjMatirx);

            return q.IsConnected();
        }

        #endregion

        #region dragging event handlers
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
            double left = mousePos.X - (((Vertex)sender).ActualWidth / 2);
            double top = mousePos.Y - (((Vertex)sender).ActualHeight / 2);
            Canvas.SetLeft(((Vertex)sender), left);
            Canvas.SetBottom(((Vertex)sender), (this.ActualHeight - top)-((Vertex)sender).ActualHeight);

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
        #endregion
    }
}
