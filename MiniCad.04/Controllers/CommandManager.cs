namespace MiniCad.Controllers
{
    using Models;

    class CommandManager : ICommand
    {
        Command currentCommand = null!;

        public Model Model { get; init; }

        public CommandManager(Model model)
        {
            Model = model;
            Set(new NullCommand());
        }

        public void Set(Command command)
        {
            command.Model = Model;
            currentCommand = command;
        }

        public bool OnInput(Point point) => currentCommand.OnInput(point);
    }
}
