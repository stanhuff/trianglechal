using Coords.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace Coords.Controllers
{
    [RoutePrefix("triangle")]
    public class TriangleController : ApiController
    {

        const int CellPixels = 10;

        [Route("vertices")]
        public IEnumerable<Vertex> GetTriangleVertices(string coords)
        {

            var row = Char.ToLower(coords[0]) - 'a';
            var x = int.Parse(coords.Substring(1));

            var isBottom = x % 2 == 1;
            var col = (x - 1) / 2;

            var top = row * CellPixels;
            var bottom = (row + 1) * CellPixels;

            var left = col * CellPixels;
            var right = (col + 1) * CellPixels;

            var point1 = new Vertex(left, top);
            var point2 = new Vertex(right, bottom);
            var point3 = isBottom ? new Vertex(left, bottom) : new Vertex(right, top);

            return isBottom
                ? new[]
                {
                    point3, point2, point1
                }
                : new[]
                {
                    point3, point1, point2
                };
        }

        [Route("coords")]
        [HttpPost]
        public string GetTriangleCoords([FromBody]  IEnumerable<Vertex> verts)
        {
            var normalizedCoords = NormalizedVerts(verts);

            var isBottom = normalizedCoords[1].X == normalizedCoords[0].X;

            var col = (normalizedCoords[0].X / CellPixels) + (isBottom ? 1 : 2);

            var row = (normalizedCoords[0].Y / CellPixels);

            return (char)('A' + row) + col.ToString();
        }

        private Vertex[] NormalizedVerts(IEnumerable<Vertex> coords)
        {
            var ary = coords.ToArray();
            Array.Sort(ary, Comparerer.Default);
            return ary;
        }

        class Comparerer : IComparer<Vertex>
        {
            public static readonly Comparerer Default = new Comparerer();
            public int Compare(Vertex x, Vertex y)
            {
                if (x.Y < y.Y)
                    return -1;
                if (x.Y > y.Y)
                    return 1;
                if (x.X < y.X)
                    return -1;
                if (x.X > y.X)
                    return 1;
                return 0;
            }
        }
    }
}
