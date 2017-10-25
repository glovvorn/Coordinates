using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Coords.Shared.Models;

namespace Coords.Test
{
    [TestClass]
    public class CoordsTest
    {
        private int _rows = 6;
        private int _columns = 12;
        private float _width = 60.0f;
        private float _height = 60.0f;

        private Grid _grid;

        [TestInitialize]
        public void TestInitialize()
        {
            _grid = new Grid(_rows, _columns, _width, _height);
        }

        [TestMethod]
        public void GetTriangleAtE5()
        {
            Triangle expectedTriangle = new Triangle
            (
                new Vertex2D(20, 50),
                new Vertex2D(20, 40),
                new Vertex2D(30, 50)
            );
            
            Triangle actualTriangle = _grid.GetTriangle("E", 5);

            Assert.AreEqual(expectedTriangle, actualTriangle);
        }

        [TestMethod]
        public void GetTriangleRowColumnFromVertices()
        {
            TriangleRowColumn expected = new TriangleRowColumn
            {
                Row = "B",
                Column = 9
            };

            Vertex2D vertex1 = new Vertex2D(40, 20);
            Vertex2D vertex2 = new Vertex2D(40, 10);
            Vertex2D vertex3 = new Vertex2D(50, 20);
            TriangleRowColumn actual = _grid.GetTriangleRowAndColumn(vertex1, vertex2, vertex3);

            Assert.AreEqual(expected, actual);
        }
    }
}
