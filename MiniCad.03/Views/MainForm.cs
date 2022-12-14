namespace MiniCad.Views
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        void exitToolStripMenuItem_Click(object sender, EventArgs e)
            => Application.Exit();
    }
}