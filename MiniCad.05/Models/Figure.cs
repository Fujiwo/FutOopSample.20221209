namespace MiniCad.Models
{
    class Figure
    {
        public virtual IEnumerable<Shape> Shapes => new Shape[0];
    }

    class DotFigure : Figure
    {
        public const int Radius = 20;
        
        public Point Position { get; set; }

        public override IEnumerable<Shape> Shapes => new[] { new Dot { Position = Position } };
    }

    class LineFigure : Figure
    {
        public Line Position { get; set; } = new Line();

        public Point Start { get => Position.Start; set => Position.Start = value; }
        public Point End   { get => Position.End  ; set => Position.End   = value; }

        public override IEnumerable<Shape> Shapes => new[] { Position };
    }

    class CircleFigure : Figure
    {
        public Circle Position { get; set; } = new Circle();
        
        public Point Center { get => Position.Center; set => Position.Center = value; }
        public int   Radius { get => Position.Radius; set => Position.Radius = value; }

        public override IEnumerable<Shape> Shapes => new[] { Position };
    }
}
