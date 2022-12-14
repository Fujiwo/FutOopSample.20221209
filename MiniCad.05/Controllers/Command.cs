namespace MiniCad.Controllers
{
    using Models;
    using ViewModels;
    using Helpers;
    using System.Drawing;

    interface ICommand
    {
        bool OnInput(Point point);
        bool OnCursorMove(Point point);
        void Draw(Graphics graphics);
    }

    abstract class Command : ICommand
    {
        const int penWidth = 10;
        static Pen pen = new Pen(Color.Black, penWidth);

        protected Pen Pen => pen;
        
        public Model Model { get; set; } = null!;

        public virtual bool OnInput(Point point) => false;
        public virtual bool OnCursorMove(Point point) => false;
        public virtual void Draw(Graphics graphics) {}
    }

    class NullCommand : Command
    {}

    class AddDotCommand : Command
    {
        Point position;
        
        public override bool OnInput(Point point)
        {
            Model.Add(new DotFigure { Position = point });
            return true;
        }

        public override bool OnCursorMove(Point point)
        {
            position = point;
            return true;
        }
        
        public override void Draw(Graphics graphics) => new Dot { Position = position }.Draw(graphics);
    }

    class AddLineCommand : Command
    {
        bool  isFirst = true;
        Point start;
        Point end;

        public override bool OnInput(Point point)
        {
            if (isFirst)
                start = point;
            else
                Model.Add(new LineFigure { Start = start, End = point });
            isFirst = !isFirst;
            return true;
        }

        public override bool OnCursorMove(Point point)
        {
            if (isFirst)
                return false;
            end = point;
            return true;
        }

        public override void Draw(Graphics graphics)
        {
            if (!isFirst)
                new Line { Start = start, End = end }.Draw(graphics);
        }
    }

    class AddCircleCommand : Command
    {
        bool isFirst = true;
        Point center;
        Point lastPoint;

        public override bool OnInput(Point point)
        {
            if (isFirst)
                center = point;
            else
                Model.Add(new CircleFigure { Center = center, Radius = center.Distance(point) });
            isFirst = !isFirst;
            return true;
        }

        public override bool OnCursorMove(Point point)
        {
            if (isFirst)
                return false;
            lastPoint = point;
            return true;
        }

        public override void Draw(Graphics graphics)
        {
            if (!isFirst)
                new Circle { Center = center, Radius = center.Distance(lastPoint) }.Draw(graphics);
        }
    }
}
