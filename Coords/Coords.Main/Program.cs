using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coords.Shared.Models;

namespace Coords.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = 6;
            int columns = 12;
            float width = 60.0f;
            float height = 60.0f;

            var grid = new Grid(rows, columns, width, height);

            Console.WriteLine($"Triangle at C5: {grid.GetTriangle('C', 5)}");

            Console.WriteLine($"Triangle at E10: {grid.GetTriangle('E', 10)}");

            Vertex2D vertex1 = new Vertex2D(20, 30);
            Vertex2D vertex2 = new Vertex2D(20, 40);
            Vertex2D vertex3 = new Vertex2D(10, 30);

            Console.WriteLine($"Getting triangle at coordinates {vertex1} {vertex2} {vertex3}:");
            Console.WriteLine("\t" + grid.GetTriangleRowAndColumn(vertex1, vertex2, vertex3));
            
            Console.ReadLine();
        }
    }
}
