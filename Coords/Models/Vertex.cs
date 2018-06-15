using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coords.Models
{
    public struct Vertex
    {
        public Vertex(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; private set; }
        public int Y { get; private set; }

        public override string ToString()
        {
            return $"{X}, {Y}";
        }
    }
}