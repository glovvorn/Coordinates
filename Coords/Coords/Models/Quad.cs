namespace Coords.Shared.Models
{
    public class Quad
    {
        public Triangle Triangle1 { get; set; }
        public Triangle Triangle2 { get; set; }

        public Quad(float left, float top, float width, float height)
        {
            Vertex2D topLeft = new Vertex2D { xCoord = left, yCoord = top };
            Vertex2D topRight = new Vertex2D { xCoord = left + width, yCoord = top };
            Vertex2D bottomLeft = new Vertex2D { xCoord = left, yCoord = top + height };
            Vertex2D bottomRight = new Vertex2D { xCoord = left + width, yCoord = top + height };

            Triangle1 = new Triangle(bottomLeft, topLeft, bottomRight);
            Triangle2 = new Triangle(topRight, bottomRight, topLeft);
        }
    }
}
