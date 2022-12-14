namespace MiniCad.Models
{
    using Helpers;
    
    public class Shape
    {}

    public class Dot : Shape
    {
        public const int Radius = 20;
        
        public Point Position { get; set; }

        public Rectangle BoundingBox => (Position, Radius).BoundingBox();
    }

    public class Line : Shape
    {
        public Point Start { get; set; }
        public Point End   { get; set; }

        public Rectangle BoundingBox
        {
            get {
                var boundingBox = new[] { Start, End }.BoundingBox();
                return boundingBox is null ? new Rectangle() : boundingBox.Value;
            }
        }
    }

    public class Circle : Shape
    {
        public Point Center { get; set; }
        public int Radius { get; set; }

        public Rectangle BoundingBox => (Center, Radius).BoundingBox();
    }
}
