using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coords.Shared.Models
{
    public class Grid
    {
        #region Private Variables

        private int _rows;
        private int _columns;
        private float _width;
        private float _height;

        #endregion

        #region Properties

        public int Rows
        {
            get => _rows;
            set
            {
                if (value != _rows)
                {
                    _rows = value;
                    calculateGrid();
                }
            }
        }
        public int Columns
        {
            get => _columns;
            set
            {
                if (value != _columns)
                {
                    _columns = value;
                    calculateGrid();
                }
            }
        }

        public float Width
        {
            get => _width;
            set
            {
                if (value != _width)
                {
                    _width = value;
                    calculateGrid();
                }
            }
        }
        public float Height
        {
            get => _height;
            set
            {
                if (value != _height)
                {
                    _height = value;
                    calculateGrid();
                }
            }
        }
        
        public Quad[,] Quads;

        #endregion

        #region Constructor

        public Grid(int rows, int columns, float width, float height)
        {
            _rows = rows;
            _columns = columns;
            _width = width;
            _height = height;

            calculateGrid();
        }

        #endregion

        #region Public Methods

        public Triangle GetTriangle(char row, int column)
        {
            return GetTriangle(row.ToString(), column);
        }

        public Triangle GetTriangle(string row, int column)
        {
            return RowValues.ContainsKey(row) ? GetTriangle(RowValues[row], column) : null;
        }

        public TriangleRowColumn GetTriangleRowAndColumn(Vertex2D point1, Vertex2D point2, Vertex2D point3)
        {
            Triangle triangleToMatch = new Triangle(point1, point2, point3);

            int quadColumns = Columns / 2;
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < quadColumns; c++)
                {
                    var quad = Quads[r, c];
                    if (quad.Triangle1.Equals(triangleToMatch))
                    {
                        int cIndex = (c * 2) + 1;
                        return new TriangleRowColumn
                        {
                            Row = GetTriangleRowFromIndex(r),
                            Column = cIndex
                        };
                    }
                    if (quad.Triangle2.Equals(triangleToMatch))
                    {
                        int cIndex = (c * 2) + 2;
                        return new TriangleRowColumn
                        {
                            Row = GetTriangleRowFromIndex(r),
                            Column = cIndex
                        };
                    }
                }
            }

            return null;
        }

        #endregion

        #region Private Methods

        private void calculateGrid()
        {
            int quadColumns = Columns / 2;
            Quads = new Quad[Rows, quadColumns];

            float quadWidth = Width / quadColumns;
            float quadHeight = Height / Rows;

            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < quadColumns; c++)
                {
                    float left = c * quadWidth;
                    float top = r * quadHeight;
                    Quads[r, c] = new Quad(left, top, quadWidth, quadHeight);
                }
            }
        }

        private Triangle GetTriangle(int row, int column)
        {
            int rowIndex = row - 1;
            int columnIndex = ((column + 1) / 2) - 1;

            var q = Quads[rowIndex, columnIndex];

            return column % 2 == 1 ? q.Triangle1 : q.Triangle2;
        }

        private string GetTriangleRowFromIndex(int row)
        {
            var rowString = RowValues.FirstOrDefault(x => x.Value == (row + 1)).Key;
            return rowString;
        }

        #endregion

        private Dictionary<string, int> RowValues = new Dictionary<string, int>
        {
            {"A", 1},
            {"B", 2},
            {"C", 3},
            {"D", 4},
            {"E", 5},
            {"F", 6},
            {"G", 7},
            {"H", 8},
            {"I", 9},
            {"J", 10},
            {"K", 11},
            {"L", 12},
            {"M", 13},
            {"N", 14},
            {"O", 15},
            {"P", 16},
            {"Q", 17},
            {"R", 18},
            {"S", 19},
            {"T", 20},
            {"U", 21},
            {"V", 22},
            {"W", 23},
            {"X", 24},
            {"Y", 25},
            {"Z", 26}
        };
    }
}
