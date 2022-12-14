namespace MiniCad.Models
{
    public class Figure
    {
        const int radius = 20;

        public Point Position { get; set; }

        public IEnumerable<Shape> Shapes => new[] { new Circle { Center = Position, Radius = radius } };
    }
}
