namespace MiniCad.Models
{
    class Figure
    {
        public virtual IEnumerable<Shape> Shapes => new Shape[0];
    }

    class DotFigure : Figure
    {
        const int radius = 20;

        public Point Position { get; set; }

        public override IEnumerable<Shape> Shapes => new[] { new Circle { Center = Position, Radius = radius } };
    }
}
