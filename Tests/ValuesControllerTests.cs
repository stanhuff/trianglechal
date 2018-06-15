using System;
using Coords.Controllers;
using Coords.Models;
using Xunit;

namespace Tests
{
    public class ValuesControllerTests
    {
        [Fact]
        public void GetTriangleVerticesA1()
        {
            var values = new TriangleController().GetTriangleVertices("A1");
            Assert.Equal(new[] { new Vertex(0, 10), new Vertex(10, 10), new Vertex(0, 0) }, values);
        }

        [Fact]
        public void GetTriangleVerticesA2()
        {
            var values = new TriangleController().GetTriangleVertices("A2");
            Assert.Equal(new[] { new Vertex(10, 0), new Vertex(0, 0), new Vertex(10, 10) }, values);
        }

        [Fact]
        public void GetTriangleVerticesC2()
        {
            var values = new TriangleController().GetTriangleVertices("C2");
            Assert.Equal(new[] { new Vertex(10, 20), new Vertex(0, 20), new Vertex(10, 30) }, values);
        }

        [Fact]
        public void GetTriangleCoordsA1()
        {
            var coords = new TriangleController().GetTriangleCoords(new[] { new Vertex(0, 0), new Vertex(0, 10), new Vertex(10, 10) });
            Assert.Equal("A1", coords);
        }

        [Fact]
        public void GetTriangleCoordsA2()
        {
            var coords = new TriangleController().GetTriangleCoords(new[] { new Vertex(0, 0), new Vertex(10, 0), new Vertex(10, 10) });
            Assert.Equal("A2", coords);
        }

        [Fact]
        public void GetTriangleCoordsC2()
        {
            var coords = new TriangleController().GetTriangleCoords(new[] { new Vertex(10, 20), new Vertex(0, 20), new Vertex(10, 30) });
            Assert.Equal("C2", coords);
        }
    }
}
