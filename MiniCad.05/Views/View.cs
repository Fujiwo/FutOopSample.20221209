using System.ComponentModel;
namespace MiniCad.Views
{
    using Models;
    using ViewModels;
    using Controllers;
    using Helpers;

    partial class View : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ICommand? CommandManager { get; set; }

        public View() => InitializeComponent();
        
        void OnPaint(object sender, PaintEventArgs e)
        {
            var model = DataContext as IEnumerable<Figure>;
            if (model is null)
                return;

            model.SelectMany(figure => figure.Shapes)
                 .ForEach(shape => shape.Draw(e.Graphics));

            CommandManager?.Draw(e.Graphics);
        }
    }
}
