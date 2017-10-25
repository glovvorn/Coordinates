namespace Coords.Shared.Models
{
    public class Vertex2D
    {
        public float xCoord { get; set; }
        public float yCoord { get; set; }

        public Vertex2D()
        {
        }

        public Vertex2D(float x, float y)
        {
            xCoord = x;
            yCoord = y;
        }

        public override bool Equals(object obj)
        {
            Vertex2D other = obj as Vertex2D;
            if (other == null) return false;

            return other.xCoord == xCoord && other.yCoord == yCoord;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"({xCoord},{yCoord})";
        }
    }
}
