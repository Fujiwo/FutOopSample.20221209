namespace MiniCad.Views
{
    using Controllers;

    partial class MainForm : Form
    {
        CommandManager commandManager = null!;
        
        public MainForm()
        {
            InitializeComponent();
            InitializeOthers();
        }
        
        void InitializeOthers()
        {
            commandManager = new CommandManager(model: model);
            view.CommandManager = commandManager;
            model.Update += () => view.Invalidate();
        }
        
        void OnFileExit(object sender, EventArgs e)
            => Application.Exit();

        void OnFigureDot(object sender, EventArgs e) => commandManager.Set(new AddDotCommand());
        void OnFigureLine(object sender, EventArgs e) => commandManager.Set(new AddLineCommand());
        void OnFigureCircle(object sender, EventArgs e) => commandManager.Set(new AddCircleCommand());

        void OnViewMouseClick(object sender, MouseEventArgs e) => commandManager.OnInput(e.Location);

        void OnViewMouseMove(object sender, MouseEventArgs e)
        {
            if (commandManager.OnCursorMove(e.Location))
                view.Invalidate();
        }
    }
}