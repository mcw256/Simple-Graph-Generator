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

            var vertexes = Creators.CreateVertexes(15);
            var settingElls = Creators.CreateSettingElls();

            ShapePositioners.ArrangeSettingElls(settingElls);
            ShapePositioners.ArrangeVertexesRandomly(vertexes, settingElls);

            for (int i = 0; i < settingElls.Count; i++)
            {
                this.Children.Add(settingElls[i]);
            }
            for (int i = 0; i < vertexes.Count; i++)
            {
                this.Children.Add(vertexes[i]);
            }       
        }

        

    }
}
