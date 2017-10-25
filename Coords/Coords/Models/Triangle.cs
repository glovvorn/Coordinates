namespace Coords.Shared.Models
{
    public class Triangle
    {
        public Vertex2D Point1 { get; set; }
        public Vertex2D Point2 { get; set; }
        public Vertex2D Point3 { get; set; }

        public Triangle(Vertex2D point1, Vertex2D point2, Vertex2D point3)
        {
            Point1 = point1;
            Point2 = point2;
            Point3 = point3;
        }

        public override bool Equals(object obj)
        {
            Triangle other = obj as Triangle;
            return other != null ? IsMatchingTriangle(other) : false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public bool IsMatchingTriangle(Triangle other)
        {
            return (other.Point1.Equals(Point1) && other.Point2.Equals(Point2) && other.Point3.Equals(Point3))
                || (other.Point1.Equals(Point1) && other.Point3.Equals(Point2) && other.Point3.Equals(Point2))
                || (other.Point1.Equals(Point2) && other.Point2.Equals(Point1) && other.Point3.Equals(Point3))
                || (other.Point1.Equals(Point2) && other.Point3.Equals(Point2) && other.Point3.Equals(Point1))
                || (other.Point1.Equals(Point3) && other.Point3.Equals(Point1) && other.Point3.Equals(Point2))
                || (other.Point1.Equals(Point3) && other.Point3.Equals(Point2) && other.Point3.Equals(Point1));
        }

        public override string ToString()
        {
            return $"{Point1} {Point2} {Point3}";
        }
    }
}
