namespace MiniCad.Controllers
{
    using Models;
    
    interface ICommand
    {
        bool OnInput(Point point);
    }

    abstract class Command : ICommand
    {
        public Model Model { get; set; } = null!;

        public virtual bool OnInput(Point point) => false;
    }

    class NullCommand : Command
    {}

    class AddDotCommand : Command
    {
        public override bool OnInput(Point point)
        {
            Model.Add(new DotFigure { Position = point });
            return true;
        }
    }
}
