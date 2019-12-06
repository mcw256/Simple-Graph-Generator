using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using SimpleGraphGenerator.Views.SceneUtils.ShapePositionersUtils;

namespace SimpleGraphGenerator.Views.SceneUtils
{
    static class ShapePositioners
    {
        public static void ArrangeVertexesRandomly(List<Vertex> vertexes, List<Ellipse> settingElls)
        {
            int halfway = (int)Math.Floor(vertexes.Count / 2.0);

            var rand = new Random(Guid.NewGuid().GetHashCode());

            // arrange half of the vertexes on first setting ellipse
            var settEllCenter = settingElls[0].GetCenter();
            var settEllRadius = settingElls[0].GetRadius();

            for (int i = 0; i < halfway; i++)
            {
                int sign = rand.NextDouble() > 0.5 ? (-1) : 1; // random number to decide whether to position on top or bottom half of the ellipse
                int x = rand.Next((int)settEllCenter.X - settEllRadius, (int)settEllCenter.X + settEllRadius); // random X in [begining of the ellipse, end of the ellipse]
                int helper = (int)Math.Sqrt((settEllRadius * settEllRadius) - ((x - settEllCenter.X) * (x - settEllCenter.X))); // calculate Y so the point is on the circle
                int y = sign * helper + (int)settEllCenter.Y;

                ShapesSetters.SetVertexProperties(vertexes[i], x - 13, y - 13, $"{i + 1}"); // -13 to fix the position so we place it at the center
            }

            // arrange half of the vertexes on first setting ellipse
            settEllCenter = settingElls[1].GetCenter();
            settEllRadius = settingElls[1].GetRadius();
  
            for (int i = halfway; i < vertexes.Count; i++)
            {
                int sign = rand.NextDouble() > 0.5 ? (-1) : 1; // random number to decide whether to position on top or bottom half of the ellipse
                int x = rand.Next((int)settEllCenter.X - settEllRadius, (int)settEllCenter.X + settEllRadius); // random X in [begining of the ellipse, end of the ellipse]
                int helper = (int)Math.Sqrt((settEllRadius * settEllRadius) - ((x - settEllCenter.X) * (x - settEllCenter.X))); // calculate Y so the point is on the circle
                int y = sign * helper + (int)settEllCenter.Y;

                ShapesSetters.SetVertexProperties(vertexes[i], x - 13, y - 13, $"{i + 1}"); // -13 to fix the position so we place it at the center
            }

        }

        public static void ArrangeVertexesEvenly(List<Vertex> vertexes, List<Ellipse> settingElls)
        {
            int halfway = (int)Math.Floor(vertexes.Count / 2.0);
            // arrange frist half of the vertexes on first setting ellipse
            var settEllCenter = settingElls[0].GetCenter();
            var settEllRadius = settingElls[0].GetRadius();
            var inc = 2 * Math.PI / halfway;

            for (int i = 0; i < halfway; i++)
            {
                var x = settEllCenter.X + settEllRadius * Math.Cos(0 + i * inc);
                var y = settEllCenter.Y + settEllRadius * Math.Sin(0 + i * inc);

                ShapesSetters.SetVertexProperties(vertexes[i], (int)x - 13, (int)y - 13, $"{i + 1}"); // -13 to fix the position so we place it at the center

            }
            // arrange second half of the vertexes on first setting ellipse
            settEllCenter = settingElls[1].GetCenter();
            settEllRadius = settingElls[1].GetRadius();
            inc = 2 * Math.PI /(vertexes.Count - halfway);
       
            for (int i = halfway; i < vertexes.Count; i++)
            {
                var x = settEllCenter.X + settEllRadius * Math.Cos(0 + i * inc);
                var y = settEllCenter.Y + settEllRadius * Math.Sin(0 + i * inc);
                ShapesSetters.SetVertexProperties(vertexes[i], (int)x - 13, (int)y - 13, $"{i + 1}"); // -13 to fix the position so we place it at the center  
            }

        }

        public static void ArrangeEdges(List<Line> edges, List<Vertex> vertexes)
        {
            for (int i = 0; i < edges.Count; i++)
            {
                var edgeName = edges[i].Name.TrimStart('v');
                var beginingAndEnd = Regex.Split(edgeName, "to");
                string beg = beginingAndEnd[0];
                string end = beginingAndEnd[1];

                Point begCoords = new Point();
                var begVertex = vertexes.First(x => x.Name == $"v{beg}");
                begCoords.X = Canvas.GetLeft(begVertex) + 13;
                begCoords.Y = Canvas.GetBottom(begVertex) + 13;

                Point endCords = new Point();
                var endVertex = vertexes.First(x => x.Name == $"v{end}");
                endCords.X = Canvas.GetLeft(endVertex) + 13;
                endCords.Y = Canvas.GetBottom(endVertex) + 13;

                ShapesSetters.SetEdgeProperties(edges[i], (int)begCoords.X, (int)begCoords.Y, (int)endCords.X, (int)endCords.Y);
            }
        }

        public static void ArrangeSingleEdge(Line edge, List<Vertex> vertexes)
        {
            var edgeName = edge.Name.TrimStart('v');
            var beginingAndEnd = Regex.Split(edgeName, "to");
            string beg = beginingAndEnd[0];
            string end = beginingAndEnd[1];

            Point begCoords = new Point();
            var begVertex = vertexes.First(x => x.Name == $"v{beg}");
            begCoords.X = Canvas.GetLeft(begVertex) - 13;
            begCoords.Y = Canvas.GetBottom(begVertex) - 13;

            Point endCords = new Point();
            var endVertex = vertexes.First(x => x.Name == $"v{end}");
            endCords.X = Canvas.GetLeft(endVertex) - 13;
            endCords.Y = Canvas.GetBottom(endVertex) - 13;

            ShapesSetters.SetEdgeProperties(edge, (int)begCoords.X, (int)begCoords.Y, (int)endCords.X, (int)endCords.Y);

        }

        public static void ArrangeSettingElls(List<Ellipse> settingElls)
        {
            ShapesSetters.SetSettingEllProperties(settingElls[0], 10, 10);
            ShapesSetters.SetSettingEllProperties(settingElls[1], 340, 340);
        }

        public static void LinkEdgesToVertexes(List<Vertex> vertexes, List<Line> edges)
        {
            if (edges.Count == 0) return;

            foreach (var edge in edges)
            {
                var edgeName = edge.Name.TrimStart('v');
                var beginingAndEnd = Regex.Split(edgeName, "to");
                string beg = beginingAndEnd[0];
                string end = beginingAndEnd[1];

                var begVertex = vertexes.First(x => x.Name == $"v{beg}");
                var endVertex = vertexes.First(x => x.Name == $"v{end}");

                begVertex.LinkedEdges.Add(new LineWithInfo(edge, true));
                endVertex.LinkedEdges.Add(new LineWithInfo(edge, false));
            }


        }

    }
}
