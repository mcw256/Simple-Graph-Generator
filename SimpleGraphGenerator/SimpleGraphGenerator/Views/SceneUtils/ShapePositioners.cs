﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace SimpleGraphGenerator.Views.SceneUtils
{
    static class ShapePositioners
    {
        public static void ArrangeVertexesRandomly(List<Label> vertexes, List<Ellipse> settingElls)
        {
            var rand = new Random(Guid.NewGuid().GetHashCode());

            // arrange half of the vertexes on first setting ellipse
            var settEllCenter = settingElls[0].GetCenter();
            var settEllRadius = settingElls[0].GetRadius();
            //place first seven
            for (int i = 0; i < 7; i++)
            {
                int sign = rand.NextDouble() > 0.5 ? (-1) : 1; // random number to decide whether to position on top or bottom half of the ellipse
                int x = rand.Next((int)settEllCenter.X - settEllRadius, (int)settEllCenter.X + settEllRadius); // random X in [begining of the ellipse, end of the ellipse]
                int helper = (int)Math.Sqrt((settEllRadius * settEllRadius) - ((x - settEllCenter.X) * (x - settEllCenter.X))); // calculate Y so the point is on the circle
                int y = sign * helper + (int)settEllCenter.Y;

                ShapesPropertiesSetters.SetVertexProperties(vertexes[i], x - 13, y - 13, $"{i + 1}"); // -13 to fix the position so we place it at the center
            }

            // arrange half of the vertexes on first setting ellipse
            settEllCenter = settingElls[1].GetCenter();
            settEllRadius = settingElls[1].GetRadius();
            //place second eight
            for (int i = 7; i < 15; i++)
            {
                int sign = rand.NextDouble() > 0.5 ? (-1) : 1; // random number to decide whether to position on top or bottom half of the ellipse
                int x = rand.Next((int)settEllCenter.X - settEllRadius, (int)settEllCenter.X + settEllRadius); // random X in [begining of the ellipse, end of the ellipse]
                int helper = (int)Math.Sqrt((settEllRadius * settEllRadius) - ((x - settEllCenter.X) * (x - settEllCenter.X))); // calculate Y so the point is on the circle
                int y = sign * helper + (int)settEllCenter.Y;

                ShapesPropertiesSetters.SetVertexProperties(vertexes[i], x - 13, y - 13, $"{i + 1}"); // -13 to fix the position so we place it at the center
            }

        }

        public static void ArrangeEdges(List<Line> edges, List<Label> vertexes)
        {
            for (int i = 0; i < edges.Count; i++)
            {
                var edgeName = edges[i].Name.TrimStart('v');
                var beginingAndEnd = Regex.Split(edgeName, "to");
                string beg = beginingAndEnd[0];
                string end = beginingAndEnd[1];

                Point begCoords = new Point();
                var begVertex = vertexes.First(x => x.Name == $"v{beg}");
                begCoords.X = Canvas.GetLeft(begVertex)+13;
                begCoords.Y = Canvas.GetBottom(begVertex)+13;

                Point endCords = new Point();
                var endVertex = vertexes.First(x => x.Name == $"v{end}");
                endCords.X = Canvas.GetLeft(endVertex)+13;
                endCords.Y = Canvas.GetBottom(endVertex)+13;

                ShapesPropertiesSetters.SetEdgeProperties(edges[i], (int)begCoords.X, (int)begCoords.Y, (int)endCords.X, (int)endCords.Y);
            }
        }

        public static void ArrangeSingleEdge(Line edge, List<Label> vertexes)
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

            ShapesPropertiesSetters.SetEdgeProperties(edge, (int)begCoords.X, (int)begCoords.Y, (int)endCords.X, (int)endCords.Y);

        }

        public static void ArrangeSettingElls(List<Ellipse> settingElls)
        {
            ShapesPropertiesSetters.SetSettingEllProperties(settingElls[0], 10, 10);
            ShapesPropertiesSetters.SetSettingEllProperties(settingElls[1], 340, 340);
        }

    }
}