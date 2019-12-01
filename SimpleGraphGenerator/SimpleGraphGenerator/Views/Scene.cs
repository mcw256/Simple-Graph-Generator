using SimpleGraphGenerator.BusinessLogic;
using SimpleGraphGenerator.Views.SceneUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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

        

    }
}
