using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace SimpleGraphGenerator.Views.SceneUtils
{
    class Vertex : Label 
    {
        public List<LineWithInfo> LinkedEdges { get; set; } = new List<LineWithInfo>();

        

    }

    class LineWithInfo
    {
        public LineWithInfo(Line line, bool isBegining)
        {
            Line = line ?? throw new ArgumentNullException(nameof(line));
            this.isBegining = isBegining;
        }

        public Line Line { get; set; }
        public bool isBegining { get; set; }

    }
}
