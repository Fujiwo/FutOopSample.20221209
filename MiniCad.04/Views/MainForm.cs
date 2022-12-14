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
            model.Update += () => view.Invalidate();
        }
        
        void OnFileExit(object sender, EventArgs e)
            => Application.Exit();

        void OnFigureDot(object sender, EventArgs e) => commandManager.Set(new AddDotCommand());

        void OnFigureLine(object sender, EventArgs e)
        {

        }

        void OnFigureCircle(object sender, EventArgs e)
        {

        }

        void OnViewMouseClick(object sender, MouseEventArgs e) => commandManager.OnInput(e.Location);
    }
}